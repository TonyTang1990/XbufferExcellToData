/**
 * Auto generated by XbufferExcelToData, do not edit it 
 * 表格名字
 */
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using xbuffer;

namespace Data
{
    /// <summary>
    /// #LOOP_CLASS_NAME#数据容器类
    /// </summary>
    public class t_global_sContainer
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        private List<t_global_s> list = null;

        /// <summary>
        /// 数据Map<ID, 数据>
        /// </summary>
        private Dictionary<string, t_global_s> map = null;

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<t_global_s> GetList()
        {
            if (list == null)
            {
                LoadDataFromBin();
            }
            return list;
        }

        /// <summary>
        /// 获取数据Map
        /// </summary>
        public Dictionary<string, t_global_s> GetMap()
        {
            if (map == null)
            {
                LoadDataFromBin();
            }
            return map;
        }

        /// <summary>
        /// 加载配置数据
        /// </summary>
        public void LoadDataFromBin()
        {
            Stream fs = ConfLoader.Singleton.GetStreamByteName(typeof(t_global_s).Name);
            if(fs != null)
            {
                BinaryReader br = new BinaryReader(fs);
                uint offset = 0;
                bool frist = true;
                try{
                    while (fs.Length - fs.Position > 0)
                    {
                        if (frist)
                        {
                            frist = false;
                            ClearData();
                            var count = br.ReadInt32();
                            if(list == null)
                            {
                                list =  new List<t_global_s>(count);             
                            }
                            if(map == null)
                            {
                                map = new Dictionary<string, t_global_s>(count);
                            }
                        }

                        var length = br.ReadInt32();
                        var data = br.ReadBytes(length);
                        var obj= t_global_sBuffer.Deserialize(data, ref offset);
                        offset = 0;
                        list.Add(obj);
                        map.Add(obj.Key, obj); 
                    }
                }catch (Exception ex)
                {
                    Debug.LogError("import data error: " + ex.ToString());
                }           
                br.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 清除数据Map
        /// </summary>
        private void ClearData()
        {
            if (list != null)
            {
                list.Clear();
            }
            if (map != null)
            {
                map.Clear();
            }
        }
    }
}