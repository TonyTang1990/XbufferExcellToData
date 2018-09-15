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

        addMonoComponents();

        nativeInitilization();
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
    private void addMonoComponents()
    {

    }

    /// <summary>
    /// 原生初始化
    /// </summary>
    private void nativeInitilization()
    {

    }
    
    /// <summary>
    /// 加载所有Excel数据
    /// </summary>
    public void onLoadAllExcelData()
    {
        Debug.Log("onLoadAllExcelData()");
        TimeCounter.Singleton.Restart("LoadAllExcelData()");
        MonoMemoryProfiler.Singleton.beginMemorySample("LoadAllExcelData()");
        GameDataManager.Instance.loadAll();
        MonoMemoryProfiler.Singleton.endMemorySample();
        TimeCounter.Singleton.End();
    }

    /// <summary>
    /// 打印AuthorInfo表格Excel数据
    /// </summary>
    public void onPrintAuthorInfoExcelData()
    {
        Debug.Log("onPrintAuthorInfoExcelData()");
        foreach(var authorinfo in GameDataManager.Instance.t_AuthorInfocontainer.getList())
        {
            Debug.Log(string.Format("authorinfo.id : {0}", authorinfo.id));
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
}
