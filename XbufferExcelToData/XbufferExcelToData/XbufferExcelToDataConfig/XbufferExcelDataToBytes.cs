/*
 * Description:             自动化将Excel数据通过Xbuffer序列化到二进制数据的单例类
 * Author:                  tanghuan
 * Create Date:             2018/09/02
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using xbuffer;

namespace XbufferExcelToData
{
    /// <summary>
    /// 自动化将Excel数据通过Xbuffer序列化到二进制数据的单例类
    /// </summary>
    public class XbufferExcelDataToBytes : SingletonTemplate<XbufferExcelDataToBytes>
    {
        /// <summary>
        /// 二进制数据输出目录
        /// </summary>
        public string BytesFolderPath { get; private set; }

        public XbufferExcelDataToBytes()
        {
            BytesFolderPath = string.Empty;
        }

        /// <summary>
        /// 配置二进制数据输出目录
        /// </summary>
        /// <param name="folderpath"></param>
        public void ConfigBytesOutputFolderPath(string folderpath)
        {
            BytesFolderPath = folderpath;
        }

        /// <summary>
        /// 将相关Excel数据写入到对应二进制文件
        /// </summary>
        /// <param name="excelinfo">excel数据信息</param>
        /// <param name="excelClassData">Excel类型数据</param>
        /// <returns></returns>
        public bool WriteExcelDataToBytes(ExcelInfo excelinfo, ClassData excelClassData)
        {
            Console.WriteLine(string.Format("当前正在序列化表格 : {0}", excelinfo.ExcelName));
            // 因为考虑到Xbuffer的内存分配策略是递增的
            // 在不确Excel数据大小的情况下，默认分配不能过大，避免内存浪费
            var exceldatalist = excelinfo.DatasList;
            using (var output = File.Create(BytesFolderPath + excelinfo.ExcelName + ConstValue.ExcelBytesDataFilePostFix))
            {
                BinaryWriter bw = new BinaryWriter(output);
                // 写入表格数据行数字节信息
                var totallinenumber = exceldatalist.Count;
                bw.Write(totallinenumber);

                int currentlinenmber = 0;
                try
                {
                    var result = true;
                    //接下来的写入格式: 每一行数据字节数长度 + 数据字节
                    for (int i = 0, length = exceldatalist.Count; i < length; i++)
                    {
                        //这里分配足够小，确保不会因为数据写入没有导致内存分配扩张导致wast计算不正确
                        XSteam stream = new XSteam(1, 32);
                        if(!SerializeExcelOneLineDatas(exceldatalist[i], excelClassData, stream))
                        {
                            var lineNum = i + ExcelDataConst.DataLineNumber;
                            Console.WriteLine($"序列化配置表:{excelinfo.ExcelName}第{lineNum}行数据出错！");
                            result = false;
                            break;
                        }
                        var bytes = stream.getBytes();
                        // 写入单行数据长度信息
                        bw.Write(bytes.Length);
                        // 写入单行表格数据字节信息
                        bw.Write(bytes);
                        currentlinenmber = i;
                    }
                    return result;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(string.Format("异常 : {0}", e.ToString()));
                    Console.WriteLine(string.Format("当前序列化的行号 : {0}", currentlinenmber));
                    return false;
                }
                finally
                {
                    bw.Flush();
                    bw.Close();
                }
            }
        }

        /// <summary>
        /// 序列化一行Excel数据信息
        /// </summary>
        /// <param name="excelData">Excel当行数据数组</param>
        /// <param name="excelClassData">Excel类型数据</param>
        /// <param name="stream">Excel二进制写入流</param>
        private bool SerializeExcelOneLineDatas(ExcelData[] excelData, ClassData excelClassData, XSteam stream)
        {
            // 先写入数据是否为空的bool信息
            SerializNoneArrayData<boolBuffer>(excelData == null ? "true" : "false", stream);
            if(excelData != null)
            {
                var memberDataList = excelClassData.MemberDataList;
                // 数据不为空才写入数据信息
                for (int index = 0, length = excelData.Length; index < length; index++)
                {
                    var data = excelData[index];
                    // 理论上数据结构和数据数量一致一一对应
                    var memberData = memberDataList[index];
                    if(!SerializeExcelData(memberData, data.Data, stream))
                    {
                        Console.WriteLine($"字段名:{data.Name}数据:{data.Data}配置有误，序列化失败！");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 序列化excel特定数据
        /// </summary>
        /// <param name="memberData">Excel成员数据</param>
        /// <param name="dataTypeDes">数据类型字符串</param>
        /// <param name="data">数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializeExcelData(MemberData memberData, string data, XSteam stream)
        {
            if(memberData.ExcelDataType == ExcelDataType.BASIC)
            {
                return SerializeBasicExcelData(memberData.BasicDataType, data, stream);
            }
            else if (memberData.ExcelDataType == ExcelDataType.BASIC_ONE_ARRAY)
            {
                return SerializeBasicOneArrayExcelData(memberData.BasicDataType, data, stream);
            }
            else if (memberData.ExcelDataType == ExcelDataType.BASIC_TWO_ARRAY)
            {
                return SerializeBasicTwoArrayExcelData(memberData.BasicDataType, data, stream);
            }
            else if (memberData.ExcelDataType == ExcelDataType.CLASS)
            {
                return SerializeClassExcelData(memberData.MemberClassData, data, stream);
            }
            else if (memberData.ExcelDataType == ExcelDataType.CLASS_ONE_ARRAY)
            {
                return SerializeClassOneArrayExcelData(memberData.MemberClassData, data, stream);
            }
            else if (memberData.ExcelDataType == ExcelDataType.CLASS_TWO_ARRAY)
            {
                return SerializeClassTwoArrayExcelData(memberData.MemberClassData, data, stream);
            }
            else
            {
                Console.WriteLine($"不支持的Excel数据类型:{memberData.ExcelDataType},序列化数据失败！");
                return false;
            }
        }

        /// <summary>
        /// 序列化普通数据类型Excel数据
        /// </summary>
        /// <param name="basicDataType"></param>
        /// <param name="data"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        private bool SerializeBasicExcelData(string basicDataType, string data, XSteam stream)
        {
            //注释类型只用于表格查看，不作为实际的数据
            //不需要进行序列化
            if (XbufferExcelUtilities.IsAnotationType(basicDataType))
            {
                return false;
            }
            switch (basicDataType)
            {
                case ExcelDataConst.IntTypeName:
                    return SerializNoneArrayData<intBuffer>(data, stream);
                case ExcelDataConst.FloatTypeName:
                    return SerializNoneArrayData<floatBuffer>(data, stream);
                case ExcelDataConst.StringTypeName:
                    return SerializNoneArrayData<stringBuffer>(data, stream);
                case ExcelDataConst.LongTypeName:
                    return SerializNoneArrayData<longBuffer>(data, stream);
                case ExcelDataConst.BoolTypeName:
                    return SerializNoneArrayData<boolBuffer>(data, stream);
                case ExcelDataConst.ByteTypeName:
                    return SerializNoneArrayData<byteBuffer>(data, stream);
                default:
                    Console.WriteLine(string.Format("严重错误! 不支持的序列化基础数据类型 : {0}", basicDataType));
                    return false;
            }
        }

        /// <summary>
        /// 序列化普通一维数组数据类型Excel数据
        /// </summary>
        /// <param name="basicDataType">基础数据类型字符串</param>
        /// <param name="excelData">Excel配置数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        /// <returns></returns>
        private bool SerializeBasicOneArrayExcelData(string basicDataType, string excelData, XSteam stream)
        {
            //注释类型只用于表格查看，不作为实际的数据
            //不需要进行序列化
            if (XbufferExcelUtilities.IsAnotationType(basicDataType))
            {
                return false;
            }
            switch (basicDataType)
            {
                case ExcelDataConst.IntTypeName:
                    return SerializOneDimensionArrayData<intBuffer>(excelData, stream);
                case ExcelDataConst.FloatTypeName:
                    return SerializOneDimensionArrayData<floatBuffer>(excelData, stream);
                case ExcelDataConst.StringTypeName:
                    return SerializOneDimensionArrayData<stringBuffer>(excelData, stream);
                case ExcelDataConst.LongTypeName:
                    return SerializOneDimensionArrayData<longBuffer>(excelData, stream);
                case ExcelDataConst.BoolTypeName:
                    return SerializOneDimensionArrayData<boolBuffer>(excelData, stream);
                case ExcelDataConst.ByteTypeName:
                    return SerializOneDimensionArrayData<byteBuffer>(excelData, stream);
                default:
                    Console.WriteLine(string.Format("严重错误! 不支持的序列化一维数组数据类型 : {0}", basicDataType));
                    return false;
            }
        }

        /// <summary>
        /// 序列化普通二维数组数据类型Excel数据
        /// </summary>
        /// <param name="basicDataType">基础数据类型字符串</param>
        /// <param name="excelData">Excel配置数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        /// <returns></returns>
        private bool SerializeBasicTwoArrayExcelData(string basicDataType, string excelData, XSteam stream)
        {
            //注释类型只用于表格查看，不作为实际的数据
            //不需要进行序列化
            if (XbufferExcelUtilities.IsAnotationType(basicDataType))
            {
                return false;
            }
            switch (basicDataType)
            {
                case ExcelDataConst.IntTypeName:
                    return SerializTwoDimensionArrayData<intBuffer>(excelData, stream);
                case ExcelDataConst.FloatTypeName:
                    return SerializTwoDimensionArrayData<floatBuffer>(excelData, stream);
                case ExcelDataConst.StringTypeName:
                    return SerializTwoDimensionArrayData<stringBuffer>(excelData, stream);
                case ExcelDataConst.LongTypeName:
                    return SerializTwoDimensionArrayData<longBuffer>(excelData, stream);
                case ExcelDataConst.BoolTypeName:
                    return SerializTwoDimensionArrayData<boolBuffer>(excelData, stream);
                case ExcelDataConst.ByteTypeName:
                    return SerializTwoDimensionArrayData<byteBuffer>(excelData, stream);
                default:
                    Console.WriteLine(string.Format("严重错误! 不支持的序列化二维数组数据类型 : {0}", basicDataType));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 序列化Class结构数据类型Excel数据
        /// </summary>
        /// <param name="classData">Class结构数据</param>
        /// <param name="excelData">Excel配置数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializeClassExcelData(ClassData classData, string excelData, XSteam stream)
        {
            if(classData == null)
            {
                Console.WriteLine($"沒传递有效的Class结构数据，序列化Class结构数据失败！");
                return false;
            }
            // 先写入数据是否为空的bool信息
            SerializNoneArrayData<boolBuffer>(string.IsNullOrEmpty(excelData) ? "true" : "false", stream);

            var memberDataList = classData.MemberDataList;
            var datas = excelData.Split(ExcelDataConst.ClassMemberValueSpliter);
            for(int index = 0, length = datas.Length; index < length; index++)
            {
                var memberData = memberDataList[index];
                //注释类型只用于表格查看，不作为实际的数据
                //不需要进行序列化
                if (XbufferExcelUtilities.IsAnotationType(memberData.BasicDataType))
                {
                    continue;
                }
                var data = datas[index];
                if(!SerializeBasicExcelData(memberData.BasicDataType, data, stream))
                {
                    Console.WriteLine($"Class Name:{classData.ClassName}的成员:{memberData.Name}数据:{data}配置有误，解析失败！");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 序列化Class结构一维数组数据类型Excel数据
        /// </summary>
        /// <param name="classData">Class结构数据</param>
        /// <param name="excelData">Excel数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializeClassOneArrayExcelData(ClassData classData, string excelData, XSteam stream)
        {
            if (classData == null)
            {
                Console.WriteLine($"沒传递有效的Class结构数据，序列化Class结构一维数组数据失败！");
                return false;
            }
            if (string.IsNullOrEmpty(excelData))
            {
                // 未配置一维数据，默认长度默认为0
                SerializNoneArrayData<intBuffer>("0", stream);
            }
            else
            {
                // 只支持1维数据的配置和快速解析
                var datas = excelData.Split(ExcelDataConst.OneDimensionSpliter);
                // 写入一维数组的长度字节数信息
                SerializNoneArrayData<intBuffer>(datas.Length.ToString(), stream);
                // 开始序列化一维数组数据
                for(int index = 0, length = datas.Length; index < length; index++)
                {
                    var data = datas[index];
                    if(!SerializeClassExcelData(classData, data, stream))
                    {
                        Console.WriteLine($"Class Name:{classData.ClassName}的第[{index}]数据:{data}配置有误，解析失败！");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 序列化Class结构二维数组数据类型Excel数据
        /// </summary>
        /// <param name="classData">Class结构数据</param>
        /// <param name="excelDdata">Excel数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializeClassTwoArrayExcelData(ClassData classData, string excelDdata, XSteam stream)
        {
            if (classData == null)
            {
                Console.WriteLine($"沒传递有效的Class结构数据，序列化Class结构二维数组数据失败！");
                return false;
            }
            if (string.IsNullOrEmpty(excelDdata))
            {
                // 未配置二维数据，默认长度默认为0
                SerializNoneArrayData<intBuffer>("0", stream);
            }
            else
            {
                var twoDimensionDatas = excelDdata.Split(ExcelDataConst.TwoDimensionSpliter);
                // 写入二维数组第一维度的长度字节数信息
                SerializNoneArrayData<intBuffer>(twoDimensionDatas.Length.ToString(), stream);

                // 开始序列化第一维度数组数据
                for(int index1 = 0, length1 = twoDimensionDatas.Length; index1 < length1; index1++)
                {
                    var twoDimensionData = twoDimensionDatas[index1];
                    // 写入每一维度数据长度+每一维度的数据
                    var oneDimensionDatas = twoDimensionData.Split(ExcelDataConst.OneDimensionSpliter);
                    // 写入每一维度数组的长度字节数信息
                    SerializNoneArrayData<intBuffer>(oneDimensionDatas.Length.ToString(), stream);
                    // 序列化Class数据
                    for(int index2 = 0, length2 = oneDimensionDatas.Length; index2 < length2; index2++)
                    {
                        var oneDimensionData = oneDimensionDatas[index2];
                        if (!SerializeClassExcelData(classData, oneDimensionData, stream))
                        {
                            Console.WriteLine($"Class Name:{classData.ClassName}的第[{index1}][{index2}]数据:{oneDimensionData}配置有误，解析失败！");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 序列化非数组类型数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializNoneArrayData<T>(string data, XSteam stream)
        {
            var result = true;
            var type = typeof(T);
            var serilizemethod = GetSerializeMethodInfoByType(type);
            if(serilizemethod != null)
            {
                // 填写数据之前需要解析数据到对应的类型
                // 支持不填数据采用默认数值的形式
                object finaldata = null;
                if (type == ExcelDataConst.IntBufferType)
                {
                    if(string.IsNullOrEmpty(data))
                    {
                        finaldata = ExcelDataConst.IntDefaultValue;
                    }
                    else
                    {
                        int finalIntData;
                        if(!int.TryParse(data, out finalIntData))
                        {
                            finalIntData = ExcelDataConst.IntDefaultValue;
                            Console.WriteLine($"配置类型:{ExcelDataConst.IntTypeName}的数据:{data}配置数据格式有误,解析失败!");
                            result = false;
                        }
                        finaldata = finalIntData;
                    }
                }
                else if(type == ExcelDataConst.FloatBufferType)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = ExcelDataConst.FloatDefaultValue;
                    }
                    else
                    {
                        float finaFloatData;
                        if (!float.TryParse(data, out finaFloatData))
                        {
                            finaFloatData = ExcelDataConst.FloatDefaultValue;
                            Console.WriteLine($"配置类型:{ExcelDataConst.FloatTypeName}的数据:{data}配置数据格式有误,解析失败!");
                            result = false;
                        }
                        finaldata = finaFloatData;
                    }
                }
                else if (type == ExcelDataConst.StringBufferType)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = ExcelDataConst.StringDefaultValue;
                    }
                    else
                    {
                        finaldata = data;
                    }
                }
                else if (type == ExcelDataConst.LongBufferType)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = ExcelDataConst.LongDefaultValue;
                    }
                    else
                    {
                        long finaLongData;
                        if (!long.TryParse(data, out finaLongData))
                        {
                            finaLongData = ExcelDataConst.LongDefaultValue;
                            Console.WriteLine($"配置类型:{ExcelDataConst.LongTypeName}的数据:{data}配置数据格式有误,解析失败!");
                            result = false;
                        }
                        finaldata = finaLongData;
                    }
                }
                else if (type == ExcelDataConst.BoolBufferType)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = ExcelDataConst.BoolDefaultValue;
                    }
                    else
                    {
                        bool finBoolData;
                        if (!bool.TryParse(data, out finBoolData))
                        {
                            finBoolData = ExcelDataConst.BoolDefaultValue;
                            Console.WriteLine($"配置类型:{ExcelDataConst.BoolTypeName}的数据:{data}配置数据格式有误,解析失败!");
                            result = false;
                        }
                        finaldata = finBoolData;
                    }
                }
                else if(type == ExcelDataConst.ByteBufferType)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = ExcelDataConst.ByteDefaultValue;
                    }
                    else
                    {
                        byte finByteData;
                        if (!byte.TryParse(data, out finByteData))
                        {
                            finByteData = ExcelDataConst.ByteDefaultValue;
                            Console.WriteLine($"配置类型:{ExcelDataConst.ByteTypeName}的数据:{data}配置数据格式有误,解析失败!");
                            result = false;
                        }
                        finaldata = finByteData;
                    }
                }
                serilizemethod.Invoke(null, new object[] { finaldata, stream });
            }
            else
            {
                Console.WriteLine(string.Format("没有找到类型T : {0}的serialize方法，序列化数据失败!", type.ToString()));
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 获取指定类型新的序列化方法信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private MethodInfo GetSerializeMethodInfoByType(Type type)
        {
            if(type == ExcelDataConst.IntBufferType)
            {
                return ExcelDataConst.IntBufferSerializeMethod;
            }
            else if (type == ExcelDataConst.FloatBufferType)
            {
                return ExcelDataConst.FloatBufferSerializeMethod;
            }
            else if (type == ExcelDataConst.StringBufferType)
            {
                return ExcelDataConst.StringBufferSerializeMethod;
            }
            else if (type == ExcelDataConst.LongBufferType)
            {
                return ExcelDataConst.LongBufferSerializeMethod;
            }
            else if (type == ExcelDataConst.BoolBufferType)
            {
                return ExcelDataConst.BoolBufferSerializeMethod;
            }
            else if (type == ExcelDataConst.ByteBufferType)
            {
                return ExcelDataConst.ByteBufferSerializeMethod;
            }
            else
            {
                Console.WriteLine(string.Format("找不到类型T : {0}的serialize方法!", type.ToString())); 
                return null;
            }
        }

        /// <summary>
        /// 序列化一维数组类型数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="spilter">分隔符</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializOneDimensionArrayData<T>(string data, XSteam stream)
        {
            if(string.IsNullOrEmpty(data))
            {
                // 未配置一维数据，默认长度默认为0
                SerializNoneArrayData<intBuffer>("0", stream);
            }
            else
            {
                // 只支持1维数据的配置和快速解析
                var datas = data.Split(ExcelDataConst.OneDimensionSpliter);
                // 写入一维数组的长度字节数信息
                SerializNoneArrayData<intBuffer>(datas.Length.ToString(), stream);

                // 开始序列化一维数组数据
                for(int index = 0, length = datas.Length; index < length; index++)
                {
                    var dt = datas[index];
                    if(!SerializNoneArrayData<T>(dt, stream))
                    {
                        Console.WriteLine($"一维数组[{index}]数据:{data}配置有误，解析失败！");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 序列化二维数组类型数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool SerializTwoDimensionArrayData<T>(string data, XSteam stream)
        {
            if (string.IsNullOrEmpty(data))
            {
                // 未配置二维数据，默认长度默认为0
                SerializNoneArrayData<intBuffer>("0", stream);
            }
            else
            {
                var twoDimensionDatas = data.Split(ExcelDataConst.TwoDimensionSpliter);
                // 写入二维数组第一维度的长度字节数信息
                SerializNoneArrayData<intBuffer>(twoDimensionDatas.Length.ToString(), stream);

                // 开始序列化第一维度数组数据
                for(int index1 = 0, length1 = twoDimensionDatas.Length; index1 < length1; index1++)
                {
                    var twoDimensionData = twoDimensionDatas[index1];
                    // 写入每一维度数据长度+每一维度的数据
                    var oneDimensionDatas = twoDimensionData.Split(ExcelDataConst.OneDimensionSpliter);
                    // 写入每一维度数组的长度字节数信息
                    SerializNoneArrayData<intBuffer>(oneDimensionDatas.Length.ToString(), stream);
                    for(int index2 = 0, length2 = oneDimensionDatas.Length; index2 < length2; index2++)
                    {
                        var oneDimensionData = oneDimensionDatas[index2];
                        if (!SerializNoneArrayData<T>(oneDimensionData, stream))
                        {
                            Console.WriteLine($"二维数组[{index1}][{index2}]数据:{data}配置有误，解析失败！");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 数据分割(递归调用，用于获取所有数据分割后的数据)
        /// Note:
        /// 因为最终放弃了多维数组的支持，这里不再需要
        /// </summary>
        /// <param name="spliters">分隔符信息</param>
        /// <param name="spilterindex">当前分隔符索引</param>
        /// <param name="spliterlength">分隔符总长度</param>
        /// <param name="data">数据</param>
        /// <param name="finaldatalist">最终所有数组分割存储在一个扁平化的列表里</param>
        /// <returns></returns>
        //private void DataSplit(char[] spliters, int spilterindex, int spliterlength, string data, List<string> finaldatalist)
        //{
        //    if(spilterindex < spliterlength)
        //    {
        //        var datas = data.Split(spliters[spilterindex]);
        //        spilterindex++;
        //        foreach (var dt in datas)
        //        {
        //            DataSplit(spliters, spilterindex, spliterlength, dt, finaldatalist);
        //        }
        //    }
        //    else
        //    {
        //        //切分到最小单位时添加数据
        //        finaldatalist.Add(data);
        //    }
        //}
    }
}
