using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Pomodoro.Model;

namespace Pomodoro.ViewModel {
	class ApplicationStartPageViewModel {


	#region Properties

		private User _loggedUser;
		public User LoggedUser {
			get { return _loggedUser; }
			set { _loggedUser = value; }
		}

		private Page _applicationStartPage;
		public Page ApplicationStartPage {
			set { _applicationStartPage = value; }
			get { return _applicationStartPage; }
		}

	#endregion


		public void ShowLoggedUserInfo() {

			var usernameLabel = ApplicationStartPage.FindName("UsernameLbl") as Label;
			usernameLabel.Content = "Logged as: " + LoggedUser.Username;
		}

	}
}
