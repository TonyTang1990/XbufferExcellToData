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
    public class t_AuthorInfoContainer
    {
        private List<t_AuthorInfo> list = null;
        private Dictionary<int, t_AuthorInfo> map = null;

        public List<t_AuthorInfo> GetList()
        {
            if (list == null || list.Count <= 0)
            {
                LoadDataFromBin();
            }
            return list;
        }

        public Dictionary<int, t_AuthorInfo> GetMap()
        {
            if (map == null || map.Count <= 0)
            {
                LoadDataFromBin();
            }
            return map;
        }

        public void ClearData()
        {
            if (list != null && list.Count > 0)
            {
                list.Clear();
            }
            if (map != null && map.Count > 0)
            {
                map.Clear();
            }
        }   

        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadDataFromBin()
        {
            Stream fs = ConfLoader.Singleton.GetStreamByteName(typeof(t_AuthorInfo).Name);
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
                                list =  new List<t_AuthorInfo>(count);             
                            }
                            if(map == null)
                            {
                                map = new Dictionary<int, t_AuthorInfo>(count);
                            }
                        }

                        var length = br.ReadInt32();
                        var data = br.ReadBytes(length);
                        var obj= t_AuthorInfoBuffer.Deserialize(data, ref offset);
                        offset = 0;
                        list.Add(obj);
                        map.Add(obj.Id, obj); 
                    }
                }catch (Exception ex)
                {
                    Debug.LogError("import data error: " + ex.ToString());
                }           
                br.Close();
                fs.Close();
            }
        }
    }
}