using Back.Dice;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.Game
{
	public class ScoreDecorator : IScoreDecorator, INotifyPropertyChanged
	{
		private IScore scoreComponent = new Score();

		public IScore ScoreComponent { get => scoreComponent; set => scoreComponent = value; }

		public int BrainsCount
		{
			get
			{
				return ScoreComponent.BrainsCount;
			}
			set
			{
				ScoreComponent.BrainsCount = value;
			}
		}

		public int ShotgunCount
		{
			get
			{
				return ScoreComponent.ShotgunCount;
			}
			set
			{
				ScoreComponent.ShotgunCount = value;
			}
		}

		public bool Killed
		{
			get
			{
				return ScoreComponent.Killed;
			}
			set
			{
				ScoreComponent.Killed = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<IDice> AllRolledDice
		{
			get
			{
				return ScoreComponent.AllRolledDice;
			}
			set
			{
				ScoreComponent.AllRolledDice = value;
			}
		}

		public ScoreDecorator()
		{
			AllRolledDice = GameSingleton.instance != null ?
				GameSingleton.instance.Game.ScoreDecorator.AllRolledDice : new ObservableCollection<IDice>();
		}

		public virtual void CheckAndKill()
		{
			ScoreComponent.CheckAndKill();
		}

		public virtual void PlayerKilled()
		{
			ScoreComponent.PlayerKilled();
		}

		public virtual void ResetScore()
		{
			ScoreComponent.ResetScore();
		}

		public virtual void SetScoreComponent(IScore score)
		{
			ScoreComponent = score;
		}

		public virtual void UpdateScore()
		{
			ScoreComponent.UpdateScore();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
