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

        
        private t_AuthorInfoContainer mt_AuthorInfoContainer = new t_AuthorInfoContainer();
        
        private t_AuthorInfo10Container mt_AuthorInfo10Container = new t_AuthorInfo10Container();
        
        private t_AuthorInfo2Container mt_AuthorInfo2Container = new t_AuthorInfo2Container();
        
        private t_AuthorInfo3Container mt_AuthorInfo3Container = new t_AuthorInfo3Container();
        
        private t_AuthorInfo4Container mt_AuthorInfo4Container = new t_AuthorInfo4Container();
        
        private t_AuthorInfo5Container mt_AuthorInfo5Container = new t_AuthorInfo5Container();
        
        private t_AuthorInfo6Container mt_AuthorInfo6Container = new t_AuthorInfo6Container();
        
        private t_AuthorInfo7Container mt_AuthorInfo7Container = new t_AuthorInfo7Container();
        
        private t_AuthorInfo8Container mt_AuthorInfo8Container = new t_AuthorInfo8Container();
        
        private t_AuthorInfo9Container mt_AuthorInfo9Container = new t_AuthorInfo9Container();
        
        private t_global_bContainer mt_global_bContainer = new t_global_bContainer();
        
        private t_Global10Container mt_Global10Container = new t_Global10Container();
        
        private t_Global2Container mt_Global2Container = new t_Global2Container();
        
        private t_Global3Container mt_Global3Container = new t_Global3Container();
        
        private t_Global4Container mt_Global4Container = new t_Global4Container();
        
        private t_Global5Container mt_Global5Container = new t_Global5Container();
        
        private t_Global6Container mt_Global6Container = new t_Global6Container();
        
        private t_Global7Container mt_Global7Container = new t_Global7Container();
        
        private t_Global8Container mt_Global8Container = new t_Global8Container();
        
        private t_Global9Container mt_Global9Container = new t_Global9Container();
        
        private t_global_iContainer mt_global_iContainer = new t_global_iContainer();
        
        private t_global_sContainer mt_global_sContainer = new t_global_sContainer();
        
        private t_languageContainer mt_languageContainer = new t_languageContainer();
        
        private t_language_cnContainer mt_language_cnContainer = new t_language_cnContainer();
        
        private t_uiContainer mt_uiContainer = new t_uiContainer();
        

		private GameDataManager()
		{
		
		}

		public void LoadAll()
		{
			
			Loadt_AuthorInfoData();
			
			Loadt_AuthorInfo10Data();
			
			Loadt_AuthorInfo2Data();
			
			Loadt_AuthorInfo3Data();
			
			Loadt_AuthorInfo4Data();
			
			Loadt_AuthorInfo5Data();
			
			Loadt_AuthorInfo6Data();
			
			Loadt_AuthorInfo7Data();
			
			Loadt_AuthorInfo8Data();
			
			Loadt_AuthorInfo9Data();
			
			Loadt_global_bData();
			
			Loadt_Global10Data();
			
			Loadt_Global2Data();
			
			Loadt_Global3Data();
			
			Loadt_Global4Data();
			
			Loadt_Global5Data();
			
			Loadt_Global6Data();
			
			Loadt_Global7Data();
			
			Loadt_Global8Data();
			
			Loadt_Global9Data();
			
			Loadt_global_iData();
			
			Loadt_global_sData();
			
			Loadt_languageData();
			
			Loadt_language_cnData();
			
			Loadt_uiData();
			
		}

		
		public void Loadt_AuthorInfoData()
		{
			mt_AuthorInfoContainer.LoadDataFromBin();
		}

		public List<t_AuthorInfo> Gett_AuthorInfoList()
		{
			return mt_AuthorInfoContainer.GetList();
		}

		public Dictionary<int, t_AuthorInfo> Gett_AuthorInfoMap()
		{
			return mt_AuthorInfoContainer.GetMap();
		}
		
		public void Loadt_AuthorInfo10Data()
		{
			mt_AuthorInfo10Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo10> Gett_AuthorInfo10List()
		{
			return mt_AuthorInfo10Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo10> Gett_AuthorInfo10Map()
		{
			return mt_AuthorInfo10Container.GetMap();
		}
		
		public void Loadt_AuthorInfo2Data()
		{
			mt_AuthorInfo2Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo2> Gett_AuthorInfo2List()
		{
			return mt_AuthorInfo2Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo2> Gett_AuthorInfo2Map()
		{
			return mt_AuthorInfo2Container.GetMap();
		}
		
		public void Loadt_AuthorInfo3Data()
		{
			mt_AuthorInfo3Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo3> Gett_AuthorInfo3List()
		{
			return mt_AuthorInfo3Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo3> Gett_AuthorInfo3Map()
		{
			return mt_AuthorInfo3Container.GetMap();
		}
		
		public void Loadt_AuthorInfo4Data()
		{
			mt_AuthorInfo4Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo4> Gett_AuthorInfo4List()
		{
			return mt_AuthorInfo4Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo4> Gett_AuthorInfo4Map()
		{
			return mt_AuthorInfo4Container.GetMap();
		}
		
		public void Loadt_AuthorInfo5Data()
		{
			mt_AuthorInfo5Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo5> Gett_AuthorInfo5List()
		{
			return mt_AuthorInfo5Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo5> Gett_AuthorInfo5Map()
		{
			return mt_AuthorInfo5Container.GetMap();
		}
		
		public void Loadt_AuthorInfo6Data()
		{
			mt_AuthorInfo6Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo6> Gett_AuthorInfo6List()
		{
			return mt_AuthorInfo6Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo6> Gett_AuthorInfo6Map()
		{
			return mt_AuthorInfo6Container.GetMap();
		}
		
		public void Loadt_AuthorInfo7Data()
		{
			mt_AuthorInfo7Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo7> Gett_AuthorInfo7List()
		{
			return mt_AuthorInfo7Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo7> Gett_AuthorInfo7Map()
		{
			return mt_AuthorInfo7Container.GetMap();
		}
		
		public void Loadt_AuthorInfo8Data()
		{
			mt_AuthorInfo8Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo8> Gett_AuthorInfo8List()
		{
			return mt_AuthorInfo8Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo8> Gett_AuthorInfo8Map()
		{
			return mt_AuthorInfo8Container.GetMap();
		}
		
		public void Loadt_AuthorInfo9Data()
		{
			mt_AuthorInfo9Container.LoadDataFromBin();
		}

		public List<t_AuthorInfo9> Gett_AuthorInfo9List()
		{
			return mt_AuthorInfo9Container.GetList();
		}

		public Dictionary<int, t_AuthorInfo9> Gett_AuthorInfo9Map()
		{
			return mt_AuthorInfo9Container.GetMap();
		}
		
		public void Loadt_global_bData()
		{
			mt_global_bContainer.LoadDataFromBin();
		}

		public List<t_global_b> Gett_global_bList()
		{
			return mt_global_bContainer.GetList();
		}

		public Dictionary<string, t_global_b> Gett_global_bMap()
		{
			return mt_global_bContainer.GetMap();
		}
		
		public void Loadt_Global10Data()
		{
			mt_Global10Container.LoadDataFromBin();
		}

		public List<t_Global10> Gett_Global10List()
		{
			return mt_Global10Container.GetList();
		}

		public Dictionary<int, t_Global10> Gett_Global10Map()
		{
			return mt_Global10Container.GetMap();
		}
		
		public void Loadt_Global2Data()
		{
			mt_Global2Container.LoadDataFromBin();
		}

		public List<t_Global2> Gett_Global2List()
		{
			return mt_Global2Container.GetList();
		}

		public Dictionary<int, t_Global2> Gett_Global2Map()
		{
			return mt_Global2Container.GetMap();
		}
		
		public void Loadt_Global3Data()
		{
			mt_Global3Container.LoadDataFromBin();
		}

		public List<t_Global3> Gett_Global3List()
		{
			return mt_Global3Container.GetList();
		}

		public Dictionary<int, t_Global3> Gett_Global3Map()
		{
			return mt_Global3Container.GetMap();
		}
		
		public void Loadt_Global4Data()
		{
			mt_Global4Container.LoadDataFromBin();
		}

		public List<t_Global4> Gett_Global4List()
		{
			return mt_Global4Container.GetList();
		}

		public Dictionary<int, t_Global4> Gett_Global4Map()
		{
			return mt_Global4Container.GetMap();
		}
		
		public void Loadt_Global5Data()
		{
			mt_Global5Container.LoadDataFromBin();
		}

		public List<t_Global5> Gett_Global5List()
		{
			return mt_Global5Container.GetList();
		}

		public Dictionary<int, t_Global5> Gett_Global5Map()
		{
			return mt_Global5Container.GetMap();
		}
		
		public void Loadt_Global6Data()
		{
			mt_Global6Container.LoadDataFromBin();
		}

		public List<t_Global6> Gett_Global6List()
		{
			return mt_Global6Container.GetList();
		}

		public Dictionary<int, t_Global6> Gett_Global6Map()
		{
			return mt_Global6Container.GetMap();
		}
		
		public void Loadt_Global7Data()
		{
			mt_Global7Container.LoadDataFromBin();
		}

		public List<t_Global7> Gett_Global7List()
		{
			return mt_Global7Container.GetList();
		}

		public Dictionary<int, t_Global7> Gett_Global7Map()
		{
			return mt_Global7Container.GetMap();
		}
		
		public void Loadt_Global8Data()
		{
			mt_Global8Container.LoadDataFromBin();
		}

		public List<t_Global8> Gett_Global8List()
		{
			return mt_Global8Container.GetList();
		}

		public Dictionary<int, t_Global8> Gett_Global8Map()
		{
			return mt_Global8Container.GetMap();
		}
		
		public void Loadt_Global9Data()
		{
			mt_Global9Container.LoadDataFromBin();
		}

		public List<t_Global9> Gett_Global9List()
		{
			return mt_Global9Container.GetList();
		}

		public Dictionary<int, t_Global9> Gett_Global9Map()
		{
			return mt_Global9Container.GetMap();
		}
		
		public void Loadt_global_iData()
		{
			mt_global_iContainer.LoadDataFromBin();
		}

		public List<t_global_i> Gett_global_iList()
		{
			return mt_global_iContainer.GetList();
		}

		public Dictionary<string, t_global_i> Gett_global_iMap()
		{
			return mt_global_iContainer.GetMap();
		}
		
		public void Loadt_global_sData()
		{
			mt_global_sContainer.LoadDataFromBin();
		}

		public List<t_global_s> Gett_global_sList()
		{
			return mt_global_sContainer.GetList();
		}

		public Dictionary<string, t_global_s> Gett_global_sMap()
		{
			return mt_global_sContainer.GetMap();
		}
		
		public void Loadt_languageData()
		{
			mt_languageContainer.LoadDataFromBin();
		}

		public List<t_language> Gett_languageList()
		{
			return mt_languageContainer.GetList();
		}

		public Dictionary<string, t_language> Gett_languageMap()
		{
			return mt_languageContainer.GetMap();
		}
		
		public void Loadt_language_cnData()
		{
			mt_language_cnContainer.LoadDataFromBin();
		}

		public List<t_language_cn> Gett_language_cnList()
		{
			return mt_language_cnContainer.GetList();
		}

		public Dictionary<string, t_language_cn> Gett_language_cnMap()
		{
			return mt_language_cnContainer.GetMap();
		}
		
		public void Loadt_uiData()
		{
			mt_uiContainer.LoadDataFromBin();
		}

		public List<t_ui> Gett_uiList()
		{
			return mt_uiContainer.GetList();
		}

		public Dictionary<string, t_ui> Gett_uiMap()
		{
			return mt_uiContainer.GetMap();
		}
		
	}
}