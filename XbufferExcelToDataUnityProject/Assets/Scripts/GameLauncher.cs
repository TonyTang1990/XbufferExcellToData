/*
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
            Debug.Log($"authorinfo.Id : {authorinfo.Id}");
            Debug.Log($"authorinfo.author : {authorinfo.author}");
            Debug.Log($"authorinfo.age : {authorinfo.age}");
            Debug.Log($"authorinfo.hashouse : {authorinfo.hashouse}");
            Debug.Log($"authorinfo.money : {authorinfo.money}");
            Debug.Log($"authorinfo.pbutctime : {authorinfo.pbutctime}");
            foreach (var lucknumber in authorinfo.luckynumber)
            {
                Debug.Log($"authorinfo.lucknumber : {lucknumber}");
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
            Debug.Log($"globalS.Key : {globalS.Value.Key}");
            Debug.Log($"globalS.Value : {globalS.Value.Value}");
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
            Debug.Log($"ui.WinName : {ui.Value.WinName}");
            Debug.Log($"ui.ResPath : {ui.Value.ResPath}");
            Debug.Log($"ui.TestSpace1 : {ui.Value.TestSpace1}");
            Debug.Log($"ui.IsFullScreen : {ui.Value.IsFullScreen}");
            Debug.Log($"ui.Layer : {ui.Value.Layer}");
            Debug.Log($"ui.TestSpace2 : {ui.Value.TestSpace2}");
            Debug.Log($"ui.TestByte : {ui.Value.TestByte}");
            for(int i = 0, length = ui.Value.TestByteArray.Length; i < length; i++)
            {
                Debug.Log($"ui.Value.TestByteArray[{i}] : {ui.Value.TestByteArray[i]}");
            }
            for (int i = 0, length = ui.Value.TestIntTwoArray.Length; i < length; i++)
            {
                for(int j = 0, length2 = ui.Value.TestIntTwoArray[i].Length; j < length2; j++)
                {
                    Debug.Log($"ui.Value.TestIntTwoArray[{i}][{j}] : {ui.Value.TestIntTwoArray[i][j]}");
                }
            }
            for (int i = 0, length = ui.Value.TestStringTwoArray.Length; i < length; i++)
            {
                for (int j = 0, length2 = ui.Value.TestStringTwoArray[i].Length; j < length2; j++)
                {
                    Debug.Log($"ui.Value.TestStringTwoArray[{i}][{j}] : {ui.Value.TestStringTwoArray[i][j]}");
                }
            }
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
            Debug.Log($"ui.Key : {languageCn.Value.Key}");
            Debug.Log($"ui.Value : {languageCn.Value.Value}");
        }
    }
}
