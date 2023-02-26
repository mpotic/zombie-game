using System.Windows.Controls;

namespace ZombieGame.Callback
{
	internal class PlayerListViewElementSingleton
	{
		private static ListView playersList;

		internal static ListView PlayersList 
		{ 
			get => playersList;
			set
			{
				lock (new object())
				{
					if (playersList == null)
					{
						playersList = value;
					}
				}
			}
		}
		
		private PlayerListViewElementSingleton()
		{
		}
	}
}
