using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel
{
	public interface IPlayerList
	{
		ObservableCollection<IPlayer> Players { get; set; }
	}
}
