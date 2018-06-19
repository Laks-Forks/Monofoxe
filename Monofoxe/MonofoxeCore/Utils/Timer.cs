﻿using Monofoxe.Engine;

namespace Monofoxe.Utils
{
	/// <summary>
	/// Counts seconds. Needs to be updated manually.
	/// </summary>
	public class Timer
	{
		/// <summary>
		/// Tells how much time has passed in seconds.
		/// </summary>
		public double Counter {get; protected set;} = 0;
		
		/// <summary>
		/// Timer won't update if it's inactive.
		/// </summary>
		public bool Active = true;

		/// <summary>
		/// Tells if timer is affected by GameCntrl.GameSpeedMultiplier.
		/// </summary>
		public bool AffectedBySpeedMultiplier = true;


		
		/// <summary>
		/// Resets timer.
		/// </summary>
		public void Reset()
		{
			Active = false;
			Counter = 0;
		}



		/// <summary>
		/// Updates timer.
		/// </summary>
		public virtual void Update()
		{
			if (Active)
			{
				if (AffectedBySpeedMultiplier)
				{
					Counter += GameCntrl.Time();
				}
				else
				{
					Counter += GameCntrl.ElapsedTime;
				}
			}
		}

	}
}
