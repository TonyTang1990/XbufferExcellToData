/**
 * Auto generated, do not edit it
 */
using System.Collections.Generic;
using xbuffer;

namespace Data
{
    public class GameDataManager
    {
		public static readonly GameDataManager Singleton = new GameDataManager();

        #CONTAINER_MEMBER_LOOP#
        private #CLASS_NAME#Container m#CLASS_NAME#Container = new #CLASS_NAME#Container();
        #CONTAINER_MEMBER_LOOP#

		private GameDataManager()
		{
		
		}

		public void LoadAll()
		{
			#CONTAINER_LOAD_LOOP#
			Load#LOOP_CLASS_NAME#Data();
			#CONTAINER_LOAD_LOOP#
		}

		#CONTAINER_GET_LOOP#
		public void Load#LOOP_CLASS_NAME#Data()
		{
			m#LOOP_CLASS_NAME#Container.LoadDataFromBin();
		}

		public List<#LOOP_CLASS_NAME#> Get#LOOP_CLASS_NAME#List()
		{
			return m#LOOP_CLASS_NAME#Container.GetList();
		}

		public Dictionary<#ID_TYPE#, #LOOP_CLASS_NAME#> Get#LOOP_CLASS_NAME#Map()
		{
			return m#LOOP_CLASS_NAME#Container.GetMap();
		}
		#CONTAINER_GET_LOOP#
	}
}