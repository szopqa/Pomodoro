using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Pomodoro.Model;

namespace Pomodoro.ViewModel.MainApplicationPagesViewModel {
	public class PomodoroTimerPageViewModel {

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

		public PomodoroTimerPageViewModel(User loggedUser, Page timerPage) {
			LoggedUser = loggedUser;
			PomodoroTimerPage = timerPage;
		}
	}
}
