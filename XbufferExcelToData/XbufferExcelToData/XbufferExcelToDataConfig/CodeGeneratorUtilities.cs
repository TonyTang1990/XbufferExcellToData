/*
 * Description:             代码生成工具静态类
 * Author:                  tanghuan
 * Create Date:             2023/08/21
 */

using System.IO;

namespace XbufferExcelToData
{
    /// <summary>
    /// 代码生成工具静态类
    /// </summary>
    public static class CodeGeneratorUtilities
    {
        /// <summary>
        /// 将类数据结构转化成Class定义代码文本
        /// </summary>
        /// <param name="classData">类结构</param>
        /// <param name="templateContent">模板文本</param>
        /// <param name="outputFolderPath">输出文件目录路径</param>
        /// <returns></returns>
        public static void GenerateClassDataToCSClassCode(ClassData classData, string templateContent, string outputFolderPath)
        {
            var template = new XTemplate(templateContent);

            template.setValue("#CLASS_NAME#", classData.ClassName);
            template.setValue("#CLASS_COMMENT#", classData.Comment);

            if (template.beginLoop("#VARIABLES#"))
            {
                foreach (var memberData in classData.MemberDataList)
                {
                    var isOneArrayDataType = XbufferExcelUtilities.IsOneArrayDataType(memberData.ExcelDataType);
                    var isTwoArrayDataType = XbufferExcelUtilities.IsTwoArrayDataType(memberData.ExcelDataType);
                    template.setCondition("SINGLE", !(isOneArrayDataType || isTwoArrayDataType));
                    template.setCondition("ARRAY", isOneArrayDataType);
                    template.setCondition("TWO_ARRAY", isTwoArrayDataType);
                    template.setValue("#VAR_TYPE#", memberData.BasicDataType);
                    template.setValue("#VAR_NAME#", memberData.Name);
                    template.setValue("#VAR_COMMENT#", memberData.Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#CONSTRUCTOR_PARAMS#"))
            {
                for (int i = 0, length = classData.MemberDataList.Count; i < length; i++)
                {
                    var memberData = classData.MemberDataList[i];
                    var isOneArrayDataType = XbufferExcelUtilities.IsOneArrayDataType(memberData.ExcelDataType);
                    var isTwoArrayDataType = XbufferExcelUtilities.IsTwoArrayDataType(memberData.ExcelDataType);
                    var isLastVariable = i == (length - 1);
                    var varName = isLastVariable ? memberData.Name : $"{memberData.Name},";
                    template.setCondition("SINGLE", !(isOneArrayDataType || isTwoArrayDataType));
                    template.setCondition("ARRAY", isOneArrayDataType);
                    template.setCondition("TWO_ARRAY", isTwoArrayDataType);
                    template.setValue("#VAR_TYPE#", memberData.BasicDataType);
                    template.setValue("#VAR_NAME#", varName);
                    template.setValue("#VAR_COMMENT#", memberData.Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#CONSTRUCTOR_ASSIGNMENTS#"))
            {
                foreach (var memberData in classData.MemberDataList)
                {
                    template.setValue("#VAR_NAME#", memberData.Name);
                    template.nextLoop();
                }
                template.endLoop();
            }
            var outputFileName = $"{classData.ClassName}{ConstValue.CSharpFilePostfix}";
            var outputFilePath = Path.Combine(outputFolderPath, outputFileName);
            File.WriteAllText(outputFilePath, template.getContent());

            // 递归生成嵌套成员Class定义代码文本
            foreach (var memberData in classData.MemberDataList)
            {
                if(XbufferExcelUtilities.IsClassExcelDataType(memberData.ExcelDataType))
                {
                    GenerateClassDataToCSClassCode(memberData.MemberClassData, templateContent, outputFolderPath);
                }
            }
        }

        /// <summary>
        /// 将类数据结构转化成Class序列化代码文本
        /// </summary>
        /// <param name="classData">类结构</param>
        /// <param name="templateContent">模板文本</param>
        /// <param name="outputFolderPath">输出文件目录路径</param>
        /// <returns></returns>
        public static void GenerateClassDataToCSBufferCode(ClassData classData, string templateContent, string outputFolderPath)
        {
            var template = new XTemplate(templateContent);

            template.setValue("#CLASS_NAME#", classData.ClassName);

            template.setCondition("DESERIALIZE_CLASS", true);
            template.setCondition("SERIALIZE_CLASS", true);

            if (template.beginLoop("#DESERIALIZE_PROCESS#"))
            {
                foreach (var memberData in classData.MemberDataList)
                {
                    var isOneArrayDataType = XbufferExcelUtilities.IsOneArrayDataType(memberData.ExcelDataType);
                    var isTwoArrayDataType = XbufferExcelUtilities.IsTwoArrayDataType(memberData.ExcelDataType);
                    template.setCondition("SINGLE", !(isOneArrayDataType || isTwoArrayDataType));
                    template.setCondition("ARRAY", isOneArrayDataType);
                    template.setCondition("TWO_ARRAY", isTwoArrayDataType);
                    template.setValue("#VAR_TYPE#", memberData.BasicDataType);
                    template.setValue("#VAR_NAME#", memberData.Name);
                    template.setValue("#VAR_COMMENT#", memberData.Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#DESERIALIZE_RETURN#"))
            {
                for (int i = 0, length = classData.MemberDataList.Count; i < length; i++)
                {
                    var memberData = classData.MemberDataList[i];
                    var isLastVariable = i == (length - 1);
                    var varName = isLastVariable ? memberData.Name : $"{memberData.Name},";
                    template.setValue("#VAR_TYPE#", memberData.BasicDataType);
                    template.setValue("#VAR_NAME#", varName);
                    template.setValue("#VAR_COMMENT#", memberData.Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#SERIALIZE_PROCESS#"))
            {
                foreach (var memberData in classData.MemberDataList)
                {
                    var isOneArrayDataType = XbufferExcelUtilities.IsOneArrayDataType(memberData.ExcelDataType);
                    var isTwoArrayDataType = XbufferExcelUtilities.IsTwoArrayDataType(memberData.ExcelDataType);
                    template.setCondition("SINGLE", !(isOneArrayDataType || isTwoArrayDataType));
                    template.setCondition("ARRAY", isOneArrayDataType);
                    template.setCondition("TWO_ARRAY", isTwoArrayDataType);
                    template.setValue("#VAR_TYPE#", memberData.BasicDataType);
                    template.setValue("#VAR_NAME#", memberData.Name);
                    template.setValue("#VAR_COMMENT#", memberData.Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }
            var outputFileName = $"{classData.ClassName}Buffer{ConstValue.CSharpFilePostfix}";
            var outputFilePath = Path.Combine(outputFolderPath, outputFileName);
            File.WriteAllText(outputFilePath, template.getContent());

            // 递归生成嵌套成员Class序列化代码文本
            foreach (var memberData in classData.MemberDataList)
            {
                if (XbufferExcelUtilities.IsClassExcelDataType(memberData.ExcelDataType))
                {
                    GenerateClassDataToCSBufferCode(memberData.MemberClassData, templateContent, outputFolderPath);
                }
            }
        }
    }
}
