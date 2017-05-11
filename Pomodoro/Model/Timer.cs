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

		private PomodoroTimerPageViewModel _viewModel;
		public PomodoroTimerPageViewModel ViewModel {
			get { return _viewModel; }
		}


		//Constructor
		public Timer( PomodoroTimerPageViewModel viewModel ) {
			_viewModel = viewModel;
			SetupTimer();
		}


		/// <summary>
		/// Sets timer interval
		/// </summary>
		private void SetupTimer () {
			_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
			_timer.Tick += new EventHandler(ViewModel.Seconds_Tick);
		}


		/// <summary>
		/// Starts timer with set interval
		/// </summary>
		public void StartTimer() {
			_timer.Start();
		}
		
		

	}
}
