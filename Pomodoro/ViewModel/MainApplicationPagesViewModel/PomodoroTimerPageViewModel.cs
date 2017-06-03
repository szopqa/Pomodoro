﻿using System;
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

	#endregion

		//Constructor
		public PomodoroTimerPageViewModel(User loggedUser, Page timerPage) {
			LoggedUser = loggedUser;
			PomodoroTimerPage = timerPage;
		}


		public void ActivateCountdown() {
			Timer timer = new Timer( Seconds_Tick );
			timer.StartTimer();
			
		}

		public void SetUserPreferences() {

			Label secondsLabel = PomodoroTimerPage.FindName("SecondsLbl") as Label;
			Label minutesLabel = PomodoroTimerPage.FindName("MinutesLbl") as Label;

			secondsLabel.Content = "00";
			minutesLabel.Content = _loggedUser.Preferences.WorkingSessionLength.ToString();

		}


		//TEST
		private static int currentCount = 0;

		/// <summary>
		/// Method invoked every timer interval
		/// </summary>
		public void Seconds_Tick ( object sender, EventArgs e ) {

			Label secondsLabel = PomodoroTimerPage.FindName("SecondsLbl") as Label;

			secondsLabel.Content = currentCount++;
			
		}

	}
}
