/*
 * Description:             GameConfigManager.cs
 * Author:                  TONYTANG
 * Create Date:             2018/08/12
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

/// <summary>
/// GameConfigManager.cs
/// ��Ϸ�����ļ���������
/// </summary>
public class GameConfigManager : SingletonTemplate<GameConfigManager> {

    /// <summary>
    /// ��Ϸ�汾��Ϣ�����ļ���
    /// </summary>
    private const string mVersionConfigFileName = "VersionConfig";

    /// <summary>
    /// ��Ϸ�汾�����ļ���׺��
    /// </summary>
    private const string mVersionConfigFilePostFix = ".json";

    /// <summary>
    /// �����ļ�Ŀ¼·��
    /// </summary>
    private const string ConfigFolderPath = "Config/";

    /// <summary>
    /// �汾��Ϣ�ļ��洢·��
    /// </summary>
    public string VersionConfigFileFolderPath
    {
        get;
        private set;
    }
    private string mVersionConfigFilePath = ConfigFolderPath + mVersionConfigFileName;

    /// <summary>
    /// ��Ϸ�汾��Ϣ
    /// </summary>
    public VersionConfig GameVersionConfig
    {
        get;
        private set;
    }

    /// <summary>
    /// UTF8����
    /// </summary>
    private UTF8Encoding mUTF8Encoding = new UTF8Encoding(true);

    /// <summary>
    /// �洢�汾��Ϣ�ļ�
    /// </summary>
    public void saveVersionConfig()
    {
        Debug.Log(string.Format("mVersionConfigFilePath : {0}", mVersionConfigFilePath));
        var edtiroversionconfigfullpath = mVersionConfigFilePath;
#if UNITY_EDITOR
        //�༭��ģʽ�²�����洢������Ŀ¼����д
        edtiroversionconfigfullpath = Application.dataPath + "/Resources/" + mVersionConfigFilePath + mVersionConfigFilePostFix;
        //�༭��ģʽ��֧�ֲ������򴴽�һ��Ĭ�ϵ�
        if (!File.Exists(edtiroversionconfigfullpath))
        {
            FileStream fsc = File.Create(edtiroversionconfigfullpath);
            fsc.Close();
            //�����ڵĴ���һ��Ĭ��VersionCode = 1, VersionName = 1����Ϸ�汾��Ϣ�ļ�
            if (GameVersionConfig == null)
            {
                GameVersionConfig = new VersionConfig();
                GameVersionConfig.VersionCode = 1;
                GameVersionConfig.VersionName = "1";
            }
        }
#else
        var versionconfigasset = Resources.Load<TextAsset>(mVersionConfigFilePath);
        if(versionconfigasset == null)
        {
            Debug.LogError(string.Format("�Ҳ�����Ϸ�汾�����ļ� : {0}!", mVersionConfigFilePath));
            return;
        }
#endif
        var versionconfigdata = JsonUtility.ToJson(GameVersionConfig);
        using (var verisionconfigfs = File.Open(edtiroversionconfigfullpath, FileMode.Open))
        {
            byte[] versionconfiginfo = mUTF8Encoding.GetBytes(versionconfigdata);
            verisionconfigfs.Write(versionconfiginfo, 0, versionconfiginfo.Length);
            verisionconfigfs.Close();
        }
    }

    /// <summary>
    /// ��ȡ�汾��Ϣ
    /// </summary>
    /// <returns></returns>
    public void readVerisonConfigData()
    {
        Debug.Log(string.Format("mVersionConfigFilePath : {0}", mVersionConfigFilePath));
        var versionconfigasset = Resources.Load<TextAsset>(mVersionConfigFilePath);
        if (versionconfigasset != null)
        {
            GameVersionConfig = JsonUtility.FromJson<VersionConfig>(mUTF8Encoding.GetString(versionconfigasset.bytes));
            Debug.Log(string.Format("VersionCode : {0} VersionName : {1}", GameVersionConfig.VersionCode, GameVersionConfig.VersionName));
        }
        else
        {
            Debug.LogError(string.Format("��Ϸ���ð汾��Ϣ�ļ� : {0}������!�޷���ȡ!", mVersionConfigFilePath));
        }
    }    
}