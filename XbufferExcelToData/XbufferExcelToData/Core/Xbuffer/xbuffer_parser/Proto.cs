/*
 * File Name:               Proto.cs
 *
 * Description:             原型语法解析工具
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

using System.Text.RegularExpressions;

namespace xbuffer
{
    public class Proto
    {
        public Proto_Class[] class_protos
        {
            get;
            private set;
        }

        public Proto(string proto)
        {
            var matchs = Regex.Matches(proto, @"//\s*(\S*)\s*((class)|(struct))\s*(\w+)\s*{\s*((\w+):([\[|\]|\w]+);\s*//\s*([\S ]*)\s*)*}");
            class_protos = new Proto_Class[matchs.Count];
            for (int i = 0; i < matchs.Count; i++)
            {
                class_protos[i] = new Proto_Class(matchs[i]);
            }
        }
    }

    /// <summary>
    /// 变量结构
    /// </summary>
    public class Proto_Variable
    {
        /// <summary>
        /// 变量类型
        /// </summary>
        public string Var_Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 变量名
        /// </summary>
        public string Var_Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否是一维数组
        /// </summary>
        public bool IsOneArray
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否是二维数组
        /// </summary>
        public bool IsTwoArray
        {
            get;
            private set;
        }

        /// <summary>
        /// 变量注释
        /// </summary>
        public string Var_Comment
        {
            get;
            private set;
        }

        public Proto_Variable(string name, string type, string comment)
        {
            Var_Name = name;
            if (type.Contains("[["))
            {
                Var_Type = type.Substring(2, type.Length - 4);
                IsOneArray = false;
                IsTwoArray = true;
            }
            else if(type.Contains("["))
            {
                Var_Type = type.Substring(1, type.Length - 2);
                IsOneArray = true;
                IsTwoArray = false;
            }
            else
            {
                Var_Type = type;
                IsOneArray = false;
                IsTwoArray = false;
            }
            Var_Comment = comment;
        }
    }

    /// <summary>
    /// 类结构
    /// </summary>
    public class Proto_Class
    {
        /// <summary>
        /// 注释
        /// </summary>
        public string Class_Comment
        {
            get;
            private set;
        }

        /// <summary>
        /// 类型 例如 class struct
        /// </summary>
        public string Class_Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 类名
        /// </summary>
        public string Class_Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 变量列表
        /// </summary>
        public Proto_Variable[] Class_Variables
        {
            get;
            private set;
        }

        public Proto_Class(Match match)
        {
            Class_Comment = match.Groups[1].Value;
            Class_Type = match.Groups[2].Value;
            Class_Name = match.Groups[5].Value;

            var varNames = match.Groups[7].Captures;
            var varTypes = match.Groups[8].Captures;
            var varComments = match.Groups[9].Captures;
            Class_Variables = new Proto_Variable[varNames.Count];
            for (int i = 0; i < Class_Variables.Length; i++)
            {
                Class_Variables[i] = new Proto_Variable(varNames[i].Value, varTypes[i].Value, varComments[i].Value);
            }
        }
    }
}