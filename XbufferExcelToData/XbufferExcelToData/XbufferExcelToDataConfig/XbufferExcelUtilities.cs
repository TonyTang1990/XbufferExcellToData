/*
 * Description:             Xbuffer Excel导表工具静态类
 * Author:                  tanghuan
 * Create Date:             2023/08/16
 */

using System;

namespace XbufferExcelToData
{
    /// <summary>
    /// Xbuffer Excel导表工具静态类
    /// </summary>
    public static class XbufferExcelUtilities
    {
        /// <summary>
        /// 指定类型是否是嵌套类型(含嵌套类型，嵌套类型一维数组，嵌套类型二维数组)
        /// </summary>
        /// <param name="excelDataType"></param>
        /// <returns></returns>
        public static bool IsClassExcelDataType(ExcelDataType excelDataType)
        {
            return excelDataType == ExcelDataType.CLASS ||
                    excelDataType == ExcelDataType.CLASS_ONE_ARRAY ||
                        excelDataType == ExcelDataType.CLASS_TWO_ARRAY;
        }

        /// <summary>
        /// 是否是一维数组类型
        /// </summary>
        /// <param name="excelDataType"></param>
        /// <returns></returns>
        public static bool IsOneArrayDataType(ExcelDataType excelDataType)
        {
            return excelDataType == ExcelDataType.BASIC_ONE_ARRAY ||
                    excelDataType == ExcelDataType.CLASS_ONE_ARRAY;
        }

        /// <summary>
        /// 是否是二维数组类型
        /// </summary>
        /// <param name="excelDataType"></param>
        /// <returns></returns>
        public static bool IsTwoArrayDataType(ExcelDataType excelDataType)
        {
            return excelDataType == ExcelDataType.BASIC_TWO_ARRAY ||
                    excelDataType == ExcelDataType.CLASS_TWO_ARRAY;
        }

        /// <summary>
        /// 获取指定数据类型的Excel数据类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static ExcelDataType GetExcelDataType(string dataType)
        {
            if (ExcelDataManager.Singleton.isValideNormalType(dataType))
            {
                return ExcelDataType.BASIC;
            }
            else if (ExcelDataManager.Singleton.isValideOneArrayNormalType(dataType))
            {
                return ExcelDataType.BASIC_ONE_ARRAY;
            }
            else if (ExcelDataManager.Singleton.isValideTwoArrayNormalType(dataType))
            {
                return ExcelDataType.BASIC_TWO_ARRAY;
            }
            else if (ExcelDataManager.Singleton.isValideNormalClassType(dataType))
            {
                return ExcelDataType.CLASS;
            }
            else if (ExcelDataManager.Singleton.isValideOneArrayClassType(dataType))
            {
                return ExcelDataType.CLASS_ONE_ARRAY;
            }
            else if (ExcelDataManager.Singleton.isValideTwoArrayClassType(dataType))
            {
                return ExcelDataType.CLASS_TWO_ARRAY;
            }
            return ExcelDataType.BASIC;
        }

        /// <summary>
        /// 获取指定Excel Sheet指定成员的嵌套Class名
        /// </summary>
        /// <param name="sheetName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetExcelMemberClassName(string sheetName, string fieldName)
        {
            return $"{sheetName}_{fieldName}";
        }

        /// <summary>
        /// 解析Excel数据信息到Excel类型数据
        /// </summary>
        /// <param name="excelInfo"></param>
        /// <returns></returns>
        public static ClassData ParseExcelInfoToClassData(ExcelInfo excelInfo)
        {
            var classData = new ClassData(excelInfo.ExcelName);
            var memberNum = excelInfo.FieldNames.Length;
            for (int memberIndex = 0, length = memberNum; memberIndex < length; memberIndex++)
            {
                var memberName = excelInfo.FieldNames[memberIndex];
                var memberType = excelInfo.FieldTypes[memberIndex];
                var memberComment = excelInfo.FieldNotations[memberIndex];
                var memberData = new MemberData(classData, memberName, memberType, memberComment);
                classData.AddMemberData(memberData);
            }
            return classData;
        }

        /// <summary>
        /// 解析指定类型数据和类名到Excel类型数据
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="className"></param>
        /// <param name="classComment"></param>
        /// <returns></returns>
        public static ClassData ParseDataTypeToClassData(string dataType, string className, string classComment = "")
        {
            var excelDataType = GetExcelDataType(dataType);
            if(excelDataType != ExcelDataType.CLASS ||
                excelDataType != ExcelDataType.CLASS_ONE_ARRAY ||
                excelDataType != ExcelDataType.CLASS_TWO_ARRAY)
            {
                return null;
            }
            var classDefinition = dataType.TrimStart('{');
            if (excelDataType == ExcelDataType.CLASS)
            {
                classDefinition = classDefinition.TrimEnd("}");
            }
            else if(excelDataType == ExcelDataType.CLASS_ONE_ARRAY)
            {
                classDefinition = classDefinition.TrimEnd("}[]");
            }
            else if(excelDataType == ExcelDataType.CLASS_TWO_ARRAY)
            {
                classDefinition = classDefinition.TrimEnd("}[][]");
            }
            var classData = new ClassData(className, classComment);
            var memberDefinitions = classDefinition.Split(ExcelDataConst.CLASS_MEMBER_SPLITER);
            foreach(var memberDefinition in memberDefinitions)
            {
                var finalMemberDefinition = memberDefinition.Trim();
                var memberInfos = finalMemberDefinition.Split(ExcelDataConst.CLASS_MEMBER_TYPE_NAME_SPLITER);
                var memberInfoNum = memberInfos.Length;
                string memberType = string.Empty;
                var memberName = string.Empty;
                if (memberInfoNum != 2)
                {
                    Console.WriteLine($"SheetName:{className}的字段名:{classComment}的数据类型:{dataType}的成员数据:{finalMemberDefinition}配置格式有误！");
                }
                else
                {
                    memberType = memberInfos[0];
                    memberName = memberInfos[1];
                    // Note:
                    // 嵌套类型只支持基础类型
                    if (!ExcelDataManager.Singleton.isValideNormalType(memberType))
                    {
                        Console.WriteLine($"SheetName:{className}的字段名:{classComment}的数据类型:{dataType}的成员数据:{finalMemberDefinition}的成员类型:{memberType}配置格式有误！");
                        memberType = string.Empty;
                    }
                    if (string.IsNullOrEmpty(memberName))
                    {
                        Console.WriteLine($"SheetName:{className}的字段名:{classComment}的数据类型:{dataType}的成员数据:{finalMemberDefinition}的成员名:{memberName}不能为空！");
                    }
                }
                var memberData = new MemberData(classData, memberName, memberType);
                classData.AddMemberData(memberData);
            }
            return classData;
        }
    }
}
