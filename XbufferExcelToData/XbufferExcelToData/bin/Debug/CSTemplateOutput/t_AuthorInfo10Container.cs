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
    public class t_AuthorInfo10Container
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        private List<t_AuthorInfo10> list = null;

        /// <summary>
        /// 只读数据列表
        /// </summary>
        private ReadOnlyCollection<t_AuthorInfo10> readOnlyList = null;

        /// <summary>
        /// 数据Map<ID, 数据>
        /// </summary>
        private Dictionary<int, t_AuthorInfo10> map = null;

        /// <summary>
        /// 只读数据Map<ID, 数据>
        /// </summary>
        private ReadOnlyDictionary<int, t_AuthorInfo10> readOnlyMap = null;

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public ReadOnlyCollection<t_AuthorInfo10> GetList()
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
        public ReadOnlyDictionary<int, t_AuthorInfo10> GetMap()
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
            Stream fs = ConfLoader.Singleton.GetStreamByteName(typeof(t_AuthorInfo10).Name);
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
                                list =  new List<t_AuthorInfo10>(count);             
                            }
                            if(map == null)
                            {
                                map = new Dictionary<int, t_AuthorInfo10>(count);
                            }
                        }

                        var length = br.ReadInt32();
                        var data = br.ReadBytes(length);
                        var obj= t_AuthorInfo10Buffer.Deserialize(data, ref offset);
                        offset = 0;
                        list.Add(obj);
                        map.Add(obj.Id, obj); 
                    }
                    readOnlyList = new ReadOnlyCollection<t_AuthorInfo10>(list);
                    readOnlyMap = new ReadOnlyDictionary<int, t_AuthorInfo10>(map);
                    list.Clear();
                    map.Clear();
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