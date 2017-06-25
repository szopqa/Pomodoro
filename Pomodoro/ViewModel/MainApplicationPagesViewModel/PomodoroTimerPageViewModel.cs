using System;
using System.Windows.Controls;
using Pomodoro.Model;

namespace Pomodoro.ViewModel.MainApplicationPagesViewModel {
	public class PomodoroTimerPageViewModel {

	#region Properties

		private User _loggedUser;
		public User LoggedUser {
			get { return _loggedUser; }
			set { _loggedUser = value; }
		}

		private Page _pomodoroTimerPage;
		public Page PomodoroTimerPage {
			set { _pomodoroTimerPage = value; }
			get { return _pomodoroTimerPage; }
		}

		private int _seconds;
		public int Seconds {
			get { return _seconds; }
			set { _minutes = value; }
		}
		private int _minutes;
		public int Minutes {
			get {  return _minutes;	}
			set {  _minutes = value; }
		}

		private bool _isTimerRunning;
		public bool IsTimerRunning {
			get { return _isTimerRunning; }
			set { _isTimerRunning = value; }
		}

		private Timer _timer;

		#endregion

		//Constructor
		public PomodoroTimerPageViewModel(User loggedUser, Page timerPage) {

			LoggedUser = loggedUser;
			PomodoroTimerPage = timerPage;
			IsTimerRunning = false;
			this._timer = new Timer ( Seconds_Tick );
		}


		/// <summary>
		/// Setting up timer
		/// </summary>
		public void ActivateTimer( Action action ) {

			//checking if timer is currently running 
			if(IsTimerRunning)
				_timer.StopTimer();

			_timer.StartTimer();
			
			if (action.Equals(Action.StartWorkingSession))
				_minutes = LoggedUser.Preferences.WorkingSessionLength;
			else
				_minutes = LoggedUser.Preferences.ShortBreakLength;

			IsTimerRunning = true;

		}

		/// <summary>
		/// Method invoked every timer interval
		/// </summary>
		public void Seconds_Tick ( object sender, EventArgs e ) {

			UpdateClock ( );

		}


		public void SetUserPreferences() {

			Label secondsLabel = PomodoroTimerPage.FindName("SecondsLbl") as Label;
			Label minutesLabel = PomodoroTimerPage.FindName("MinutesLbl") as Label;
			
			//Setting user preferences
			secondsLabel.Content = "00";
			minutesLabel.Content = LoggedUser.Preferences.WorkingSessionLength.ToString();

		}
		

		

		private void UpdateClock() {

			if (IsTimerRunning){

				Label secondsLabel = PomodoroTimerPage.FindName ( "SecondsLbl" ) as Label;
				Label minutesLabel = PomodoroTimerPage.FindName ( "MinutesLbl" ) as Label;

				_seconds--;

				if ( _seconds < 0 ) {
					_seconds = 59;
					_minutes--;

					secondsLabel.Content = _seconds;

					if ( _minutes < 10 )
						minutesLabel.Content = "0" + _minutes;

					minutesLabel.Content = _minutes;
				} else {
					if ( _seconds < 10 ) {
						secondsLabel.Content = "0" + _seconds;
					} else {
						secondsLabel.Content = _seconds;
					}
				}
			}


		}




	}
}
