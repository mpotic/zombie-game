using Back.Dice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Game
{
	public class ScoreDecoratorHeroine : IScoreDecorator
	{
		public IScore ScoreComponent => throw new NotImplementedException();

		public int BrainsCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int ShotgunCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Killed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ObservableCollection<IDice> AllRolledDice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void CheckAndKill()
		{
			throw new NotImplementedException();
		}

		public void PlayerKilled()
		{
			throw new NotImplementedException();
		}

		public void ResetScore()
		{
			throw new NotImplementedException();
		}

		public void SetScoreComponent(IScore score)
		{
			throw new NotImplementedException();
		}

		public void UpdateScore()
		{
			throw new NotImplementedException();
		}
	}
}
