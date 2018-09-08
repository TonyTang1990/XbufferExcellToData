/**
 * Auto generated, do not edit it
 */
using xbuffer;

namespace Data
{
    public class GameDataManager
    {
		public static readonly GameDataManager Instance = new GameDataManager();

        
        public t_AuthorInfoContainer t_AuthorInfocontainer = new t_AuthorInfoContainer();
        
        public t_GlobalContainer t_Globalcontainer = new t_GlobalContainer();
        

		private GameDataManager()
		{
		
		}

		public void loadAll()
		{
			
			t_AuthorInfocontainer.loadDataFromBin();
			
			t_Globalcontainer.loadDataFromBin();
			
		}
	}
}