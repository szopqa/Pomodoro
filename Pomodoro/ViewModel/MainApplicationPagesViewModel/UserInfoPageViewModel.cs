using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Pomodoro.Model;

namespace Pomodoro.ViewModel.MainApplicationPagesViewModel {
	class UserInfoPageViewModel {

		private User _loggedUser;
		public User LoggedUser {
			get { return _loggedUser; }
			set { _loggedUser = value; }
		}

		private Page _userInfoPage;
		public Page UserInfoPage {
			set { _userInfoPage = value; }
			get { return _userInfoPage; }
		}

		public UserInfoPageViewModel(User loggedUser, Page userInfoPage) {
			LoggedUser = loggedUser;
			UserInfoPage = userInfoPage;
		}


	}
}
