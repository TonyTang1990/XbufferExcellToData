/**
 * Auto generated by XbufferExcelToData, do not edit it 
 * 表格名字
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;
using xbuffer;

namespace Data
{
    /// <summary>
    /// #LOOP_CLASS_NAME#数据容器类
    /// </summary>
    public class t_Global9Container
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        private List<t_Global9> list = null;

        /// <summary>
        /// 只读数据列表
        /// </summary>
        private ReadOnlyCollection<t_Global9> readOnlyList = null;

        /// <summary>
        /// 数据Map<ID, 数据>
        /// </summary>
        private Dictionary<int, t_Global9> map = null;

        /// <summary>
        /// 只读数据Map<ID, 数据>
        /// </summary>
        private ReadOnlyDictionary<int, t_Global9> readOnlyMap = null;

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public ReadOnlyCollection<t_Global9> GetList()
        {
            if (readOnlyList == null)
            {
                LoadDataFromBin();
            }
            return readOnlyList;
        }

        /// <summary>
        /// 获取数据Map
        /// </summary>
        public ReadOnlyDictionary<int, t_Global9> GetMap()
        {
            if (readOnlyMap == null)
            {
                LoadDataFromBin();
            }
            return readOnlyMap;
        }

        /// <summary>
        /// 加载配置数据
        /// </summary>
        public void LoadDataFromBin()
        {
            Stream fs = ConfLoader.Singleton.GetStreamByteName(typeof(t_Global9).Name);
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
                                list =  new List<t_Global9>(count);             
                            }
                            if(map == null)
                            {
                                map = new Dictionary<int, t_Global9>(count);
                            }
                        }

                        var length = br.ReadInt32();
                        var data = br.ReadBytes(length);
                        var obj= t_Global9Buffer.Deserialize(data, ref offset);
                        offset = 0;
                        list.Add(obj);
                        map.Add(obj.Id, obj); 
                    }
                    readOnlyList = new ReadOnlyCollection<t_Global9>(list);
                    readOnlyMap = new ReadOnlyDictionary<int, t_Global9>(map);
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
            if (readOnlyList != null)
            {
                list.Clear();
                readOnlyList = null;
            }
            if (readOnlyMap != null)
            {
                map.Clear();
                readOnlyMap = null;
            }
        }
    }
}