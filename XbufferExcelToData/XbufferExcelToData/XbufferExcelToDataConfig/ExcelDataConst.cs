/*
 * Description:             导表工具常量定义
 * Author:                  tanghuan
 * Create Date:             2022/12/28
 */

using System;
using System.Reflection;
using xbuffer;

namespace XbufferExcelToData
{
    /// <summary>
    /// 导表工具常量定义
    /// </summary>
    public static class ExcelDataConst
    {
        /// <summary>
        /// 字段名字行号
        /// </summary>
        public const int FieldNameLineNumber = 1;

        /// <summary>
        /// 字段注释行号
        /// </summary>
        public const int FieldNotationLineNumber = 2;

        /// <summary>
        /// 数据类型行号
        /// </summary>
        public const int FieldTypeLineNumber = 3;

        /// <summary>
        /// 分割信息(仅用于一维和多维数组数据)行号
        /// </summary>
        public const int FieldSpliterLineNumber = 4;

        /// <summary>
        /// 占位符1行号
        /// </summary>
        public const int FieldPlaceHolder1LineNumber = 5;

        /// <summary>
        /// 占位符2行号
        /// </summary>
        public const int FieldPlaceHolder2LineNumber = 6;

        /// <summary>
        /// 数据开始行号
        /// </summary>
        public const int DataLineNumber = 7;

        /// <summary>
        /// byteBuffer类型信息
        /// </summary>
        public static Type ByteBufferType = typeof(byteBuffer);

        /// <summary>
        /// intBuffer类型信息
        /// </summary>
        public static Type IntBufferType = typeof(intBuffer);

        /// <summary>
        /// longBuffer类型信息
        /// </summary>
        public static Type LongBufferType = typeof(longBuffer);

        /// <summary>
        /// floatBuffer类型信息
        /// </summary>
        public static Type FloatBufferType = typeof(floatBuffer);

        /// <summary>
        /// boolBuffer类型信息
        /// </summary>
        public static Type BoolBufferType = typeof(boolBuffer);

        /// <summary>
        /// stringBuffer类型信息
        /// </summary>
        public static Type StringBufferType = typeof(stringBuffer);

        /// <summary>
        /// byteBuffer serialize方法信息
        /// </summary>
        public static MethodInfo ByteBufferSerializeMethod = ByteBufferType.GetMethod("Serialize");

        /// <summary>
        /// intBuffer serialize方法信息
        /// </summary>
        public static MethodInfo IntBufferSerializeMethod = IntBufferType.GetMethod("Serialize");

        /// <summary>
        /// longBuffer serialize方法信息
        /// </summary>
        public static MethodInfo LongBufferSerializeMethod = LongBufferType.GetMethod("Serialize");

        /// <summary>
        /// floatBuffer serialize方法信息
        /// </summary>
        public static MethodInfo FloatBufferSerializeMethod = FloatBufferType.GetMethod("Serialize");
        
        /// <summary>
        /// boolBuffer serialize方法信息
        /// </summary>
        public static MethodInfo BoolBufferSerializeMethod = BoolBufferType.GetMethod("Serialize");

        /// <summary>
        /// stringBuffer serialize方法信息
        /// </summary>
        public static MethodInfo StringBufferSerializeMethod = StringBufferType.GetMethod("Serialize");

        /// <summary>
        /// byte默认值
        /// </summary>
        public const byte ByteDefaultValue = default(byte);

        /// <summary>
        /// int默认值
        /// </summary>
        public const int IntDefaultValue = default(int);

        /// <summary>
        /// long默认值
        /// </summary>
        public const long LongDefaultValue = default(long);

        /// <summary>
        /// float默认值
        /// </summary>
        public const float FloatDefaultValue = default(float);

        /// <summary>
        /// bool默认值
        /// </summary>
        public const bool BoolDefaultValue = default(bool);

        /// <summary>
        /// string默认值
        /// </summary>
        public const string StringDefaultValue = "";

        /// <summary>
        /// 一维数组分隔符
        /// </summary>
        public const char OneDimensionSpliter = '#';

        /// <summary>
        /// 二维数组分隔符
        /// </summary>
        public const char TwoDimensionSpliter = '|';

        /// <summary>
        /// 嵌套类型成员数据定义分隔符
        /// </summary>
        public const char ClassMemberValueSpliter = ';';

        /// <summary>
        /// 嵌套类型成员定义分隔符
        /// </summary>
        public const char ClassMemberSpliter = ';';

        /// <summary>
        /// 嵌套类型成员类型名字分隔符
        /// </summary>
        public const char ClassMemberTypeNameSpliter = ' ';

        /// <summary>
        /// 注释类型名
        /// </summary>
        public const string NotationTypeName = "notation";

        /// <summary>
        /// int类型名
        /// </summary>
        public const string IntTypeName = "int";

        /// <summary>
        /// float类型名
        /// </summary>
        public const string FloatTypeName = "float";

        /// <summary>
        /// String类型名
        /// </summary>
        public const string StringTypeName = "string";

        /// <summary>
        /// long类型名
        /// </summary>
        public const string LongTypeName = "long";

        /// <summary>
        /// bool类型名
        /// </summary>
        public const string BoolTypeName = "bool";

        /// <summary>
        /// byte类型名
        /// </summary>
        public const string ByteTypeName = "byte";
    }
}
