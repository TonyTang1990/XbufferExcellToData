/*
 * Description:             Excel数据类型枚举
 * Author:                  tanghuan
 * Create Date:             2023/08/16
 */

namespace XbufferExcelToData
{
    /// <summary>
    /// Excel数据类型枚举
    /// </summary>
    public enum ExcelDataType
    {
        BASIC = 1,          // 基础数据类型
        BASIC_ONE_ARRAY,    // 一维数组基础数据类型
        BASIC_TWO_ARRAY,    // 二维数组基础数据类型
        CLASS,              // 嵌套CLASS类型
        CLASS_ONE_ARRAY,    // 一维数组嵌套Class类型
        CLASS_TWO_ARRAY,    // 二维数组嵌套Class类型
    }
}
