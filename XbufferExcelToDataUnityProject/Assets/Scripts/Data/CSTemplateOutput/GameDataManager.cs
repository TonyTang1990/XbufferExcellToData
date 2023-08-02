/**
 * Auto generated, do not edit it
 */
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        
		/// <summary>
		/// t_AuthorInfo配置容器对象
		/// </summary>
        private t_AuthorInfoContainer mt_AuthorInfoContainer = new t_AuthorInfoContainer();
        
		/// <summary>
		/// t_AuthorInfo10配置容器对象
		/// </summary>
        private t_AuthorInfo10Container mt_AuthorInfo10Container = new t_AuthorInfo10Container();
        
		/// <summary>
		/// t_AuthorInfo2配置容器对象
		/// </summary>
        private t_AuthorInfo2Container mt_AuthorInfo2Container = new t_AuthorInfo2Container();
        
		/// <summary>
		/// t_AuthorInfo3配置容器对象
		/// </summary>
        private t_AuthorInfo3Container mt_AuthorInfo3Container = new t_AuthorInfo3Container();
        
		/// <summary>
		/// t_AuthorInfo4配置容器对象
		/// </summary>
        private t_AuthorInfo4Container mt_AuthorInfo4Container = new t_AuthorInfo4Container();
        
		/// <summary>
		/// t_AuthorInfo5配置容器对象
		/// </summary>
        private t_AuthorInfo5Container mt_AuthorInfo5Container = new t_AuthorInfo5Container();
        
		/// <summary>
		/// t_AuthorInfo6配置容器对象
		/// </summary>
        private t_AuthorInfo6Container mt_AuthorInfo6Container = new t_AuthorInfo6Container();
        
		/// <summary>
		/// t_AuthorInfo7配置容器对象
		/// </summary>
        private t_AuthorInfo7Container mt_AuthorInfo7Container = new t_AuthorInfo7Container();
        
		/// <summary>
		/// t_AuthorInfo8配置容器对象
		/// </summary>
        private t_AuthorInfo8Container mt_AuthorInfo8Container = new t_AuthorInfo8Container();
        
		/// <summary>
		/// t_AuthorInfo9配置容器对象
		/// </summary>
        private t_AuthorInfo9Container mt_AuthorInfo9Container = new t_AuthorInfo9Container();
        
		/// <summary>
		/// t_global_b配置容器对象
		/// </summary>
        private t_global_bContainer mt_global_bContainer = new t_global_bContainer();
        
		/// <summary>
		/// t_Global10配置容器对象
		/// </summary>
        private t_Global10Container mt_Global10Container = new t_Global10Container();
        
		/// <summary>
		/// t_Global2配置容器对象
		/// </summary>
        private t_Global2Container mt_Global2Container = new t_Global2Container();
        
		/// <summary>
		/// t_Global3配置容器对象
		/// </summary>
        private t_Global3Container mt_Global3Container = new t_Global3Container();
        
		/// <summary>
		/// t_Global4配置容器对象
		/// </summary>
        private t_Global4Container mt_Global4Container = new t_Global4Container();
        
		/// <summary>
		/// t_Global5配置容器对象
		/// </summary>
        private t_Global5Container mt_Global5Container = new t_Global5Container();
        
		/// <summary>
		/// t_Global6配置容器对象
		/// </summary>
        private t_Global6Container mt_Global6Container = new t_Global6Container();
        
		/// <summary>
		/// t_Global7配置容器对象
		/// </summary>
        private t_Global7Container mt_Global7Container = new t_Global7Container();
        
		/// <summary>
		/// t_Global8配置容器对象
		/// </summary>
        private t_Global8Container mt_Global8Container = new t_Global8Container();
        
		/// <summary>
		/// t_Global9配置容器对象
		/// </summary>
        private t_Global9Container mt_Global9Container = new t_Global9Container();
        
		/// <summary>
		/// t_global_i配置容器对象
		/// </summary>
        private t_global_iContainer mt_global_iContainer = new t_global_iContainer();
        
		/// <summary>
		/// t_global_s配置容器对象
		/// </summary>
        private t_global_sContainer mt_global_sContainer = new t_global_sContainer();
        
		/// <summary>
		/// t_language_cn配置容器对象
		/// </summary>
        private t_language_cnContainer mt_language_cnContainer = new t_language_cnContainer();
        
		/// <summary>
		/// t_ui配置容器对象
		/// </summary>
        private t_uiContainer mt_uiContainer = new t_uiContainer();
        

		private GameDataManager()
		{
		
		}

		/// <summary>
		/// 加载所有配置数据
		/// </summary>
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
			
			Loadt_language_cnData();
			
			Loadt_uiData();
			
		}

		
		/// <summary>
		/// 加载t_AuthorInfo配置数据
		/// </summary>
		public void Loadt_AuthorInfoData()
		{
			mt_AuthorInfoContainer.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo数据列表
		/// </summary>
		public ReadOnlyCollection<t_AuthorInfo> Gett_AuthorInfoList()
		{
			return mt_AuthorInfoContainer.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo数据Map
		/// </summary>
		public ReadOnlyDictionary<int, t_AuthorInfo> Gett_AuthorInfoMap()
		{
			return mt_AuthorInfoContainer.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo10配置数据
		/// </summary>
		public void Loadt_AuthorInfo10Data()
		{
			mt_AuthorInfo10Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo10数据列表
		/// </summary>
		public List<t_AuthorInfo10> Gett_AuthorInfo10List()
		{
			return mt_AuthorInfo10Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo10数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo10> Gett_AuthorInfo10Map()
		{
			return mt_AuthorInfo10Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo2配置数据
		/// </summary>
		public void Loadt_AuthorInfo2Data()
		{
			mt_AuthorInfo2Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo2数据列表
		/// </summary>
		public List<t_AuthorInfo2> Gett_AuthorInfo2List()
		{
			return mt_AuthorInfo2Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo2数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo2> Gett_AuthorInfo2Map()
		{
			return mt_AuthorInfo2Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo3配置数据
		/// </summary>
		public void Loadt_AuthorInfo3Data()
		{
			mt_AuthorInfo3Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo3数据列表
		/// </summary>
		public List<t_AuthorInfo3> Gett_AuthorInfo3List()
		{
			return mt_AuthorInfo3Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo3数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo3> Gett_AuthorInfo3Map()
		{
			return mt_AuthorInfo3Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo4配置数据
		/// </summary>
		public void Loadt_AuthorInfo4Data()
		{
			mt_AuthorInfo4Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo4数据列表
		/// </summary>
		public List<t_AuthorInfo4> Gett_AuthorInfo4List()
		{
			return mt_AuthorInfo4Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo4数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo4> Gett_AuthorInfo4Map()
		{
			return mt_AuthorInfo4Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo5配置数据
		/// </summary>
		public void Loadt_AuthorInfo5Data()
		{
			mt_AuthorInfo5Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo5数据列表
		/// </summary>
		public List<t_AuthorInfo5> Gett_AuthorInfo5List()
		{
			return mt_AuthorInfo5Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo5数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo5> Gett_AuthorInfo5Map()
		{
			return mt_AuthorInfo5Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo6配置数据
		/// </summary>
		public void Loadt_AuthorInfo6Data()
		{
			mt_AuthorInfo6Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo6数据列表
		/// </summary>
		public List<t_AuthorInfo6> Gett_AuthorInfo6List()
		{
			return mt_AuthorInfo6Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo6数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo6> Gett_AuthorInfo6Map()
		{
			return mt_AuthorInfo6Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo7配置数据
		/// </summary>
		public void Loadt_AuthorInfo7Data()
		{
			mt_AuthorInfo7Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo7数据列表
		/// </summary>
		public List<t_AuthorInfo7> Gett_AuthorInfo7List()
		{
			return mt_AuthorInfo7Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo7数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo7> Gett_AuthorInfo7Map()
		{
			return mt_AuthorInfo7Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo8配置数据
		/// </summary>
		public void Loadt_AuthorInfo8Data()
		{
			mt_AuthorInfo8Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo8数据列表
		/// </summary>
		public List<t_AuthorInfo8> Gett_AuthorInfo8List()
		{
			return mt_AuthorInfo8Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo8数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo8> Gett_AuthorInfo8Map()
		{
			return mt_AuthorInfo8Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_AuthorInfo9配置数据
		/// </summary>
		public void Loadt_AuthorInfo9Data()
		{
			mt_AuthorInfo9Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_AuthorInfo9数据列表
		/// </summary>
		public List<t_AuthorInfo9> Gett_AuthorInfo9List()
		{
			return mt_AuthorInfo9Container.GetList();
		}

		/// <summary>
		/// 获取t_AuthorInfo9数据Map
		/// </summary>
		public Dictionary<int, t_AuthorInfo9> Gett_AuthorInfo9Map()
		{
			return mt_AuthorInfo9Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_global_b配置数据
		/// </summary>
		public void Loadt_global_bData()
		{
			mt_global_bContainer.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_global_b数据列表
		/// </summary>
		public List<t_global_b> Gett_global_bList()
		{
			return mt_global_bContainer.GetList();
		}

		/// <summary>
		/// 获取t_global_b数据Map
		/// </summary>
		public Dictionary<string, t_global_b> Gett_global_bMap()
		{
			return mt_global_bContainer.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global10配置数据
		/// </summary>
		public void Loadt_Global10Data()
		{
			mt_Global10Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global10数据列表
		/// </summary>
		public List<t_Global10> Gett_Global10List()
		{
			return mt_Global10Container.GetList();
		}

		/// <summary>
		/// 获取t_Global10数据Map
		/// </summary>
		public Dictionary<int, t_Global10> Gett_Global10Map()
		{
			return mt_Global10Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global2配置数据
		/// </summary>
		public void Loadt_Global2Data()
		{
			mt_Global2Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global2数据列表
		/// </summary>
		public List<t_Global2> Gett_Global2List()
		{
			return mt_Global2Container.GetList();
		}

		/// <summary>
		/// 获取t_Global2数据Map
		/// </summary>
		public Dictionary<int, t_Global2> Gett_Global2Map()
		{
			return mt_Global2Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global3配置数据
		/// </summary>
		public void Loadt_Global3Data()
		{
			mt_Global3Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global3数据列表
		/// </summary>
		public List<t_Global3> Gett_Global3List()
		{
			return mt_Global3Container.GetList();
		}

		/// <summary>
		/// 获取t_Global3数据Map
		/// </summary>
		public Dictionary<int, t_Global3> Gett_Global3Map()
		{
			return mt_Global3Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global4配置数据
		/// </summary>
		public void Loadt_Global4Data()
		{
			mt_Global4Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global4数据列表
		/// </summary>
		public List<t_Global4> Gett_Global4List()
		{
			return mt_Global4Container.GetList();
		}

		/// <summary>
		/// 获取t_Global4数据Map
		/// </summary>
		public Dictionary<int, t_Global4> Gett_Global4Map()
		{
			return mt_Global4Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global5配置数据
		/// </summary>
		public void Loadt_Global5Data()
		{
			mt_Global5Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global5数据列表
		/// </summary>
		public List<t_Global5> Gett_Global5List()
		{
			return mt_Global5Container.GetList();
		}

		/// <summary>
		/// 获取t_Global5数据Map
		/// </summary>
		public Dictionary<int, t_Global5> Gett_Global5Map()
		{
			return mt_Global5Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global6配置数据
		/// </summary>
		public void Loadt_Global6Data()
		{
			mt_Global6Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global6数据列表
		/// </summary>
		public List<t_Global6> Gett_Global6List()
		{
			return mt_Global6Container.GetList();
		}

		/// <summary>
		/// 获取t_Global6数据Map
		/// </summary>
		public Dictionary<int, t_Global6> Gett_Global6Map()
		{
			return mt_Global6Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global7配置数据
		/// </summary>
		public void Loadt_Global7Data()
		{
			mt_Global7Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global7数据列表
		/// </summary>
		public List<t_Global7> Gett_Global7List()
		{
			return mt_Global7Container.GetList();
		}

		/// <summary>
		/// 获取t_Global7数据Map
		/// </summary>
		public Dictionary<int, t_Global7> Gett_Global7Map()
		{
			return mt_Global7Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global8配置数据
		/// </summary>
		public void Loadt_Global8Data()
		{
			mt_Global8Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global8数据列表
		/// </summary>
		public List<t_Global8> Gett_Global8List()
		{
			return mt_Global8Container.GetList();
		}

		/// <summary>
		/// 获取t_Global8数据Map
		/// </summary>
		public Dictionary<int, t_Global8> Gett_Global8Map()
		{
			return mt_Global8Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_Global9配置数据
		/// </summary>
		public void Loadt_Global9Data()
		{
			mt_Global9Container.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_Global9数据列表
		/// </summary>
		public List<t_Global9> Gett_Global9List()
		{
			return mt_Global9Container.GetList();
		}

		/// <summary>
		/// 获取t_Global9数据Map
		/// </summary>
		public Dictionary<int, t_Global9> Gett_Global9Map()
		{
			return mt_Global9Container.GetMap();
		}
		
		/// <summary>
		/// 加载t_global_i配置数据
		/// </summary>
		public void Loadt_global_iData()
		{
			mt_global_iContainer.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_global_i数据列表
		/// </summary>
		public List<t_global_i> Gett_global_iList()
		{
			return mt_global_iContainer.GetList();
		}

		/// <summary>
		/// 获取t_global_i数据Map
		/// </summary>
		public Dictionary<string, t_global_i> Gett_global_iMap()
		{
			return mt_global_iContainer.GetMap();
		}
		
		/// <summary>
		/// 加载t_global_s配置数据
		/// </summary>
		public void Loadt_global_sData()
		{
			mt_global_sContainer.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_global_s数据列表
		/// </summary>
		public List<t_global_s> Gett_global_sList()
		{
			return mt_global_sContainer.GetList();
		}

		/// <summary>
		/// 获取t_global_s数据Map
		/// </summary>
		public Dictionary<string, t_global_s> Gett_global_sMap()
		{
			return mt_global_sContainer.GetMap();
		}
		
		/// <summary>
		/// 加载t_language_cn配置数据
		/// </summary>
		public void Loadt_language_cnData()
		{
			mt_language_cnContainer.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_language_cn数据列表
		/// </summary>
		public List<t_language_cn> Gett_language_cnList()
		{
			return mt_language_cnContainer.GetList();
		}

		/// <summary>
		/// 获取t_language_cn数据Map
		/// </summary>
		public Dictionary<string, t_language_cn> Gett_language_cnMap()
		{
			return mt_language_cnContainer.GetMap();
		}
		
		/// <summary>
		/// 加载t_ui配置数据
		/// </summary>
		public void Loadt_uiData()
		{
			mt_uiContainer.LoadDataFromBin();
		}

		/// <summary>
		/// 获取t_ui数据列表
		/// </summary>
		public List<t_ui> Gett_uiList()
		{
			return mt_uiContainer.GetList();
		}

		/// <summary>
		/// 获取t_ui数据Map
		/// </summary>
		public Dictionary<string, t_ui> Gett_uiMap()
		{
			return mt_uiContainer.GetMap();
		}
		
	}
}