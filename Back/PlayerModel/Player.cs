using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PlayerModel
{
	public enum PlayerStatus { ALIVE = 0, DEAD, ACTIVE }
	public class Player : IPlayer
	{
		private string name;
		private int totalBrainCount = 0;
		private PlayerStatus status = PlayerStatus.ALIVE;

		public int TotalBrainCount { get => totalBrainCount; set => totalBrainCount = value; }
		public string Name { get => name; set => name = value; }
		public PlayerStatus Status { get => status; set => status = value; }
		public void Accept(IPlayerVisitor visitor)
		{
			visitor.Visit(this);
		}
		public override string ToString()
		{
			return Name + '\n' + "Brains: " + TotalBrainCount;
		}
	}
}
