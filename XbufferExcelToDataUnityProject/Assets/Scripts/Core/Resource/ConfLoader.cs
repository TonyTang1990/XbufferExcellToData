/*
 * Description:             ���ñ���ظ���������
 * Author:                  tanghuan
 * Create Date:             2018/09/05
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// ���ñ���ظ���������
/// </summary>
public class ConfLoader : SingletonTemplate<ConfLoader> {

    /// <summary>
    /// Excel������ݴ洢Ŀ¼
    /// </summary>
    public const string ExcelDataFolderPath = "DataBytes/";

    public ConfLoader()
    {

    }

    /// <summary>
    /// ��ȡ����������ݵĶ�����������
    /// </summary>
    /// <param name="bytefilename"></param>
    /// <returns></returns>
    public Stream GetStreamByteName(string bytefilename)
    {
        var textasset = Resources.Load(ExcelDataFolderPath + bytefilename) as TextAsset;
        var memorystream = new MemoryStream(textasset.bytes);
        return memorystream;
    }
}
