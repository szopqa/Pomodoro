using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
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

		private int seconds;
		public int Seconds {
			get { return seconds; }
			set { minutes = value; }
		}
		private int minutes;
		public int Minutes {
			get {  return minutes;	}
			set {  minutes = value; }
		}

		private bool _isTimerRunning;
		public bool IsTimerRunning {
			get { return _isTimerRunning; }
			set { _isTimerRunning = value; }
		}

		#endregion

		//Constructor
		public PomodoroTimerPageViewModel(User loggedUser, Page timerPage) {
			LoggedUser = loggedUser;
			PomodoroTimerPage = timerPage;
			IsTimerRunning = false;
			
			//Setting session length based on user preferences
			minutes = _loggedUser.Preferences.WorkingSessionLength;
			seconds = 0;
		}

		/// <summary>
		/// Setting up timer
		/// </summary>
		public void ActivateTimer() {

			Timer timer = new Timer( Seconds_Tick );
			timer.StartTimer();
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

			secondsLabel.Content = "00";
			minutesLabel.Content = Minutes.ToString();

			//minutes = _loggedUser.Preferences.WorkingSessionLength;

		}
		

		

		private void UpdateClock() {

			seconds--;

			Label secondsLabel = PomodoroTimerPage.FindName ( "SecondsLbl" ) as Label;
			Label minutesLabel = PomodoroTimerPage.FindName ( "MinutesLbl" ) as Label;

			if (seconds < 0) {
				seconds = 59;
				minutes--;

				secondsLabel.Content = seconds;

				if (minutes < 10)
					minutesLabel.Content = "0" + minutes;

				minutesLabel.Content = minutes;
			}
			
			else{
				if (seconds < 10){
					secondsLabel.Content = "0" + seconds;
				}
				else{
					secondsLabel.Content = seconds;
				}
			}
		}




	}
}
