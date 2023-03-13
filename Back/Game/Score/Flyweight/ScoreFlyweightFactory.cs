using System;
using System.Collections.Generic;

namespace Back.Game
{
	public class ScoreFlyweightFactory : IScoreFlyweightFactory
	{
		private Dictionary<Type, IScore> flyweights = new Dictionary<Type, IScore>();

		public IScore GetFlyweight(Type type)
		{
			if(flyweights.ContainsKey(type))
			{
				return flyweights[type];
			}

			flyweights[type] = (IScore)Activator.CreateInstance(type);
			return flyweights[type];
		}
	}
}
