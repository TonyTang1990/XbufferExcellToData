﻿/*
 * Description:             游戏入口
 * Author:                  tanghuan
 * Create Date:             2018/03/12
 */

using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 游戏入口
/// </summary>
public class GameLauncher : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this);

        VisibleLogUtility visiblelog = gameObject.AddComponent<VisibleLogUtility>();
        visiblelog.setInstance(visiblelog);
        VisibleLogUtility.getInstance().mVisibleLogSwitch = FastUIEntry.LogSwitch;
        Application.logMessageReceived += VisibleLogUtility.getInstance().HandleLog;

        AddMonoComponents();

        NativeInitilization();
    }

    private void Start () {
        Debug.Log("ExportExcelDataTool");
        MonoMemoryProfiler.Singleton.beginMemorySample("GameLaucher:Start()");
        MonoMemoryProfiler.Singleton.endMemorySample();
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= VisibleLogUtility.getInstance().HandleLog;
    }

    /// <summary>
    /// 添加Mono相关的组件
    /// </summary>
    private void AddMonoComponents()
    {

    }

    /// <summary>
    /// 原生初始化
    /// </summary>
    private void NativeInitilization()
    {

    }
    
    /// <summary>
    /// 加载所有Excel数据
    /// </summary>
    public void OnLoadAllExcelData()
    {
        Debug.Log("OnLoadAllExcelData()");
        TimeCounter.Singleton.Restart("LoadAllExcelData()");
        MonoMemoryProfiler.Singleton.beginMemorySample("LoadAllExcelData()");
        GameDataManager.Singleton.LoadAll();
        MonoMemoryProfiler.Singleton.endMemorySample();
        TimeCounter.Singleton.End();
    }

    /// <summary>
    /// 打印AuthorInfo表格Excel数据
    /// </summary>
    public void OnPrintAuthorInfoExcelData()
    {
        Debug.Log("OnPrintAuthorInfoExcelData()");
        foreach(var authorinfo in GameDataManager.Singleton.Gett_AuthorInfoList())
        {
            Debug.Log(string.Format("authorinfo.Id : {0}", authorinfo.Id));
            Debug.Log(string.Format("authorinfo.author : {0}", authorinfo.author));
            Debug.Log(string.Format("authorinfo.age : {0}", authorinfo.age));
            Debug.Log(string.Format("authorinfo.hashouse : {0}", authorinfo.hashouse));
            Debug.Log(string.Format("authorinfo.money : {0}", authorinfo.money));
            Debug.Log(string.Format("authorinfo.pbutctime : {0}", authorinfo.pbutctime));
            foreach (var lucknumber in authorinfo.luckynumber)
            {
                Debug.Log(string.Format("authorinfo.lucknumber : {0}", lucknumber));
            }
        }
    }

    /// <summary>
    /// 打印GlobalS
    /// </summary>
    public void OnPrintGlobal_SExcelData()
    {
        Debug.Log("OnPrintAuthorInfoExcelData()");
        foreach (var globalS in GameDataManager.Singleton.Gett_global_sMap())
        {
            Debug.Log(string.Format("globalS.Key : {0}", globalS.Value.Key));
            Debug.Log(string.Format("globalS.Value : {0}", globalS.Value.Value));
        }
    }

    /// <summary>
    /// 打印UI表
    /// </summary>
    public void OnPrintUIExcelData()
    {
        Debug.Log("OnPrintUIExcelData()");
        foreach (var ui in GameDataManager.Singleton.Gett_uiMap())
        {
            Debug.Log(string.Format("ui.WinName : {0}", ui.Value.WinName));
            Debug.Log(string.Format("ui.ResPath : {0}", ui.Value.ResPath));
            Debug.Log(string.Format("ui.IsFullScreen : {0}", ui.Value.IsFullScreen));
            Debug.Log(string.Format("ui.Layer : {0}", ui.Value.Layer));
        }
    }

    /// <summary>
    /// 打印语言表
    /// </summary>
    public void OnPrintLanguageExcelData()
    {
        Debug.Log("OnPrintLanguageExcelData()");
        foreach (var languageCn in GameDataManager.Singleton.Gett_language_cnMap())
        {
            Debug.Log(string.Format("ui.Key : {0}", languageCn.Value.Key));
            Debug.Log(string.Format("ui.Value : {0}", languageCn.Value.Value));
        }
    }
}
