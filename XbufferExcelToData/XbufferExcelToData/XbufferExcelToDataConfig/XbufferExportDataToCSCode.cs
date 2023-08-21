/*
 * Description:             自动化根据Excel数据结构文件生成CS对应代码的静态单例类
 * Author:                  tanghuan
 * Create Date:             2023/08/19
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace XbufferExcelToData
{
    /// <summary>
    /// 自动化根据Excel数据结构文件生成CS对应代码的静态单例类
    /// </summary>
    public class XbufferExportDataToCSCode : SingletonTemplate<XbufferExportDataToCSCode>
    {
        /// <summary> Xbuffer模板文件目录 /// </summary>
        public string TemplateFolderPath { get; private set; }

        /// <summary> CS类代码生成目录 /// </summary>
        public string CSClassCodeFolderPath { get; private set; }

        /// <summary> CS序列化代码生成目录 /// </summary>
        public string CSBufferCodeFolderPath { get; private set; }

        public XbufferExportDataToCSCode()
        {
            TemplateFolderPath = string.Empty;
            CSClassCodeFolderPath = string.Empty;
            CSBufferCodeFolderPath = string.Empty;
        }

        /// <summary>
        /// 配置相关目录路径
        /// </summary>
        /// <param name="templatefolderpath">Xbuffer模本文件目录</param>
        /// <param name="csclassfolderpath">CS类代码文件生成目录</param>
        /// <param name="csbufferfolderpath">CS序列化代码文件生成目录</param>
        public void configFolderPath(string templatefolderpath, string csclassfolderpath, string csbufferfolderpath)
        {
            TemplateFolderPath = TemplateFolderPath;
            CSClassCodeFolderPath = csclassfolderpath;
            CSBufferCodeFolderPath = csbufferfolderpath;
        }

        /// <summary>
        /// 将所有Excel数据结构文件生成对应的所有Xbuffer相关代码(含对应类代码以及序列化相关代码)
        /// </summary>
        /// <param name="excelClassDataMap">Excel类型数据Map</param>
        /// <returns></returns>
        public bool writeAllExportDataToCSCode(Dictionary<string, ClassData> excelClassDataMap)
        {
            Utilities.RecreateSpecificFolder(CSClassCodeFolderPath);
            Utilities.RecreateSpecificFolder(CSBufferCodeFolderPath);
            startExportDataToCSClass(excelClassDataMap);
            startExportDataToCSBuffer(excelClassDataMap);
            return true;
        }

        /// <summary>
        /// 开始根据Excel结构数据生成CS类代码
        /// </summary>
        /// <param name="excelClassDataMap">Excel类型数据Map</param>
        private void startExportDataToCSClass(Dictionary<string, ClassData> excelClassDataMap)
        {
            var result = false;
            var csClassTemplateFilePath = GetCSClassTemplateFilePath();
            if(!string.IsNullOrEmpty(csClassTemplateFilePath))
            {
                if (!File.Exists(csClassTemplateFilePath))
                {
                    Console.WriteLine($"CSClass模版文件:{csClassTemplateFilePath}不存在，生成CSClass代码失败！");
                }
                else
                {
                    var templateContent = File.ReadAllText(csClassTemplateFilePath);
                    foreach (var classDataValues in excelClassDataMap)
                    {
                        var classData = classDataValues.Value;
                        var outputFileName = $"{classData.ClassName}{ConstValue.CSharpFilePostfix}";
                        var outputFilePath = Path.Combine(CSClassCodeFolderPath, outputFileName);
                        CodeGeneratorUtilities.GenerateClassDataToCSClassCode(classData, templateContent, outputFilePath);
                    }
                }
            }
            var resultTxt = result ? "成功" : "失败";
            Console.WriteLine($"CS Class生成结果:{resultTxt}");
        }

        /// <summary>
        /// 开始Xbuffer生成CS序列化代码
        /// </summary>
        /// <param name="excelClassDataMap">Excel类型数据Map</param>
        private void startExportDataToCSBuffer(Dictionary<string, ClassData> excelClassDataMap)
        {
            var result = false;
            var csBufferTemplateFilePath = GetCSBufferTemplateFilePath();
            if (!string.IsNullOrEmpty(csBufferTemplateFilePath))
            {
                if(!File.Exists(csBufferTemplateFilePath))
                {
                    Console.WriteLine($"CSBuffer模版文件:{csBufferTemplateFilePath}不存在，生成CSBuffer代码失败！");
                }
                else
                {
                    var templateContent = File.ReadAllText(csBufferTemplateFilePath);
                    foreach (var classDataValues in excelClassDataMap)
                    {
                        var classData = classDataValues.Value;
                        var outputFileName = $"{classData.ClassName}Buffer{ConstValue.CSharpFilePostfix}";
                        var outputFilePath = Path.Combine(CSBufferCodeFolderPath, outputFileName);
                        CodeGeneratorUtilities.GenerateClassDataToCSBufferCode(classData, templateContent, outputFilePath);
                    }
                }
            }
            var resultTxt = result ? "成功" : "失败";
            Console.WriteLine($"CS Buffer生成结果:{resultTxt}");
        }

        /// <summary>
        /// 获取CSClass模版文件路径
        /// </summary>
        /// <returns></returns>
        private string GetCSClassTemplateFilePath()
        {
            if(string.IsNullOrEmpty(TemplateFolderPath))
            {
                Console.WriteLine($"未配置有效模版文件目录路径，获取CSClass模版文件路径失败！");
                return null;
            }
            return $"{TemplateFolderPath}{ConstValue.CSClassTemplateFileName}";
        }

        /// <summary>
        /// 获取CSBuffer模版文件路径
        /// </summary>
        /// <returns></returns>
        private string GetCSBufferTemplateFilePath()
        {
            if (string.IsNullOrEmpty(TemplateFolderPath))
            {
                Console.WriteLine($"未配置有效模版文件目录路径，获取CSBuffer模版文件路径失败！");
                return null;
            }
            return $"{TemplateFolderPath}{ConstValue.CSBufferTemplateFileName}";
        }
    }
}
