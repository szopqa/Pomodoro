using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Pomodoro.ViewModel.MainApplicationPagesViewModel;

namespace Pomodoro.Model {
	public class Timer {

		private DispatcherTimer _timer;	

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="functionToInvoke">Function invoked every interval</param>
		public Timer( Action<object,EventArgs> functionToInvoke ) {

			//Setting interval for one second
			_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
			
			_timer.Tick += new EventHandler( functionToInvoke );

		}

		
		/// <summary>
		/// Starts timer with set interval
		/// </summary>
		public void StartTimer() {
			_timer.Start();
		}
		
		

	}
}
