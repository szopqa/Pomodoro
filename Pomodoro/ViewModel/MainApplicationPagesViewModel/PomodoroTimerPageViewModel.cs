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

		//Action taking place currently
		private Action _action;

		#endregion	

		//Constructor
		public PomodoroTimerPageViewModel(User loggedUser, Page timerPage) {

			LoggedUser = loggedUser;
			PomodoroTimerPage = timerPage;
			IsTimerRunning = false;
			this._timer = new Timer ( Seconds_Tick );

		}


		/// <summary>
		/// Shows user working session duration preferences
		/// </summary>
		public void SetUserPreferences ( int minutes )
		{

			Label secondsLabel = PomodoroTimerPage.FindName ( "SecondsLbl" ) as Label;
			Label minutesLabel = PomodoroTimerPage.FindName ( "MinutesLbl" ) as Label;

			//Setting user preferences
			secondsLabel.Content = "00";
			if ( minutes < 10 )
				minutesLabel.Content = "0" + minutes.ToString ( );
			else
				minutesLabel.Content = minutes.ToString ( );
		}


		/// <summary>
		/// Setting up timer
		/// </summary>
		public void ActivateTimer ( Action action) {

			if (IsTimerRunning)
				StopTimer();

			//Resetting seconds value
			_seconds = 0;

			//Timer duration depending user preferences for action chosen
			switch (action) {

				case Action.WorkingSession:
					_minutes = LoggedUser.Preferences.WorkingSessionLength;
					this._action = Action.WorkingSession;
					break;

				case Action.ShortBreak:
					_minutes = LoggedUser.Preferences.ShortBreakLength;
					this._action = Action.ShortBreak;
					break;

			}

			_timer.StartTimer();

			IsTimerRunning = true;
		}

		/// <summary>
		/// Stops currently running timer
		/// </summary>
		public void StopTimer() {
			_timer.StopTimer();
		}

		/// <summary>
		/// Method invoked every timer interval
		/// </summary>
		public void Seconds_Tick ( object sender, EventArgs e ) {
			
			UpdateClock ( );

			//Saving user data ( duration of action done ) 
			if (_action.Equals(Action.WorkingSession))
				LoggedUser.UserData.WorkLengthInSeconds ++;

			else if (_action.Equals(Action.ShortBreak))
				LoggedUser.UserData.RestLengthInSeconds ++ ;

		}
		

		
		/// <summary>
		/// Method invoked every clock interval, manages timer 
		/// </summary>
		private void UpdateClock() {

			Label secondsLabel = PomodoroTimerPage.FindName ( "SecondsLbl" ) as Label;
			Label minutesLabel = PomodoroTimerPage.FindName ( "MinutesLbl" ) as Label;
			

				if (_seconds < 0) {
					_seconds = 59;
					_minutes--;
				}


				//Showig values
				if (_seconds < 10)
					secondsLabel.Content = "0" + Seconds;
				else
					secondsLabel.Content = Seconds;

				if (_minutes < 10)
					minutesLabel.Content = "0" + Minutes;
				else
					minutesLabel.Content = Minutes;

			
			//Decresing time
			_seconds--;

		}


	}
}
