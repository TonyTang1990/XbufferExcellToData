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

        
        private t_AuthorInfoContainer t_AuthorInfoContainer = new t_AuthorInfoContainer();
        
        private t_AuthorInfo10Container t_AuthorInfo10Container = new t_AuthorInfo10Container();
        
        private t_AuthorInfo2Container t_AuthorInfo2Container = new t_AuthorInfo2Container();
        
        private t_AuthorInfo3Container t_AuthorInfo3Container = new t_AuthorInfo3Container();
        
        private t_AuthorInfo4Container t_AuthorInfo4Container = new t_AuthorInfo4Container();
        
        private t_AuthorInfo5Container t_AuthorInfo5Container = new t_AuthorInfo5Container();
        
        private t_AuthorInfo6Container t_AuthorInfo6Container = new t_AuthorInfo6Container();
        
        private t_AuthorInfo7Container t_AuthorInfo7Container = new t_AuthorInfo7Container();
        
        private t_AuthorInfo8Container t_AuthorInfo8Container = new t_AuthorInfo8Container();
        
        private t_AuthorInfo9Container t_AuthorInfo9Container = new t_AuthorInfo9Container();
        
        private t_global_bContainer t_global_bContainer = new t_global_bContainer();
        
        private t_Global10Container t_Global10Container = new t_Global10Container();
        
        private t_Global2Container t_Global2Container = new t_Global2Container();
        
        private t_Global3Container t_Global3Container = new t_Global3Container();
        
        private t_Global4Container t_Global4Container = new t_Global4Container();
        
        private t_Global5Container t_Global5Container = new t_Global5Container();
        
        private t_Global6Container t_Global6Container = new t_Global6Container();
        
        private t_Global7Container t_Global7Container = new t_Global7Container();
        
        private t_Global8Container t_Global8Container = new t_Global8Container();
        
        private t_Global9Container t_Global9Container = new t_Global9Container();
        
        private t_global_iContainer t_global_iContainer = new t_global_iContainer();
        
        private t_global_sContainer t_global_sContainer = new t_global_sContainer();
        
        private t_language_cnContainer t_language_cnContainer = new t_language_cnContainer();
        
        private t_uiContainer t_uiContainer = new t_uiContainer();
        

		private GameDataManager()
		{
		
		}

		public void loadAll()
		{
			
			t_AuthorInfoContainer.loadDataFromBin();
			
			t_AuthorInfo10Container.loadDataFromBin();
			
			t_AuthorInfo2Container.loadDataFromBin();
			
			t_AuthorInfo3Container.loadDataFromBin();
			
			t_AuthorInfo4Container.loadDataFromBin();
			
			t_AuthorInfo5Container.loadDataFromBin();
			
			t_AuthorInfo6Container.loadDataFromBin();
			
			t_AuthorInfo7Container.loadDataFromBin();
			
			t_AuthorInfo8Container.loadDataFromBin();
			
			t_AuthorInfo9Container.loadDataFromBin();
			
			t_global_bContainer.loadDataFromBin();
			
			t_Global10Container.loadDataFromBin();
			
			t_Global2Container.loadDataFromBin();
			
			t_Global3Container.loadDataFromBin();
			
			t_Global4Container.loadDataFromBin();
			
			t_Global5Container.loadDataFromBin();
			
			t_Global6Container.loadDataFromBin();
			
			t_Global7Container.loadDataFromBin();
			
			t_Global8Container.loadDataFromBin();
			
			t_Global9Container.loadDataFromBin();
			
			t_global_iContainer.loadDataFromBin();
			
			t_global_sContainer.loadDataFromBin();
			
			t_language_cnContainer.loadDataFromBin();
			
			t_uiContainer.loadDataFromBin();
			
		}

		
		public List<t_AuthorInfo> Gett_AuthorInfoList()
		{
			return t_AuthorInfoContainer.getList();
		}

		public Dictionary<int, t_AuthorInfo> Gett_AuthorInfoMap()
		{
			return t_AuthorInfoContainer.getMap();
		}
		
		public List<t_AuthorInfo10> Gett_AuthorInfo10List()
		{
			return t_AuthorInfo10Container.getList();
		}

		public Dictionary<int, t_AuthorInfo10> Gett_AuthorInfo10Map()
		{
			return t_AuthorInfo10Container.getMap();
		}
		
		public List<t_AuthorInfo2> Gett_AuthorInfo2List()
		{
			return t_AuthorInfo2Container.getList();
		}

		public Dictionary<int, t_AuthorInfo2> Gett_AuthorInfo2Map()
		{
			return t_AuthorInfo2Container.getMap();
		}
		
		public List<t_AuthorInfo3> Gett_AuthorInfo3List()
		{
			return t_AuthorInfo3Container.getList();
		}

		public Dictionary<int, t_AuthorInfo3> Gett_AuthorInfo3Map()
		{
			return t_AuthorInfo3Container.getMap();
		}
		
		public List<t_AuthorInfo4> Gett_AuthorInfo4List()
		{
			return t_AuthorInfo4Container.getList();
		}

		public Dictionary<int, t_AuthorInfo4> Gett_AuthorInfo4Map()
		{
			return t_AuthorInfo4Container.getMap();
		}
		
		public List<t_AuthorInfo5> Gett_AuthorInfo5List()
		{
			return t_AuthorInfo5Container.getList();
		}

		public Dictionary<int, t_AuthorInfo5> Gett_AuthorInfo5Map()
		{
			return t_AuthorInfo5Container.getMap();
		}
		
		public List<t_AuthorInfo6> Gett_AuthorInfo6List()
		{
			return t_AuthorInfo6Container.getList();
		}

		public Dictionary<int, t_AuthorInfo6> Gett_AuthorInfo6Map()
		{
			return t_AuthorInfo6Container.getMap();
		}
		
		public List<t_AuthorInfo7> Gett_AuthorInfo7List()
		{
			return t_AuthorInfo7Container.getList();
		}

		public Dictionary<int, t_AuthorInfo7> Gett_AuthorInfo7Map()
		{
			return t_AuthorInfo7Container.getMap();
		}
		
		public List<t_AuthorInfo8> Gett_AuthorInfo8List()
		{
			return t_AuthorInfo8Container.getList();
		}

		public Dictionary<int, t_AuthorInfo8> Gett_AuthorInfo8Map()
		{
			return t_AuthorInfo8Container.getMap();
		}
		
		public List<t_AuthorInfo9> Gett_AuthorInfo9List()
		{
			return t_AuthorInfo9Container.getList();
		}

		public Dictionary<int, t_AuthorInfo9> Gett_AuthorInfo9Map()
		{
			return t_AuthorInfo9Container.getMap();
		}
		
		public List<t_global_b> Gett_global_bList()
		{
			return t_global_bContainer.getList();
		}

		public Dictionary<string, t_global_b> Gett_global_bMap()
		{
			return t_global_bContainer.getMap();
		}
		
		public List<t_Global10> Gett_Global10List()
		{
			return t_Global10Container.getList();
		}

		public Dictionary<int, t_Global10> Gett_Global10Map()
		{
			return t_Global10Container.getMap();
		}
		
		public List<t_Global2> Gett_Global2List()
		{
			return t_Global2Container.getList();
		}

		public Dictionary<int, t_Global2> Gett_Global2Map()
		{
			return t_Global2Container.getMap();
		}
		
		public List<t_Global3> Gett_Global3List()
		{
			return t_Global3Container.getList();
		}

		public Dictionary<int, t_Global3> Gett_Global3Map()
		{
			return t_Global3Container.getMap();
		}
		
		public List<t_Global4> Gett_Global4List()
		{
			return t_Global4Container.getList();
		}

		public Dictionary<int, t_Global4> Gett_Global4Map()
		{
			return t_Global4Container.getMap();
		}
		
		public List<t_Global5> Gett_Global5List()
		{
			return t_Global5Container.getList();
		}

		public Dictionary<int, t_Global5> Gett_Global5Map()
		{
			return t_Global5Container.getMap();
		}
		
		public List<t_Global6> Gett_Global6List()
		{
			return t_Global6Container.getList();
		}

		public Dictionary<int, t_Global6> Gett_Global6Map()
		{
			return t_Global6Container.getMap();
		}
		
		public List<t_Global7> Gett_Global7List()
		{
			return t_Global7Container.getList();
		}

		public Dictionary<int, t_Global7> Gett_Global7Map()
		{
			return t_Global7Container.getMap();
		}
		
		public List<t_Global8> Gett_Global8List()
		{
			return t_Global8Container.getList();
		}

		public Dictionary<int, t_Global8> Gett_Global8Map()
		{
			return t_Global8Container.getMap();
		}
		
		public List<t_Global9> Gett_Global9List()
		{
			return t_Global9Container.getList();
		}

		public Dictionary<int, t_Global9> Gett_Global9Map()
		{
			return t_Global9Container.getMap();
		}
		
		public List<t_global_i> Gett_global_iList()
		{
			return t_global_iContainer.getList();
		}

		public Dictionary<string, t_global_i> Gett_global_iMap()
		{
			return t_global_iContainer.getMap();
		}
		
		public List<t_global_s> Gett_global_sList()
		{
			return t_global_sContainer.getList();
		}

		public Dictionary<string, t_global_s> Gett_global_sMap()
		{
			return t_global_sContainer.getMap();
		}
		
		public List<t_language_cn> Gett_language_cnList()
		{
			return t_language_cnContainer.getList();
		}

		public Dictionary<string, t_language_cn> Gett_language_cnMap()
		{
			return t_language_cnContainer.getMap();
		}
		
		public List<t_ui> Gett_uiList()
		{
			return t_uiContainer.getList();
		}

		public Dictionary<string, t_ui> Gett_uiMap()
		{
			return t_uiContainer.getMap();
		}
		
	}
}