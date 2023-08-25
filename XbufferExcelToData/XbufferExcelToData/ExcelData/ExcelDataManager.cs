/*
 * Description:             表格数据读取类
 * Author:                  tanghuan
 * Create Date:             2018/09/02
 */

using Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XbufferExcelToData
{
    /// <summary>
    /// 表格数据单例读取管理类
    /// </summary>
    public class ExcelDataManager : SingletonTemplate<ExcelDataManager>
    {
        /// <summary> Excel目录路径 /// </summary>
        public string ExcelFolderPath { get; private set; }

        /// <summary> 所有的excel文件 /// </summary>
        public List<string> AllExcelFilesList { get; private set; }

        /// <summary>
        /// 表格信息映射Map
        /// Key为表格名字，Value为对应表格的信息
        /// </summary>
        public Dictionary<string, ExcelInfo> ExcelsInfoMap { get; private set; }

        #region Excel数据规则
        /// <summary>
        /// 不参与导表的sheet名开头标识
        /// </summary>
        private const string BLACK_LIST_PREFIX = "blacklist";

        /// <summary>
        /// 有效的Id类型列表
        /// </summary>
        public static List<string> ValideIdTypeList = new List<string>
        {
            ExcelDataConst.IntTypeName,
            ExcelDataConst.StringTypeName,
        };
        #endregion

        /// <summary>
        /// Excel文件有效的后缀名过滤
        /// </summary>
        private List<string> ValideExcelPostFixFilter;

        /// <summary>
        /// 有效的数据类型配置(不含嵌套Class类型)
        /// </summary>
        private List<string> ValideTypesList;

        /// <summary>
        /// 有效的一维数据类型配置(不含嵌套Class类型)
        /// </summary>
        private List<string> ValideOneArrayTypesList;

        /// <summary>
        /// 有效的二维数据类型配置(不含嵌套Class类型)
        /// </summary>
        private List<string> ValideTwoArrayTypesList;

        /// <summary>
        /// 有效的分割符号配置
        /// </summary>
        //private List<char> ValideSplitersList;

        /// <summary>
        /// 临时id判定Map(优化GC问题)
        /// </summary>
        private Dictionary<string, string> mTempIdMap;

        public ExcelDataManager()
        {
            ExcelFolderPath = string.Empty;
            AllExcelFilesList = new List<string>();
            ExcelsInfoMap = new Dictionary<string, ExcelInfo>();
            ValideExcelPostFixFilter = new List<string>(new string[] { "*.xlsx", "*.xls", "*.csv" });
            ValideTypesList = new List<string>
            {
                ExcelDataConst.NotationTypeName, // 第一个notation是特殊类型，用于表示注释列
                ExcelDataConst.IntTypeName, ExcelDataConst.FloatTypeName, ExcelDataConst.StringTypeName,
                ExcelDataConst.LongTypeName, ExcelDataConst.BoolTypeName, ExcelDataConst.ByteTypeName,
            };
            ValideOneArrayTypesList = new List<string>()
            {
                $"{ExcelDataConst.IntTypeName}[]", $"{ExcelDataConst.FloatTypeName}[]", $"{ExcelDataConst.StringTypeName}[]",
                $"{ExcelDataConst.LongTypeName}[]", $"{ExcelDataConst.BoolTypeName}[]", $"{ExcelDataConst.ByteTypeName}[]",
            };
            ValideTwoArrayTypesList = new List<string>()
            {
                $"{ExcelDataConst.IntTypeName}[][]", $"{ExcelDataConst.FloatTypeName}[][]", $"{ExcelDataConst.StringTypeName}[][]",
                $"{ExcelDataConst.LongTypeName}[][]", $"{ExcelDataConst.BoolTypeName}[][]", $"{ExcelDataConst.ByteTypeName}[][]",
            };

            mTempIdMap = new Dictionary<string, string>();
        }

        /// <summary>
        /// 配置Excel目录路径
        /// </summary>
        /// <param name="excelfolderpath"></param>
        public void ConfigExcelFolderPath(string excelfolderpath)
        {
            ExcelFolderPath = excelfolderpath;
        }

        /// <summary>
        /// 加载所有的Excel数据信息
        /// </summary>
        /// <returns></returns>
        public bool LoadAllDataFromExcelFile()
        {
            if(!ReadAllExcelFiles())
            {
                return false;
            }

            if(!ReadAllExcelFilesInfo())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 读取所有Excel文件
        /// </summary>
        private bool ReadAllExcelFiles()
        {
            if (Directory.Exists(ExcelFolderPath))
            {
                AllExcelFilesList.Clear();
                foreach (var postfixfilter in ValideExcelPostFixFilter)
                {
                    var files = Directory.GetFiles(ExcelFolderPath, postfixfilter);
                    foreach(var file in files)
                    {
                        if(AllExcelFilesList.Contains(file))
                        {
                            continue;
                        }
                        else
                        {
                            AllExcelFilesList.Add(file);
                        }
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine(string.Format("Excel目录不存在:{0}", ExcelFolderPath));
                return false;
            }
        }

        /// <summary>
        /// 读取所有Excel文件内部信息
        /// </summary>
        private bool ReadAllExcelFilesInfo()
        {
            ExcelsInfoMap.Clear();
            bool issuccess = true;
            foreach (var excelfile in AllExcelFilesList)
            {
                // 如果配置有问题，直接退出
                if (issuccess == false)
                {
                    Console.WriteLine("配置有问题，请先修正配置后再导出!");
                    break;
                }
                FileStream fs = File.Open(excelfile, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                if (!excelreader.IsValid)
                {
                    Console.WriteLine(string.Format("Excel文件:{0}读取失败！", excelfile));
                    issuccess = false;
                    break;
                }
                else
                {
                    #if DEBUG
                    Console.WriteLine(string.Format("Excel文件.Name:{0}", excelreader.Name));
                    #endif
                    var dataset = excelreader.AsDataSet();
                    for (int index = 0, length = dataset.Tables.Count; index < length; index++)
                    {
                        if (IsValideSheet(excelreader.Name))
                        {
                            if (HasSheetNameExist(excelreader.Name))
                            {
                                Console.WriteLine(string.Format("Excel:{0}有重名Sheet:{1}!", excelfile, excelreader.Name));
                                issuccess = false;
                                break;
                            }
                            else
                            {
                                var excelinfo = new ExcelInfo();
                                excelinfo.ExcelName = excelreader.Name;
                                int currentlinenumber = 1;
                                while (excelreader.Read())
                                {
                                    //读取每一行的数据
                                    string[] datas = new string[excelreader.FieldCount];
                                    for (int i = 0; i < excelreader.FieldCount; i++)
                                    {
                                        datas[i] = excelreader.GetString(i);
                                    }

                                    // 字段信息行
                                    if (currentlinenumber == ExcelDataConst.FieldNameLineNumber)
                                    {
                                        // 确保字段名不会因为错误的空格导致报错
                                        Utilities.TrimAllWhiteSpace(datas);
                                        excelinfo.FieldNames = datas;
                                    }
                                    // 字段注释信息行
                                    else if (currentlinenumber == ExcelDataConst.FieldNotationLineNumber)
                                    {
                                        excelinfo.FieldNotations = datas;
                                    }
                                    // 字段类型信息行
                                    else if (currentlinenumber == ExcelDataConst.FieldTypeLineNumber)
                                    {
                                        // 确保类型数据不会因为错误的空格导致报错
                                        Utilities.TrimAllWhiteSpace(datas);
                                        excelinfo.FieldTypes = datas;
                                    }
                                    // 字段分隔符信息行
                                    else if (currentlinenumber == ExcelDataConst.FieldSpliterLineNumber)
                                    {
                                        //excelinfo.FieldSpliters = datas;
                                    }
                                    // 字段占位符1信息行
                                    else if (currentlinenumber == ExcelDataConst.FieldPlaceHolder1LineNumber)
                                    {
                                        excelinfo.FieldPlaceholder1s = datas;
                                    }
                                    // 字段占位符2信息行
                                    else if (currentlinenumber == ExcelDataConst.FieldPlaceHolder2LineNumber)
                                    {
                                        excelinfo.FieldPlaceholder2s = datas;
                                    }
                                    else if (currentlinenumber >= ExcelDataConst.DataLineNumber)
                                    {
                                        // 存储数据之前，检查一次各字段名字，字段信息等配置是否正确
                                        if (currentlinenumber == ExcelDataConst.DataLineNumber)
                                        {
                                            if (HasInvalideName(excelinfo.FieldNames, excelinfo.FieldTypes))
                                            {
                                                Console.WriteLine(string.Format("Excel Table:{0}", excelreader.Name));
                                                issuccess = false;
                                                break;
                                            }
                                            if (HasInvalideType(excelinfo.FieldTypes))
                                            {
                                                Console.WriteLine(string.Format("Excel Table:{0}", excelreader.Name));
                                                issuccess = false;
                                                break;
                                            }
                                            //if (HasInvalideSpliter(excelinfo.FieldSpliters))
                                            //{
                                            //    Console.WriteLine(string.Format("Excel Table:{0}", excelreader.Name));
                                            //    issuccess = false;
                                            //    break;
                                            //}
                                        }

                                        // 记录每一行所有数据的字段名，字段类型，字段数据
                                        List<ExcelData> exceldatas = new List<ExcelData>();
                                        for (int m = 0; m < datas.Length; m++)
                                        {
                                            var fieldType = excelinfo.FieldTypes[m];
                                            // 注释类型不参与导出配置，不添加到数据成员里
                                            if(XbufferExcelUtilities.IsNotationType(fieldType))
                                            {
                                                continue;
                                            }
                                            ExcelData cd = new ExcelData();
                                            cd.Type = excelinfo.FieldTypes[m];
                                            cd.Name = excelinfo.FieldNames[m];
                                            //cd.Spliter = excelinfo.FieldSpliters[m];
                                            cd.Data = datas[m];
                                            exceldatas.Add(cd);
                                        }

                                        if (issuccess == false)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            excelinfo.AddData(exceldatas);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("无效的行号:{0}", currentlinenumber));
                                        issuccess = false;
                                        break;
                                    }
                                    currentlinenumber++;
                                }

                                // 检查是否有重复的id
                                if (!IsIdValide(excelinfo))
                                {
                                    Console.WriteLine($"Excel Sheet:{excelinfo.ExcelName}的配置有问题!");
                                    issuccess = false;
                                    break;
                                }

                                ExcelsInfoMap.Add(excelreader.Name, excelinfo);
                            }
                        }
                        excelreader.NextResult();
                    }
                }
            }

            if(!issuccess)
            {
                ClearExcelInfo();
                return false;
            }
            else
            {
#if DEBUG
                //打印表格数据信息
                //foreach(var excelinfo in ExcelsInfoMap)
                //{
                //    excelinfo.Value.printOutAllExcelInfo();
                //}
#endif
                return true;
            }
        }

        /// <summary>
        /// 是否是有效Sheet
        /// </summary>
        /// <param name="sheetname"></param>
        /// <returns></returns>
        private bool IsValideSheet(string sheetname)
        {
            return !sheetname.StartsWith(BLACK_LIST_PREFIX);
        }

        /// <summary>
        /// 指定sheet名是否存在(不区分大小写)
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        private bool HasSheetNameExist(string sheetName)
        {
            foreach(var excelInfo in ExcelsInfoMap)
            {
                if(excelInfo.Value.ExcelName.Equals(sheetName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查是否有重复的字段名
        /// 字段名不能是否有为空的(不含注释类型)
        /// 注释类型不允许填字段名
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        private bool HasInvalideName(string[] names, string[] types)
        {
            var length = names != null ? names.Length : 0;
            if(length == 0)
            {
                Console.WriteLine($"未配置有效字段和类型信息!");
                return true;
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        // 注释类型强制不允许配置字段名，注释类型不需要名字检查
                        bool isnotationtype = XbufferExcelUtilities.IsNotationType(types[i]);
                        if(isnotationtype)
                        {
                            if (!string.IsNullOrEmpty(names[i]))
                            {
                                Console.WriteLine(string.Format("配置错误 : 注释类型不允许填字段名，字段索引 : {0}!", i));
                                return true;
                            }
                            else
                            {
                                // 注释类型不参与后面的检查
                                continue;
                            }
                        }
                        else if (string.IsNullOrEmpty(names[i]))
                        {
                            Console.WriteLine(string.Format("配置错误 : 字段名不能为空，字段索引 : {0}!", i));
                            return true;
                        }
                        else if (names[i].Equals(names[j]))
                        {
                            Console.WriteLine(string.Format("配置错误 : 同名字段:{0}!", names[i]));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 是否有无效的类型配置且第一列必须是int或string类型(强制限制第一类数据类型，第一列用于填id)
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private bool HasInvalideType(string[] types)
        {
            for(int i = 0, length = types.Length; i < length; i++)
            {
                if(i == 0 && !IsValideIdType(types[i]))
                {
                    Console.WriteLine($"配置错误 : 第一列的数据类型:{types[i]}不支持");
                    return true;
                }
                else
                {
                    if (!IsValideType(types[i]))
                    {
                        Console.WriteLine(string.Format("配置错误 : 不支持的数据类型配置:{0}", types[i]));
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 是否有不被支持的分隔符配置
        /// </summary>
        /// <param name="spliters"></param>
        /// <returns></returns>
        //private bool HasInvalideSpliter(string[] spliters)
        //{
        //    foreach (var spliter in spliters)
        //    {
        //        if (spliter != null)
        //        {
        //            var allspliters = spliter.ToCharArray();
        //            // 只支持一个分隔符即一维数组配置
        //            if (allspliters.Length != 1)
        //            {
        //                Console.WriteLine("只支持最多一个的分隔符配置!");
        //                return true;
        //            }
        //            else
        //            {
        //                foreach (var sp in allspliters)
        //                {
        //                    if (!ValideSplitersList.Contains(sp))
        //                    {
        //                        Console.WriteLine(string.Format("配置错误 : 不支持的分隔符配置:{0}", sp));
        //                        Console.WriteLine(string.Format("支持的有效分隔符如下: {0}", ValideSplitersList.ToString()));
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Id是否有效
        /// </summary>
        private bool IsIdValide(ExcelInfo excelInfo)
        {
            var idType = excelInfo.GetIdType();
            if (!IsValideIdType(idType))
            {
                Console.WriteLine($"id类型:{idType}不支持,仅支持int和string!");
                return false;
            }
            if(HasDuplicatedId(excelInfo))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 指定的类型是否是有效id类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsValideIdType(string type)
        {
            return ValideIdTypeList.Contains(type);
        }

        /// <summary>
        /// 指定的类型是否是有效类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsValideType(string type)
        {
            if(IsValideNormalType(type))
            {
                return true;
            }
            if (IsValideOneArrayNormalType(type))
            {
                return true;
            }
            if (IsValideTwoArrayNormalType(type))
            {
                return true;
            }
            if (IsValideClassType(type))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 指定的类型是否是普通类型
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsValideNormalType(string type)
        {
            return ValideTypesList.Contains(type);
        }

        /// <summary>
        /// 指定的类型是否是一维普通类型数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsValideOneArrayNormalType(string type)
        {
            return ValideOneArrayTypesList.Contains(type);
        }

        /// <summary>
        /// 指定的类型是否是二维普通类型数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsValideTwoArrayNormalType(string type)
        {
            return ValideTwoArrayTypesList.Contains(type);
        }

        /// <summary>
        /// 是否是有效的嵌套Class类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsValideClassType(string type)
        {
            if(IsValideNormalClassType(type) || IsValideOneArrayClassType(type) || IsValideTwoArrayClassType(type))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 指定的类型是否是嵌套类型
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsValideNormalClassType(string type)
        {
            return type.StartsWith("{") && type.EndsWith("}");
        }

        /// <summary>
        /// 指定的类型是否是一维嵌套类型数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsValideOneArrayClassType(string type)
        {
            return type.StartsWith("{") && type.EndsWith("}[]");
        }

        /// <summary>
        /// 指定的类型是否是二维嵌套类型数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsValideTwoArrayClassType(string type)
        {
            return type.StartsWith("{") && type.EndsWith("}[][]");
        }

        /// <summary>
        /// 是否有重复的id
        /// </summary>
        /// <param name="excelinfo"></param>
        /// <returns></returns>
        private bool HasDuplicatedId(ExcelInfo excelinfo)
        {
            if(excelinfo != null)
            {
                mTempIdMap.Clear();
                foreach(var data in excelinfo.DatasList)
                {
                    if(mTempIdMap.ContainsKey(data[0].Data))
                    {
                        Console.WriteLine(string.Format("重复的id : {0}", data[0].Data));
                        return true;
                    }
                    else
                    {
                        mTempIdMap.Add(data[0].Data, data[0].Data);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 清除Excel信息
        /// </summary>
        private void ClearExcelInfo()
        {
            ExcelsInfoMap.Clear();
        }
    }
}
