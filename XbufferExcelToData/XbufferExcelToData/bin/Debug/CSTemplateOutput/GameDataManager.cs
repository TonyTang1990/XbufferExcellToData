/**
 * Auto generated, do not edit it
 */
using xbuffer;

namespace Data
{
    public class GameDataManager
    {
		public static readonly GameDataManager Instance = new GameDataManager();

        
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
        
        private t_globalContainer mt_globalContainer = new t_globalContainer();
        
        private t_Global10Container mt_Global10Container = new t_Global10Container();
        
        private t_Global2Container mt_Global2Container = new t_Global2Container();
        
        private t_Global3Container mt_Global3Container = new t_Global3Container();
        
        private t_Global4Container mt_Global4Container = new t_Global4Container();
        
        private t_Global5Container mt_Global5Container = new t_Global5Container();
        
        private t_Global6Container mt_Global6Container = new t_Global6Container();
        
        private t_Global7Container mt_Global7Container = new t_Global7Container();
        
        private t_Global8Container mt_Global8Container = new t_Global8Container();
        
        private t_Global9Container mt_Global9Container = new t_Global9Container();
        
        private t_languageContainer mt_languageContainer = new t_languageContainer();
        
        private t_uiContainer mt_uiContainer = new t_uiContainer();
        

		private GameDataManager()
		{
		
		}

		public void loadAll()
		{
			
			mt_AuthorInfoContainer.loadDataFromBin();
			
			mt_AuthorInfo10Container.loadDataFromBin();
			
			mt_AuthorInfo2Container.loadDataFromBin();
			
			mt_AuthorInfo3Container.loadDataFromBin();
			
			mt_AuthorInfo4Container.loadDataFromBin();
			
			mt_AuthorInfo5Container.loadDataFromBin();
			
			mt_AuthorInfo6Container.loadDataFromBin();
			
			mt_AuthorInfo7Container.loadDataFromBin();
			
			mt_AuthorInfo8Container.loadDataFromBin();
			
			mt_AuthorInfo9Container.loadDataFromBin();
			
			mt_globalContainer.loadDataFromBin();
			
			mt_Global10Container.loadDataFromBin();
			
			mt_Global2Container.loadDataFromBin();
			
			mt_Global3Container.loadDataFromBin();
			
			mt_Global4Container.loadDataFromBin();
			
			mt_Global5Container.loadDataFromBin();
			
			mt_Global6Container.loadDataFromBin();
			
			mt_Global7Container.loadDataFromBin();
			
			mt_Global8Container.loadDataFromBin();
			
			mt_Global9Container.loadDataFromBin();
			
			mt_languageContainer.loadDataFromBin();
			
			mt_uiContainer.loadDataFromBin();
			
		}

		
		public t_AuthorInfoContainer[] Gett_AuthorInfoList()
		{
			return mt_AuthorInfoContainer.getList();
		}

		public Dictionary<int, t_AuthorInfoContainer> Gett_AuthorInfoMap()
		{
			return mt_AuthorInfoContainer.getMap();
		}
		
		public t_AuthorInfo10Container[] Gett_AuthorInfo10List()
		{
			return mt_AuthorInfo10Container.getList();
		}

		public Dictionary<int, t_AuthorInfo10Container> Gett_AuthorInfo10Map()
		{
			return mt_AuthorInfo10Container.getMap();
		}
		
		public t_AuthorInfo2Container[] Gett_AuthorInfo2List()
		{
			return mt_AuthorInfo2Container.getList();
		}

		public Dictionary<int, t_AuthorInfo2Container> Gett_AuthorInfo2Map()
		{
			return mt_AuthorInfo2Container.getMap();
		}
		
		public t_AuthorInfo3Container[] Gett_AuthorInfo3List()
		{
			return mt_AuthorInfo3Container.getList();
		}

		public Dictionary<int, t_AuthorInfo3Container> Gett_AuthorInfo3Map()
		{
			return mt_AuthorInfo3Container.getMap();
		}
		
		public t_AuthorInfo4Container[] Gett_AuthorInfo4List()
		{
			return mt_AuthorInfo4Container.getList();
		}

		public Dictionary<int, t_AuthorInfo4Container> Gett_AuthorInfo4Map()
		{
			return mt_AuthorInfo4Container.getMap();
		}
		
		public t_AuthorInfo5Container[] Gett_AuthorInfo5List()
		{
			return mt_AuthorInfo5Container.getList();
		}

