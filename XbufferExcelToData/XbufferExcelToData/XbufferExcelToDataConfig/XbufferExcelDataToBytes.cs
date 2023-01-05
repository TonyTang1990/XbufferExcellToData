﻿/*
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
        public void configBytesOutputFolderPath(string folderpath)
        {
            BytesFolderPath = folderpath;
        }

        /// <summary>
        /// 将相关Excel数据写入到对应二进制文件
        /// </summary>
        /// <param name="excelinfo">excel数据信息</param>
        /// <returns></returns>
        public bool writeExcelDataToBytes(ExcelInfo excelinfo)
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
                    //接下来的写入格式: 每一行数据字节数长度 + 数据字节
                    for (int i = 0, length = exceldatalist.Count; i < length; i++)
                    {
                        //这里分配足够小，确保不会因为数据写入没有导致内存分配扩张导致wast计算不正确
                        XSteam stream = new XSteam(1, 32);
                        serializeExcelOneLineDatas(exceldatalist[i], stream);
                        var bytes = stream.getBytes();
                        // 写入单行数据长度信息
                        bw.Write(bytes.Length);
                        // 写入单行表格数据字节信息
                        bw.Write(bytes);
                        currentlinenmber = i;
                    }
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
            return true;
        }

        /// <summary>
        /// 序列化一行Excel数据信息
        /// </summary>
        /// <param name="exceldata"></param>
        private void serializeExcelOneLineDatas(ExcelData[] exceldata, XSteam stream)
        {
            // 先写入数据是否为空的bool信息
            serializeExcelData("bool", exceldata == null ? "true" : "false", stream);
            if(exceldata != null)
            {
                // 数据不为空才写入数据信息
                foreach (var data in exceldata)
                {
                    serializeExcelData(data.Type, data.Data, stream);
                }
            }
        }

        /// <summary>
        /// 序列化excel特定数据
        /// </summary>
        /// <param name="datatype">数据类型字符串</param>
        /// <param name="data">数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private bool serializeExcelData(string datatype, string data, XSteam stream)
        {
            switch (datatype)
            {
                case "notation":
                    //注释类型只用于表格查看，不作为实际的数据
                    //不需要进行序列化
                    break;
                case "int":
                    serializNoneArrayData<intBuffer>(data, stream);
                    break;
                case "float":
                    serializNoneArrayData<floatBuffer>(data, stream);
                    break;
                case "string":
                    serializNoneArrayData<stringBuffer>(data, stream);
                    break;
                case "long":
                    serializNoneArrayData<longBuffer>(data, stream);
                    break;
                case "bool":
                    serializNoneArrayData<boolBuffer>(data, stream);
                    break;
                case "byte":
                    serializNoneArrayData<byteBuffer>(data, stream);
                    break;
                case "int[]":
                    serializOneDimensionArrayData<intBuffer>(data, stream);
                    break;
                case "float[]":
                    serializOneDimensionArrayData<floatBuffer>(data, stream);
                    break;
                case "string[]":
                    serializOneDimensionArrayData<stringBuffer>(data, stream);
                    break;
                case "long[]":
                    serializOneDimensionArrayData<longBuffer>(data, stream);
                    break;
                case "bool[]":
                    serializOneDimensionArrayData<boolBuffer>(data, stream);
                    break;
                case "byte[]":
                    serializOneDimensionArrayData<byteBuffer>(data, stream);
                    break;
                case "int[][]":
                    serializTwoDimensionArrayData<intBuffer>(data, stream);
                    break;
                case "float[][]":
                    serializTwoDimensionArrayData<floatBuffer>(data, stream);
                    break;
                case "string[][]":
                    serializTwoDimensionArrayData<stringBuffer>(data, stream);
                    break;
                case "long[][]":
                    serializTwoDimensionArrayData<longBuffer>(data, stream);
                    break;
                case "bool[][]":
                    serializTwoDimensionArrayData<boolBuffer>(data, stream);
                    break;
                case "byte[][]":
                    serializTwoDimensionArrayData<byteBuffer>(data, stream);
                    break;
                default:
                    Console.WriteLine(string.Format("严重错误! 不支持的序列化数据类型 : {0}", datatype));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 序列化非数组类型数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private void serializNoneArrayData<T>(string data, XSteam stream)
        {
            var type = typeof(T);
            var serilizemethod = GetSerializeMethodInfoByType(type);
            if(serilizemethod != null)
            {
                // 填写数据之前需要解析数据到对应的类型
                // 支持不填数据采用默认数值的形式
                object finaldata = null;
                if (type == ExcelDataConst.INT_BUFFER_TYPE)
                {
                    if(string.IsNullOrEmpty(data))
                    {
                        finaldata = default(int);
                    }
                    else
                    {
                        int finalIntData;
                        if(!int.TryParse(data, out finalIntData))
                        {
                            finalIntData = default(int);
                            Console.WriteLine($"数据:{data} 类型:{type.Name} 配置数据格式有误,解析失败!");
                        }
                        finaldata = finalIntData;
                    }
                }
                else if(type == ExcelDataConst.FLOAT_BUFFER_TYPE)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = default(float);
                    }
                    else
                    {
                        float finaFloatData;
                        if (!float.TryParse(data, out finaFloatData))
                        {
                            finaFloatData = default(float);
                            Console.WriteLine($"数据:{data} 类型:{type.Name} 配置数据格式有误,解析失败!");
                        }
                        finaldata = finaFloatData;
                    }
                }
                else if (type == ExcelDataConst.STRING_BUFFER_TYPE)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = string.Empty;
                    }
                    else
                    {
                        finaldata = data;
                    }
                }
                else if (type == ExcelDataConst.LONG_BUFFER_TYPE)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = default(long);
                    }
                    else
                    {
                        long finaLongData;
                        if (!long.TryParse(data, out finaLongData))
                        {
                            finaLongData = default(long);
                            Console.WriteLine($"数据:{data} 类型:{type.Name} 配置数据格式有误,解析失败!");
                        }
                        finaldata = finaLongData;
                    }
                }
                else if (type == ExcelDataConst.BOOL_BUFFER_TYPE)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = default(bool);
                    }
                    else
                    {
                        bool finBoolData;
                        if (!bool.TryParse(data, out finBoolData))
                        {
                            finBoolData = default(bool);
                            Console.WriteLine($"数据:{data} 类型:{type.Name} 配置数据格式有误,解析失败!");
                        }
                        finaldata = finBoolData;
                    }
                }
                else if(type == ExcelDataConst.BYTE_BUFFER_TYPE)
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        finaldata = default(byte);
                    }
                    else
                    {
                        byte finByteData;
                        if (!byte.TryParse(data, out finByteData))
                        {
                            finByteData = default(byte);
                            Console.WriteLine($"数据:{data} 类型:{type.Name} 配置数据格式有误,解析失败!");
                        }
                        finaldata = finByteData;
                    }
                }
                serilizemethod.Invoke(null, new object[] { finaldata, stream });
            }
            else
            {
                Console.WriteLine(string.Format("没有找到类型T : {0}的serialize方法!", type.ToString()));
            }
        }

        /// <summary>
        /// 获取指定类型新的序列化方法信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private MethodInfo GetSerializeMethodInfoByType(Type type)
        {
            if(type == ExcelDataConst.INT_BUFFER_TYPE)
            {
                return ExcelDataConst.INT_BUFFER_SERIALIZE_METHOD;
            }
            else if (type == ExcelDataConst.FLOAT_BUFFER_TYPE)
            {
                return ExcelDataConst.FLOAT_BUFFER_SERIALIZE_METHOD;
            }
            else if (type == ExcelDataConst.STRING_BUFFER_TYPE)
            {
                return ExcelDataConst.STRING_BUFFER_SERIALIZE_METHOD;
            }
            else if (type == ExcelDataConst.LONG_BUFFER_TYPE)
            {
                return ExcelDataConst.LONG_BUFFER_SERIALIZE_METHOD;
            }
            else if (type == ExcelDataConst.BOOL_BUFFER_TYPE)
            {
                return ExcelDataConst.BOOL_BUFFER_SERIALIZE_METHOD;
            }
            else if (type == ExcelDataConst.BYTE_BUFFER_TYPE)
            {
                return ExcelDataConst.BYTE_BUFFER_SERIALIZE_METHOD;
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
        private void serializOneDimensionArrayData<T>(string data, XSteam stream)
        {
            if(string.IsNullOrEmpty(data))
            {
                // 未配置一维数据，默认长度默认为0
                serializNoneArrayData<intBuffer>("0", stream);
            }
            else
            {
                // 只支持1维数据的配置和快速解析
                var datas = data.Split(ExcelDataConst.ONE_DIMENSION_SPLITER);
                // 写入一维数组的长度字节数信息
                serializNoneArrayData<intBuffer>(datas.Length.ToString(), stream);

                // 开始序列化一维数组数据
                foreach (var dt in datas)
                {
                    serializNoneArrayData<T>(dt, stream);
                }
            }
        }

        /// <summary>
        /// 序列化二维数组类型数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="stream">Xbuffer的内存管理分配对象</param>
        private void serializTwoDimensionArrayData<T>(string data, XSteam stream)
        {
            if (string.IsNullOrEmpty(data))
            {
                // 未配置二维数据，默认长度默认为0
                serializNoneArrayData<intBuffer>("0", stream);
            }
            else
            {
                var twoDimensionDatas = data.Split(ExcelDataConst.TWO_DIMENSION_SPLITER);
                // 写入二维数组第一维度的长度字节数信息
                serializNoneArrayData<intBuffer>(twoDimensionDatas.Length.ToString(), stream);

                // 开始序列化第一维度数组数据
                foreach (var twoDimensionData in twoDimensionDatas)
                {
                    // 写入每一维度数据长度+每一维度的数据
                    var oneDimensionDatas = twoDimensionData.Split(ExcelDataConst.ONE_DIMENSION_SPLITER);
                    // 写入每一维度数组的长度字节数信息
                    serializNoneArrayData<intBuffer>(oneDimensionDatas.Length.ToString(), stream);
                    foreach(var oneDimensionData in oneDimensionDatas)
                    {
                        serializNoneArrayData<T>(oneDimensionData, stream);
                    }
                }
            }
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
        //private void dataSplit(char[] spliters, int spilterindex, int spliterlength, string data, List<string> finaldatalist)
        //{
        //    if(spilterindex < spliterlength)
        //    {
        //        var datas = data.Split(spliters[spilterindex]);
        //        spilterindex++;
        //        foreach (var dt in datas)
        //        {
        //            dataSplit(spliters, spilterindex, spliterlength, dt, finaldatalist);
        //        }
        //    }
        //    else
        //    {
        //        //切分到最小单位时添加数据
        //        finaldatalist.Add(data);
        //    }
        //}

        /// <summary>
        /// 获取序列化***Buffer对应的字符串默认值
        /// 比如:
        /// intBuffer对应int的默认值"0"
        /// stringBuffer对应string的string.Empty(string默认的default(string)值为null，这里不采用)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private string getBufferCorrespondingDV<T>()
        {
            var type = typeof(T);
            if (type == ExcelDataConst.INT_BUFFER_TYPE)
            {
                return ExcelDataConst.INT_BUFFER_DEFAULT_STRING_VALUE;
            }
            else if(type == ExcelDataConst.FLOAT_BUFFER_TYPE)
            {
                return ExcelDataConst.FLOAT_BUFFER_DEFAULT_STRING_VALUE;
            }
            else if (type == ExcelDataConst.STRING_BUFFER_TYPE)
            {
                return ExcelDataConst.STRING_BUFFER_DEFAULT_STRING_VALUE;
            }
            else if (type == ExcelDataConst.LONG_BUFFER_TYPE)
            {
                return ExcelDataConst.LONG_BUFFER_DEFAULT_STRING_VALUE;
            }
            else if (type == ExcelDataConst.BOOL_BUFFER_TYPE)
            {
                return ExcelDataConst.BOOL_BUFFER_DEFAULT_STRING_VALUE;
            }
            else if(type == ExcelDataConst.BYTE_BUFFER_TYPE)
            {
                return ExcelDataConst.BYTE_BUFFER_DEFAULT_STRING_VALUE;
            }
            else
            {
                Console.WriteLine(string.Format("不支持的数据类型 : {0}!无法正确的获取默认值!", typeof(T).ToString()));
                return string.Empty;
            }
        }
    }
}
