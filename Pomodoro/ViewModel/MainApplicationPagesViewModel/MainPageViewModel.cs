using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
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

		private bool _isMenuVisible;
		public bool IsMenuVisible {
			get { return _isMenuVisible; }
			set { _isMenuVisible = value; }
		}

	#endregion



		public MainPageViewModel (User loggedUser, Page mainPage) {
			LoggedUser = loggedUser;
			ApplicationMainPage = mainPage;

			IsMenuVisible = true;
		}
		


		public void AnimateSlidingMenu() {

			//Getting page resources
			Storyboard showMenuAnimation = ApplicationMainPage.FindResource("showDockPanel") as Storyboard;
			Storyboard hideMenuAnimation = ApplicationMainPage.FindResource("showDockPanel") as Storyboard;

			Button moveMenuButton = ApplicationMainPage.FindName("MoveMenuBtn") as Button;
			Button startPageButton = ApplicationMainPage.FindName("StartPageBtn") as Button;
			Button timerPageButton = ApplicationMainPage.FindName("PomodoroTimerBtn") as Button;

			//Function's logic
			if (IsMenuVisible) {
				hideMenuAnimation = ApplicationMainPage.FindResource("hideDockPanel") as Storyboard;
				hideMenuAnimation.Begin();
				startPageButton.Visibility = Visibility.Hidden;
				timerPageButton.Visibility = Visibility.Hidden;
				IsMenuVisible = false;
			}
			else {
				showMenuAnimation = ApplicationMainPage.FindResource("showDockPanel") as Storyboard;
				showMenuAnimation.Begin();
				startPageButton.Visibility = Visibility.Visible;
				timerPageButton.Visibility = Visibility.Visible;
				IsMenuVisible = true;
			}

		}




	}
}
