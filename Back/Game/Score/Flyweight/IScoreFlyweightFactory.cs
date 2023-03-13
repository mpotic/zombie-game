using System;

namespace Back.Game
{
	public interface IScoreFlyweightFactory
	{
		IScore GetFlyweight(Type type);
	}
}
