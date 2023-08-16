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
    /// 自动化分析配置表数据到导出数据
    /// </summary>
    class XbufferExcelToExportData : SingletonTemplate<XbufferExcelToExportData>
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
        }

        /// <summary>
        /// 成员结构数据抽象
        /// </summary>
        public class MemberData
        {
            /// <summary>
            /// 成员名
            /// </summary>
            public string Name
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
            /// <param name="name"></param>
            /// <param name="dataType"></param>
            /// <param name="comment"></param>
            /// <param name="excelDataType"></param>
            public MemberData(string name, string dataType, string comment = "", ExcelDataType excelDataType = ExcelDataType.BASIC)
            {
                Name = name;
                DataType = dataType;
                Comment = comment;
                ExcelDataType = excelDataType;
            }

            /// <summary>
            /// 获取字符串描述
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return $"Name:{Name};DataType:{DataType};ExcelDataType:{ExcelDataType};Comment:{Comment}";
            }
        }

        /// <summary>
        /// Excel类型数据Map<sheet名, sheet类型数据>
        /// </summary>
        private Dictionary<string, ClassData> mExcelClassDataMap;

        public XbufferExcelToExportData()
        {
            mExcelClassDataMap = new Dictionary<string, ClassData>();
        }

        /// <summary>
        /// 解析Excel类型数据
        /// </summary>
        /// <param name="excelsInfoMap"></param>
        public void ParseExcelClassDatas(Dictionary<string, ExcelInfo> excelsInfoMap)
        {
            mExcelClassDataMap.Clear();

        }

        /// <summary>
        /// 获取指定Sheet名的Excel类型抽象数据
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public ClassData GetExcelClassDataBySheetName(string sheetName)
        {
            ClassData classData;
            if(!mExcelClassDataMap.TryGetValue(sheetName, out classData))
            {
                Console.WriteLine($"找不到Sheet:{sheetName}的Excel类型抽象数据！");
                return null;
            }
            return classData;
        }
    }
}
