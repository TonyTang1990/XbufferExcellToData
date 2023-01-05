# XbufferExcellToData
基于Xbuffer的自动化导表工具

## 功能支持
1. 支持常见基础数据类型配置(e.g int, bool, long, float, string)配置(可自行修改源码快速支持double之类的基础数据)
2. ~~支持一维数据的快速配置(支持配置一个分割符(分隔符支持范围:"+;,|"))(可自行修改源码快速支持)~~**(2023/1/5不再支持自定义指定分隔符，一维分隔符固定用#)**
3. 自动化生成表格数据快速访问相关代码
4. 基于Xbuffer的高效序列化反序列化性能以及内存占用
5. 支持单Excel多sheet导出支持(**2022/1/20支持完成**)
6. 支持二维数组配置导出**(二维分隔符固定用|，2023/1/5支持完成)**

## Excel文件支持
1. *.xlsx(实际上我只测试了这个，下面两个是理论上支持的)
2. *.xls
3. *.csv

## 配置表规则
1. 导表工具相关配置通过配置ExportConfig.xml文件即可
    - ExcelInputPath(Excel目录配置)
    - TemplatePath(代码模板文件目录配置)
    - DesFileOutputPath(Excel对应的描述文件输出目录配置)
    - ByteDataOutputPath(序列化数据输出目录配置)
    - CSClassCodeOutputPath(CS类代码输出目录配置)
    - CSBufferCodeOutputPath(CS序列化代码输出目录配置)
    - CSTemplateOutputPath(CS模板文件代码输出目录配置)
    - OtherLanguageCodeOutputPath(其他语言代码输出目录配置 -- 扩展支持其他语言的话(暂未做支持))
    Note:
    支持相对路径配置。
2. 配置规则限制
    - 第一行表示字段名字
    - 第二行表示字段注释
    - 第三行表示字段数据类型
    - 第四行分隔符信息配置
    - 第五行占位符1(未来扩展用)
    - 第六行占位符2(未来扩展用)
    - 第七行以及以后(数据配置)
3. Excel的Sheet名字限制
    - 不允许重名的Sheet名字
    - Sheet名blacklist开头表示不参与导表(**2022/1/20支持完成**)
4. 字段名要求
    - 第一列的字段名不再限制取名(**2022/1/20支持完成**)
    - 非注释类型字段必须配置字段名
    - 非注释类型配置的字段名不能为空
    - 非注释类型字段名在同一个Excel里不允许重名
    - 注释类型不可以配置字段名
5. 字段类型配置限制(只支持以下类型)
    - int
    - bool
    - long
    - float
    - string
    - 上面各基础类型的一维数组类型 T[]
    - notation(注释类型，不会参与序列化和反序列化的数据，仅供Excel查看使用)
6. ~~分隔符配置限制~~**(2023/1/5不再支持自定义指定分隔符，一维分隔符固定用#，二维分隔符固定用|)**
    - ~~只支持配置了T[]类型的数据配置分割符~~
    - ~~分隔符只能指定一个~~
    - ~~分隔符必须是以下分隔符里的一个:+;,|(可自行修改源码支持更多)~~
    - ~~T[]类型数据必须指定分隔符~~ 
7. 数据配置限制
    - 第一列字段类型必须为int或string类型(**2022/1/20支持完成**)
    - 第一列字段名配置不能为空
    - 第一列字段不能重复

多语言扩展:
理论上通过自定义对应模板生成对应语言反序列化相关代码即可。

## 核心工具
### ExcelDataReader
Github上一个跨平台的C#读取Excel数据的库。

Github链接：
[ExcelDataReader](https://github.com/ExcelDataReader/ExcelDataReader)

### Xbuffer
Github上一个简易版的FlatBuffer序列化库。

Github链接：
[Xbuffer](https://github.com/CodeZeg/xbuffer)

### XbufferExcelToData工具
本Github项目实现的以Xbuffer为序列化核心，ExcelDataReader作为Excel表格数据读取完成的一个自动化导表读取工具。

C#工程里：

核心文件(这里的流程顺序也相当于导表工具流程):
1. ExportConfig.xml(导表工具相关路径配置文件)
2. ExportConfig.cs(工具路径配置信息抽象类) &  XbufferExcelExportConfig.cs(工具路径配置信息读取管理类)
3. ExcelDataReader.dll(第三方跨平台Excel读取库) & ExcelData.cs(单个表格数据抽象类) & ExcelDataManager.cs(所有Excel数据读取管理类)
4. XbufferExcelToDesFile.cs(自动化生成Excel数据对应的数据结构定义文件类的单例类)
5. XbufferDesFileToCSCode.cs(自动化根据数据结构文件生成CS对应代码的静态单例类)
6. XbufferExcelDataToBytes.cs(自动化将Excel数据通过Xbuffer序列化到二进制数据的单例类)
7. XbufferTemplateToCSCode.cs(模板解析单例类，根据模板解析生成自动化加载管理相关的代码) & excelContainer.ftl(Excel对应的数据加载类模板) & GameDataManager.ftl(所有Excel数据统一管理加载的类模板)

Unity工程：
1. ConfLoader.cs(配置表加载辅助单例类 - 占时是放在Resource是目录下以TextAsset的形式加载)

## Demo使用说明
测试数据:
    
    两张表（author_info.xlsx和global_config.xlsx），各配置了1000行数据，然后复制两张表9次并改名(文件名和Excel内部sheet名都得改)(总计20张表 X 1000行数据)。

测试平台：
    
    PC Windows & 小米 Mix2一代

游戏引擎:
    
    Unity 2017.4.3f1

Demo使用流程：
1. 配置ExportConfig.xml(保持默认配好的即可)
2. 打开Unity工程项目XbufferExcelToDataUnityProject(Unity 2017.4.3.f1版本)

    Unity下的导表工具目录：

    ![FilesFolderStructure](/Images/FilesFolderStructure.png)
3. 双击使用Conf目录下的XbufferExcelToData.exe(导表工具触发导表)

    导表耗时:

    ![XbuuferExcelToDataTimeConsume](/Images/XbufferExcelToDataTimeConsume.png)

    导表后的二进制文件大小(未压缩):
        二进制数据总大小我统计了下未压缩共1.3M。
4. 运行项目

    ![RunUnityProject](/Images/RunUnityProject.png)
5. 点击加载所有表格按钮

    ![LoadAllExcelData](/Images/LoadAllExcelData.png)
6. 点击打印AuthorInfo表格数据按钮

    ![PrintAuthorInfoExcelData](/Images/PrintAuthorInfoExcelData.png)


表格数据读取内存以及反序列化时间开销：
	   
统计方式:
       
    Unity的Profiler.GetMonoUsedSizeLong()

PC:

![Profiler_GetMonoUsedSizeLong_MemoryUsing](/Images/Profiler_GetMonoUsedSizeLong_MemoryUsing.png)

小米Mix2一代:

![AndroidDevice_Profiler_GetMonoUsedSizeLong_MemoryUsing](/Images/AndroidDevice_Profiler_GetMonoUsedSizeLong_MemoryUsing.png)

Unity API统计的堆内存内存开销在5M左右。
时间开销PC在100ms左右,Android真机在200ms左右。

从20张表，每张表大概4-7个字段，各1000行数据来看，内存和序列化，反序列化速度都还是相当可观的。

这里因为没有集成支持其他序列化方式，所以没法做详细的对比，详细各序列化库性能对比参考Xbuffer作者在Github上的对比[Xbuffer](https://github.com/CodeZeg/xbuffer)。

Note:

*理论上扩展支持其他语言只需要定义对应语言的模板文件然后生成对应所需代码即可。*

## 小技巧

问题1：

每次导表格后生成CS代码导致Unity转圈圈转很久。

解决方案：

支持配置是否生成CS代码来优化Unity转圈圈问题

使用方式：

ExportExcel_DisableCSOuput.bat -- 关闭生成CS代码功能的导表快捷方式

ExportExcel_EnableCSOuput.bat -- 开启生成CS代码功能的导表快捷方式

问题2:

第二行写注释如果有空格符号会导致该表格无法生成对应的数据结构代码**(2023/1/5已解决，支持注释填写空格)**

解决方案:

具体原因是*.xb文件的正则匹配上不允许注释中间出现任意空格符号，暂时没支持，所以临时解决方案是不要再注释中间写空格符号。**(2023/1/5已解决，支持注释填写空格)**

## 个人博客

详细的博客记录学习:

[Data-Config-Automation](http://tonytang1990.github.io/2018/03/18/Data-Config-Automation/#%E5%9F%BA%E4%BA%8EXbuffer%E7%9A%84%E5%AF%BC%E8%A1%A8%E5%B7%A5%E5%85%B7)

# 鸣谢
感谢Xbuffer作者的无私分享，Xbuffer的Github链接:

[Xbuffer](https://github.com/CodeZeg/xbuffer)

感谢ExcelDataReader作者分享的Excel快速读取跨平台库，Github链接：

[ExcelDataReader](https://github.com/ExcelDataReader/ExcelDataReader)