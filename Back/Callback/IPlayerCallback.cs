﻿namespace Back.Callback
{
	public interface IPlayerCallback: IFrontCallback
	{
		void ChangeActivePlayer(int previous, int current);
	}
}
