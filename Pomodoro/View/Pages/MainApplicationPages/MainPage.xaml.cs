using System.Windows;
using System.Windows.Controls;
using Pomodoro.Model;
using Pomodoro.ViewModel;
using System.Windows.Media.Animation;
using Pomodoro.ViewModel.MainApplicationPagesViewModel;

namespace Pomodoro.View.Pages.MainApplicationPages {
	
	/// <summary>
	/// Application's main page. Holds logged user info, passing it to pages viewmodels
	/// </summary>	
	public partial class MainPage : Page {

	#region Properties
		
		private MainPageViewModel _mainViewModel;
		
		/*Page objects*/
		private UserInfoPage userInfoPage = new UserInfoPage();
		private PomodoroTimerPage pomodoroTimerPage = new PomodoroTimerPage();
		
	#endregion

		public MainPage(User loggedUser) {

			InitializeComponent();

			//Passing loggedUser and pages to their viewmodels
			_mainViewModel = new MainPageViewModel(loggedUser,this);
			userInfoPage.ViewModel = new UserInfoPageViewModel(loggedUser, userInfoPage);
			pomodoroTimerPage.ViewModel = new PomodoroTimerPageViewModel(loggedUser, pomodoroTimerPage);
	
		}
		
		
		/// <summary>
		/// Shows / hides sliding menu
		/// </summary>
		private void MenuButtonClick ( object sender, RoutedEventArgs e ) {

			_mainViewModel.AnimateSlidingMenu();

		}


		/// <summary>
		/// Loads PomodoroTimerPage as application's starting page
		/// </summary>
		private void MainPage_OnLoaded ( object sender, RoutedEventArgs e ) {
			
			//Loads PomodoroTimerPage
			this.ApplicationMainFrame.NavigationService.Navigate(userInfoPage);

		}

		

		/// <summary>
		/// Loads start page 
		/// </summary>
		private void StartPageBtn_OnClick(object sender, RoutedEventArgs e) {
			this.ApplicationMainFrame.NavigationService.Navigate(userInfoPage);
		}



		/// <summary>
		/// Loads timer page
		/// </summary>
		private void PomodoroTimerBtn_OnClick(object sender, RoutedEventArgs e) {
			this.ApplicationMainFrame.NavigationService.Navigate(pomodoroTimerPage);
		}

		
	}
}
