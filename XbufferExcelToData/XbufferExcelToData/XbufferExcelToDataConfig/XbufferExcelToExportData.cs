/*
 * Description:             自动化分析配置表数据到导出数据
 * Author:                  tanghuan
 * Create Date:             2023/08/16
 */

using System;
using System.Collections.Generic;

namespace XbufferExcelToData
{
    /// <summary>
    /// 类型结构数据抽象
    /// </summary>
    public class ClassData
    {
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName
        {
            get;
            private set;
        }

        /// <summary>
        /// 注释
        /// </summary>
        public string Comment
        {
            get;
            private set;
        }

        /// <summary>
        /// 成员数据列表
        /// </summary>
        public List<MemberData> MemberDataList
        {
            get;
            private set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="className"></param>
        /// <param name="comment"></param>
        public ClassData(string className, string comment = "")
        {
            ClassName = className;
            Comment = comment;
            MemberDataList = new List<MemberData>();
        }

        /// <summary>
        /// 添加成员数据
        /// </summary>
        /// <param name="memberData"></param>
        /// <returns></returns>
        public bool AddMemberData(MemberData memberData)
        {
            if (MemberDataList.Contains(memberData))
            {
                Console.WriteLine($"重复添加成员数据:{memberData.ToString()}，添加成员失败！");
                return false;
            }
            MemberDataList.Add(memberData);
            return true;
        }

        /// <summary>
        /// 删除指定成员数据
        /// </summary>
        /// <param name="memberData"></param>
        /// <returns></returns>
        public bool RemoveMemberData(MemberData memberData)
        {
            return MemberDataList.Remove(memberData);
        }

        /// <summary>
        /// 是否是有效Class数据
        /// </summary>
        /// <returns></returns>
        public bool IsValide()
        {
            if(string.IsNullOrEmpty(ClassName))
            {
                Console.WriteLine($"不允许构建空类名的Class数据！");
                return false;
            }
            foreach(var memberData in MemberDataList)
            {
                if(!memberData.IsValide())
                {
                    Console.WriteLine($"类名:{ClassName}有无效成员数据:{memberData.Name}！");
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 成员结构数据抽象
    /// </summary>
    public class MemberData
    {
        /// <summary>
        /// 所属类型结构数据
        /// </summary>
        public ClassData OwnerClassData
        {
            get;
            private set;
        }

        /// <summary>
        /// 成员名
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据类型描述
        /// </summary>
        public string DataTypeDes
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType
        {
            get;
            private set;
        }

        /// <summary>
        /// 最基础数据类型(剔除一维和二维数据概念后的基础数据类型)
        /// </summary>
        public string BasicDataType
        {
            get;
            private set;
        }

        /// <summary>
        /// 注释
        /// </summary>
        public string Comment
        {
            get;
            private set;
        }

        /// <summary>
        /// Excel数据类型
        /// </summary>
        public ExcelDataType ExcelDataType
        {
            get;
            private set;
        }

        /// <summary>
        /// 成员类型数据(仅当数据类型DataType为Class时有效)
        /// </summary>
        public ClassData MemberClassData
        {
            get;
            private set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="classData"></param>
        /// <param name="name"></param>
        /// <param name="dataTypeDes"></param>
        /// <param name="comment"></param>
        public MemberData(ClassData classData, string name, string dataTypeDes, string comment = "")
        {
            OwnerClassData = classData;
            Name = name;
            DataTypeDes = dataTypeDes;
            DataType = dataTypeDes;
            BasicDataType = dataTypeDes;
            Comment = comment;
            ExcelDataType = XbufferExcelUtilities.GetExcelDataType(dataTypeDes);
            if (ExcelDataType == ExcelDataType.BASIC_ONE_ARRAY)
            {
                var lastBracketIndex = BasicDataType.LastIndexOf("[]");
                BasicDataType = BasicDataType.Remove(lastBracketIndex);
            }
            else if (ExcelDataType == ExcelDataType.BASIC_TWO_ARRAY)
            {
                var lastBracketIndex = BasicDataType.LastIndexOf("[][]");
                BasicDataType = BasicDataType.Remove(lastBracketIndex);
            }
            if (XbufferExcelUtilities.IsClassExcelDataType(ExcelDataType))
            {
                var className = XbufferExcelUtilities.GetExcelMemberClassName(classData.ClassName, Name);
                var classComment = Comment;
                MemberClassData = XbufferExcelUtilities.ParseDataTypeToClassData(DataTypeDes, className, classComment);
                DataType = className;
                BasicDataType = className;
                if (ExcelDataType == ExcelDataType.CLASS_ONE_ARRAY)
                {
                    DataType = $"{DataType}[]";
                }
                else if(ExcelDataType == ExcelDataType.CLASS_TWO_ARRAY)
                {
                    DataType = $"{DataType}[][]";
                }
            }
        }

        /// <summary>
        /// 是否是有效成员数据
        /// </summary>
        /// <returns></returns>
        public bool IsValide()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Console.WriteLine($"Sheet:{OwnerClassData.ClassName}不允许配置空字段名成员数据！");
                return false;
            }
            if (string.IsNullOrEmpty(DataTypeDes))
            {
                Console.WriteLine($"Sheet:{OwnerClassData.ClassName},字段:{Name}不允许配置空字段类型数据！");
                return false;
            }
            if (XbufferExcelUtilities.IsClassExcelDataType(ExcelDataType) && (MemberClassData == null || !MemberClassData.IsValide()))
            {
                Console.WriteLine($"Sheet:{OwnerClassData.ClassName}的成员数据有无效数据！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取字符串描述
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name:{Name};DataType:{DataTypeDes};ExcelDataType:{ExcelDataType};Comment:{Comment}";
        }
    }

    /// <summary>
    /// 自动化分析配置表数据到导出数据
    /// </summary>
    public class XbufferExcelToExportData : SingletonTemplate<XbufferExcelToExportData>
    {
        /// <summary>
        /// Excel类型数据Map<sheet名, sheet类型数据>
        /// </summary>
        public Dictionary<string, ClassData> ExcelClassDataMap
        {
            get;
            private set;
        }

        public XbufferExcelToExportData()
        {
            ExcelClassDataMap = new Dictionary<string, ClassData>();
        }

        /// <summary>
        /// 清除所有Excel类型数据
        /// </summary>
        public void ClearAllExcelClassData()
        {
            ExcelClassDataMap.Clear();
        }

        /// <summary>
        /// 解析Excel数据信息Map
        /// </summary>
        /// <param name="excelsInfoMap"></param>
        public bool ParseExcelInfoMap(Dictionary<string, ExcelInfo> excelsInfoMap)
        {
            foreach(var excelsInfoData in excelsInfoMap)
            {
                if(!ParseExcelInfo(excelsInfoData.Value))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 解析单个Excel数据信息
        /// </summary>
        /// <param name="excelInfo"></param>
        public bool ParseExcelInfo(ExcelInfo excelInfo)
        {
            if(IsContainSheetClassData(excelInfo.ExcelName))
            {
                Console.WriteLine($"重复解析Sheet:{excelInfo.ExcelName}的Excel数据信息，解析失败！");
                return false;
            }
            var classData = XbufferExcelUtilities.ParseExcelInfoToClassData(excelInfo);
            AddClassData(excelInfo.ExcelName, classData);
            return classData.IsValide();
        }

        /// <summary>
        /// 添加指定Sheet名的Excel类型数据
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="classData"></param>
        /// <returns></returns>
        public bool AddClassData(string sheetName, ClassData classData)
        {
            if(classData == null)
            {
                Console.WriteLine($"Sheet:{sheetName}不支持添加空Excel数据信息，添加Excel类型数据失败！");
                return false;
            }
            if(IsContainSheetClassData(sheetName))
            {
                Console.WriteLine($"重复添加Sheet:{sheetName}的Excel数据信息，添加Excel类型数据失败！");
                return false;
            }
            ExcelClassDataMap.Add(sheetName, classData);
            return true;
        }

        /// <summary>
        /// 获取指定Sheet名的Excel类型抽象数据
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public ClassData GetExcelClassDataBySheetName(string sheetName)
        {
            ClassData classData;
            if(!ExcelClassDataMap.TryGetValue(sheetName, out classData))
            {
                Console.WriteLine($"找不到Sheet:{sheetName}的Excel类型抽象数据！");
                return null;
            }
            return classData;
        }

        /// <summary>
        /// 是否包含指定Sheet名的Excel类型数据
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool IsContainSheetClassData(string sheetName)
        {
            return ExcelClassDataMap.ContainsKey(sheetName);
        }
    }
}
