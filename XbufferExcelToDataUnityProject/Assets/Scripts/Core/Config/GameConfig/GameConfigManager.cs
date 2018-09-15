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
/// 游戏配置文件管理单例类
/// </summary>
public class GameConfigManager : SingletonTemplate<GameConfigManager> {

    /// <summary>
    /// 游戏版本信息配置文件名
    /// </summary>
    private const string mVersionConfigFileName = "VersionConfig";

    /// <summary>
    /// 游戏版本配置文件后缀名
    /// </summary>
    private const string mVersionConfigFilePostFix = ".json";

    /// <summary>
    /// 配置文件目录路径
    /// </summary>
    private const string ConfigFolderPath = "Config/";

    /// <summary>
    /// 版本信息文件存储路径
    /// </summary>
    public string VersionConfigFileFolderPath
    {
        get;
        private set;
    }
    private string mVersionConfigFilePath = ConfigFolderPath + mVersionConfigFileName;

    /// <summary>
    /// 游戏版本信息
    /// </summary>
    public VersionConfig GameVersionConfig
    {
        get;
        private set;
    }

    /// <summary>
    /// UTF8编码
    /// </summary>
    private UTF8Encoding mUTF8Encoding = new UTF8Encoding(true);

    /// <summary>
    /// 存储版本信息文件
    /// </summary>
    public void saveVersionConfig()
    {
        Debug.Log(string.Format("mVersionConfigFilePath : {0}", mVersionConfigFilePath));
        var edtiroversionconfigfullpath = mVersionConfigFilePath;
#if UNITY_EDITOR
        //编辑器模式下才允许存储创建，目录单独写
        edtiroversionconfigfullpath = Application.dataPath + "/Resources/" + mVersionConfigFilePath + mVersionConfigFilePostFix;
        //编辑器模式下支持不存在则创建一个默认的
        if (!File.Exists(edtiroversionconfigfullpath))
        {
            FileStream fsc = File.Create(edtiroversionconfigfullpath);
            fsc.Close();
            //不存在的创建一个默认VersionCode = 1, VersionName = 1的游戏版本信息文件
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
            Debug.LogError(string.Format("找不到游戏版本配置文件 : {0}!", mVersionConfigFilePath));
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
    /// 读取版本信息
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
            Debug.LogError(string.Format("游戏配置版本信息文件 : {0}不存在!无法读取!", mVersionConfigFilePath));
        }
    }    
}