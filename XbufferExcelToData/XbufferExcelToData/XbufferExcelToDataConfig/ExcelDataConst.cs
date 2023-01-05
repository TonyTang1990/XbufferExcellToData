/*
 * Description:             导表工具常量定义
 * Author:                  tanghuan
 * Create Date:             2022/12/28
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using xbuffer;

namespace XbufferExcelToData
{
    /// <summary>
    /// 导表工具常量定义
    /// </summary>
    public static class ExcelDataConst
    {
        /// <summary>
        /// byteBuffer类型信息
        /// </summary>
        public static Type BYTE_BUFFER_TYPE = typeof(byteBuffer);

        /// <summary>
        /// intBuffer类型信息
        /// </summary>
        public static Type INT_BUFFER_TYPE = typeof(intBuffer);

        /// <summary>
        /// longBuffer类型信息
        /// </summary>
        public static Type LONG_BUFFER_TYPE = typeof(longBuffer);

        /// <summary>
        /// floatBuffer类型信息
        /// </summary>
        public static Type FLOAT_BUFFER_TYPE = typeof(floatBuffer);

        /// <summary>
        /// boolBuffer类型信息
        /// </summary>
        public static Type BOOL_BUFFER_TYPE = typeof(boolBuffer);

        /// <summary>
        /// stringBuffer类型信息
        /// </summary>
        public static Type STRING_BUFFER_TYPE = typeof(stringBuffer);

        /// <summary>
        /// byteBuffer serialize方法信息
        /// </summary>
        public static MethodInfo BYTE_BUFFER_SERIALIZE_METHOD = BYTE_BUFFER_TYPE.GetMethod("serialize");

        /// <summary>
        /// intBuffer serialize方法信息
        /// </summary>
        public static MethodInfo INT_BUFFER_SERIALIZE_METHOD = INT_BUFFER_TYPE.GetMethod("serialize");

        /// <summary>
        /// longBuffer serialize方法信息
        /// </summary>
        public static MethodInfo LONG_BUFFER_SERIALIZE_METHOD = LONG_BUFFER_TYPE.GetMethod("serialize");

        /// <summary>
        /// floatBuffer serialize方法信息
        /// </summary>
        public static MethodInfo FLOAT_BUFFER_SERIALIZE_METHOD = FLOAT_BUFFER_TYPE.GetMethod("serialize");
        
        /// <summary>
        /// boolBuffer serialize方法信息
        /// </summary>
        public static MethodInfo BOOL_BUFFER_SERIALIZE_METHOD = BOOL_BUFFER_TYPE.GetMethod("serialize");

        /// <summary>
        /// stringBuffer serialize方法信息
        /// </summary>
        public static MethodInfo STRING_BUFFER_SERIALIZE_METHOD = STRING_BUFFER_TYPE.GetMethod("serialize");

        /// <summary>
        /// byteBuffer默认指字符串
        /// </summary>
        public static string BYTE_BUFFER_DEFAULT_STRING_VALUE = default(byte).ToString();

        /// <summary>
        /// intBuffer默认指字符串
        /// </summary>
        public static string INT_BUFFER_DEFAULT_STRING_VALUE = default(int).ToString();

        /// <summary>
        /// longBuffer默认指字符串
        /// </summary>
        public static string LONG_BUFFER_DEFAULT_STRING_VALUE = default(long).ToString();

        /// <summary>
        /// floatBuffer默认指字符串
        /// </summary>
        public static string FLOAT_BUFFER_DEFAULT_STRING_VALUE = default(float).ToString();

        /// <summary>
        /// boolBuffer默认指字符串
        /// </summary>
        public static string BOOL_BUFFER_DEFAULT_STRING_VALUE = default(bool).ToString();

        /// <summary>
        /// stringBuffer默认指字符串
        /// </summary>
        public static string STRING_BUFFER_DEFAULT_STRING_VALUE = string.Empty;

        /// <summary>
        /// 一维数组分隔符
        /// </summary>
        public const char ONE_DIMENSION_SPLITER = '#';

        /// <summary>
        /// 二维数组分隔符
        /// </summary>
        public const char TWO_DIMENSION_SPLITER = '|';
    }
}
