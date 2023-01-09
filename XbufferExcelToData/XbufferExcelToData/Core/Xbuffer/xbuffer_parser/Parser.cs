/*
 * File Name:               Parser.cs
 *
 * Description:             将类对象转化成代码文本
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2017/10/25
 */

using System;
using System.IO;

namespace xbuffer
{
    /// <summary>
    /// 解析器静态类
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// 根据指定参数进行解析
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool parseByArgs(string[] args)
        {
            if (!Config.load(args))
            {
                Console.WriteLine($"请输入正确的参数:{args}！");
                return false;
            }

            if (!Directory.Exists(Config.input))
            {
                Console.WriteLine($"请输入正确的描述文件路径:{Config.input}");
                return false;
            }

            if (!File.Exists(Config.template))
            {
                Console.WriteLine($"请输入正确的模板文件路径:{Config.template}");
                return false;
            }

            //修改支持指定描述文件目录形式的自动化解析
            var template_str = File.ReadAllText(Config.template);
            var template_name = Path.GetFileNameWithoutExtension(Config.template);
            if (Config.output_file == "")
            {
                Directory.CreateDirectory(Config.output_dir);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Config.output_file));
            }

            var files = Directory.GetFiles(Config.input, "*.xb");
            foreach (var file in files)
            {
                var proto = File.ReadAllText(file);
                var proto_classs = new Proto(proto).class_protos;
                var output = "";
                var showHead = true;
                foreach (var proto_class in proto_classs)
                {
                    if (Config.output_file == "")
                    {
                        output = parse(proto_class, template_str, showHead);
                        showHead = false;
                        File.WriteAllText(Config.output_dir + "/" + proto_class.Class_Name + Config.suffix, output);
                    }
                    else
                    {
                        output += parse(proto_class, template_str, showHead);
                        output += "\n\n";
                        showHead = false;
                    }
                }
                if (Config.output_file != "")
                    File.WriteAllText(Config.output_file + Config.suffix, output);

                Console.WriteLine(string.Format("生成完毕 input:{0}, template:{1}", Path.GetFileName(file), Path.GetFileName(Config.template)));
            }
            return true;
        }

        /// <summary>
        /// 将类对象转化成代码文本
        /// </summary>
        /// <param name="proto_class">类结构</param>
        /// <param name="template_str">模板文本</param>
        /// <returns></returns>
        public static string parse(Proto_Class proto_class, string template_str, bool showHead)
        {
            var template = new XTemplate(template_str);

            template.setCondition("HEAD", showHead);
            template.setValue("#CLASS_TYPE#", proto_class.Class_Type);
            template.setValue("#CLASS_NAME#", proto_class.Class_Name);
            template.setValue("#CLASS_COMMENT#", proto_class.Class_Comment);

            template.setCondition("DESERIALIZE_CLASS", proto_class.Class_Type == "class");
            template.setCondition("SERIALIZE_CLASS", proto_class.Class_Type == "class");

            if (template.beginLoop("#VARIABLES#"))
            {
                foreach (var item in proto_class.Class_Variables)
                {
                    template.setCondition("SINGLE", !(item.IsOneArray || item.IsTwoArray));
                    template.setCondition("ARRAY", item.IsOneArray);
                    template.setCondition("TWO_ARRAY", item.IsTwoArray);
                    template.setValue("#VAR_TYPE#", item.Var_Type);
                    template.setValue("#VAR_NAME#", item.Var_Name);
                    template.setValue("#VAR_COMMENT#", item.Var_Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#DESERIALIZE_PROCESS#"))
            {
                foreach (var item in proto_class.Class_Variables)
                {
                    template.setCondition("SINGLE", !(item.IsOneArray || item.IsTwoArray));
                    template.setCondition("ARRAY", item.IsOneArray);
                    template.setCondition("TWO_ARRAY", item.IsTwoArray);
                    template.setValue("#VAR_TYPE#", item.Var_Type);
                    template.setValue("#VAR_NAME#", item.Var_Name);
					template.setValue("#VAR_COMMENT#", item.Var_Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#DESERIALIZE_RETURN#"))
            {
                foreach (var item in proto_class.Class_Variables)
                {
					template.setValue("#VAR_TYPE#", item.Var_Type);
                    template.setValue("#VAR_NAME#", item.Var_Name);
					template.setValue("#VAR_COMMENT#", item.Var_Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            if (template.beginLoop("#SERIALIZE_PROCESS#"))
            {
                foreach (var item in proto_class.Class_Variables)
                {
                    template.setCondition("SINGLE", !(item.IsOneArray || item.IsTwoArray));
                    template.setCondition("ARRAY", item.IsOneArray);
                    template.setCondition("TWO_ARRAY", item.IsTwoArray);
                    template.setValue("#VAR_TYPE#", item.Var_Type);
                    template.setValue("#VAR_NAME#", item.Var_Name);
					template.setValue("#VAR_COMMENT#", item.Var_Comment);
                    template.nextLoop();
                }
                template.endLoop();
            }

            return template.getContent();
        }
    }
}