		public Dictionary<int, t_AuthorInfo5Container> Gett_AuthorInfo5Map()
		{
			return mt_AuthorInfo5Container.getMap();
		}
		
		public t_AuthorInfo6Container[] Gett_AuthorInfo6List()
		{
			return mt_AuthorInfo6Container.getList();
		}

		public Dictionary<int, t_AuthorInfo6Container> Gett_AuthorInfo6Map()
		{
			return mt_AuthorInfo6Container.getMap();
		}
		
		public t_AuthorInfo7Container[] Gett_AuthorInfo7List()
		{
			return mt_AuthorInfo7Container.getList();
		}

		public Dictionary<int, t_AuthorInfo7Container> Gett_AuthorInfo7Map()
		{
			return mt_AuthorInfo7Container.getMap();
		}
		
		public t_AuthorInfo8Container[] Gett_AuthorInfo8List()
		{
			return mt_AuthorInfo8Container.getList();
		}

		public Dictionary<int, t_AuthorInfo8Container> Gett_AuthorInfo8Map()
		{
			return mt_AuthorInfo8Container.getMap();
		}
		
		public t_AuthorInfo9Container[] Gett_AuthorInfo9List()
		{
			return mt_AuthorInfo9Container.getList();
		}

		public Dictionary<int, t_AuthorInfo9Container> Gett_AuthorInfo9Map()
		{
			return mt_AuthorInfo9Container.getMap();
		}
		
		public t_globalContainer[] Gett_globalList()
		{
			return mt_globalContainer.getList();
		}

		public Dictionary<int, t_globalContainer> Gett_globalMap()
		{
			return mt_globalContainer.getMap();
		}
		
		public t_Global10Container[] Gett_Global10List()
		{
			return mt_Global10Container.getList();
		}

		public Dictionary<int, t_Global10Container> Gett_Global10Map()
		{
			return mt_Global10Container.getMap();
		}
		
		public t_Global2Container[] Gett_Global2List()
		{
			return mt_Global2Container.getList();
		}

		public Dictionary<int, t_Global2Container> Gett_Global2Map()
		{
			return mt_Global2Container.getMap();
		}
		
		public t_Global3Container[] Gett_Global3List()
		{
			return mt_Global3Container.getList();
		}

		public Dictionary<int, t_Global3Container> Gett_Global3Map()
		{
			return mt_Global3Container.getMap();
		}
		
		public t_Global4Container[] Gett_Global4List()
		{
			return mt_Global4Container.getList();
		}

		public Dictionary<int, t_Global4Container> Gett_Global4Map()
		{
			return mt_Global4Container.getMap();
		}
		
		public t_Global5Container[] Gett_Global5List()
		{
			return mt_Global5Container.getList();
		}

		public Dictionary<int, t_Global5Container> Gett_Global5Map()
		{
			return mt_Global5Container.getMap();
		}
		
		public t_Global6Container[] Gett_Global6List()
		{
			return mt_Global6Container.getList();
		}

		public Dictionary<int, t_Global6Container> Gett_Global6Map()
		{
			return mt_Global6Container.getMap();
		}
		
		public t_Global7Container[] Gett_Global7List()
		{
			return mt_Global7Container.getList();
		}

		public Dictionary<int, t_Global7Container> Gett_Global7Map()
		{
			return mt_Global7Container.getMap();
		}
		
		public t_Global8Container[] Gett_Global8List()
		{
			return mt_Global8Container.getList();
		}

		public Dictionary<int, t_Global8Container> Gett_Global8Map()
		{
			return mt_Global8Container.getMap();
		}
		
		public t_Global9Container[] Gett_Global9List()
		{
			return mt_Global9Container.getList();
		}

		public Dictionary<int, t_Global9Container> Gett_Global9Map()
		{
			return mt_Global9Container.getMap();
		}
		
		public t_languageContainer[] Gett_languageList()
		{
			return mt_languageContainer.getList();
		}

		public Dictionary<string, t_languageContainer> Gett_languageMap()
		{
			return mt_languageContainer.getMap();
		}
		
		public t_uiContainer[] Gett_uiList()
		{
			return mt_uiContainer.getList();
		}

		public Dictionary<string, t_uiContainer> Gett_uiMap()
		{
			return mt_uiContainer.getMap();
		}
		
	}
}