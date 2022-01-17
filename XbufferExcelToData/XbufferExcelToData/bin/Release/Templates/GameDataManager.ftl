/**
 * Auto generated, do not edit it
 */
using xbuffer;

namespace Data
{
    public class GameDataManager
    {
		public static readonly GameDataManager Instance = new GameDataManager();

        #CONTAINER_MEMBER_LOOP#
        private #CLASS_NAME#Container m#CLASS_NAME#Container = new #CLASS_NAME#Container();
        #CONTAINER_MEMBER_LOOP#

		private GameDataManager()
		{
		
		}

		public void loadAll()
		{
			#CONTAINER_LOAD_LOOP#
			m#LOOP_CLASS_NAME#Container.loadDataFromBin();
			#CONTAINER_LOAD_LOOP#
		}

		#CONTAINER_GET_LOOP#
		public #LOOP_CLASS_NAME#Container Get#LOOP_CLASS_NAME#List()
		{
			return m#LOOP_CLASS_NAME#Container.getList()
		}

		public #LOOP_CLASS_NAME#Container Get#LOOP_CLASS_NAME#Map()
		{
			return m#LOOP_CLASS_NAME#Container.getMap()
		}
		#CONTAINER_GET_LOOP#
	}
}