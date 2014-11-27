using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Snake.Core;

namespace Snake.IOS
{
	public class Timer : System.Timers.Timer, ITimer
	{
		#region Constructor
		public Timer()
		{
			this.Elapsed += Timer_Tick;
		}
		#endregion

		#region Timer
		public new double Interval
		{
			get
			{
				return base.Interval;
			}
			set
			{
				base.Interval = value;
			}
		}

		public Action OnTick
		{
			get;
			set;
		}

		public void Dispose()
		{
		}
		#endregion

		#region Methods
		void Timer_Tick(object sender, object e)
		{
			if(this.OnTick!=null)
			{
				this.OnTick();
			}
		}
		#endregion
	}
}
