using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel
{
	public interface IPlayer
	{
		int TotalBrainCount { get; set; }
		string Name { get; set; }
		PlayerStatus Status { get; set; }
		void Accept(IPlayerVisitor visitor);
	}
}
