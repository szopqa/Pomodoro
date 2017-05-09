using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Pomodoro.Model;

namespace Pomodoro.ViewModel {
	public class MainPageViewModel {


	#region Properties

		private User _loggedUser;
		public User LoggedUser {
			get { return _loggedUser; }
			set { _loggedUser = value; }
		}

		private Page _applicationMainPage;
		public Page ApplicationMainPage {
			set { _applicationMainPage = value; }
			get { return _applicationMainPage; }
		}

		public MainPageViewModel(User loggedUser, Page mainPage) {
			LoggedUser = loggedUser;
			ApplicationMainPage = mainPage;
		}


	#endregion


	}
}
