/**
 * Auto generated, do not edit it
 */
using System.Collections.Generic;
using xbuffer;

namespace Data
{
	/// <summary>
	/// 数据管理类
	/// </summary>
    public class GameDataManager
    {
		/// <summary>
		/// 数据管理单例对象
		/// </summary>
		public static readonly GameDataManager Singleton = new GameDataManager();

        #CONTAINER_MEMBER_LOOP#
		/// <summary>
		/// #CLASS_NAME#配置容器对象
		/// </summary>
        private #CLASS_NAME#Container m#CLASS_NAME#Container = new #CLASS_NAME#Container();
        #CONTAINER_MEMBER_LOOP#

		private GameDataManager()
		{
		
		}

		/// <summary>
		/// 加载所有配置数据
		/// </summary>
		public void LoadAll()
		{
			#CONTAINER_LOAD_LOOP#
			Load#LOOP_CLASS_NAME#Data();
			#CONTAINER_LOAD_LOOP#
		}

		#CONTAINER_GET_LOOP#
		/// <summary>
		/// 加载#LOOP_CLASS_NAME#配置数据
		/// </summary>
		public void Load#LOOP_CLASS_NAME#Data()
		{
			m#LOOP_CLASS_NAME#Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取#LOOP_CLASS_NAME#数据列表
		/// </summary>
		public List<#LOOP_CLASS_NAME#> Get#LOOP_CLASS_NAME#List()
		{
			return m#LOOP_CLASS_NAME#Container.GetList();
		}

		/// <summary>
		/// 获取#LOOP_CLASS_NAME#数据Map
		/// </summary>
		public Dictionary<#ID_TYPE#, #LOOP_CLASS_NAME#> Get#LOOP_CLASS_NAME#Map()
		{
			return m#LOOP_CLASS_NAME#Container.GetMap();
		}
		#CONTAINER_GET_LOOP#
	}
}