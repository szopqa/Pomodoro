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
		
		/*Page objects*/
		private UserInfoPage userInfoPage = new UserInfoPage();
		private PomodoroTimerPage pomodoroTimerPage = new PomodoroTimerPage();
		
		/*Page ViewModel class*/
		private MainPageViewModel _mainViewModel;
		
		private bool isSliderMenuVisible;

	#endregion

		public MainPage(User loggedUser) {

			InitializeComponent();

			//Passing loggedUser and pages to their viewmodels
			_mainViewModel = new MainPageViewModel(loggedUser,this);
			userInfoPage.ViewModel = new UserInfoPageViewModel(loggedUser, userInfoPage);
			pomodoroTimerPage.ViewModel = new PomodoroTimerPageViewModel(loggedUser, pomodoroTimerPage);

			//Setting private properties
			this.isSliderMenuVisible = true;
	
		}

		/// <summary>
		/// Loads PomodoroTimerPage as application's starting page
		/// </summary>
		private void MainPage_OnLoaded ( object sender, RoutedEventArgs e ) {
			
			//Loads PomodoroTimerPage
			this.ApplicationMainFrame.NavigationService.Navigate(userInfoPage);

		}

		/// <summary>
		/// Shows / hides sliding menu
		/// </summary>
		private void MenuButtonClick ( object sender, RoutedEventArgs e ) {

			Storyboard showMenuAnimation = this.FindResource("showDockPanel") as Storyboard;
			Storyboard hideMenuAnimation = this.FindResource("showDockPanel") as Storyboard;

			if ( ! isSliderMenuVisible ) {
				showMenuAnimation = this.FindResource("showDockPanel") as Storyboard;
				this.StartPageBtn.Visibility = Visibility.Visible;
				this.PomodoroTimerBtn.Visibility = Visibility.Visible;
				showMenuAnimation.Begin();
				this.MoveMenuBtn.Content = "Hide";
				isSliderMenuVisible = true;
			}
			else {
				hideMenuAnimation = this.FindResource("hideDockPanel") as Storyboard;
				hideMenuAnimation.Begin();
				this.StartPageBtn.Visibility = Visibility.Hidden;
				this.PomodoroTimerBtn.Visibility = Visibility.Hidden;
				this.MoveMenuBtn.Content = "Show";
				isSliderMenuVisible = false;
			}

		}

		/// <summary>
		/// Loads start page 
		/// </summary>
		private void StartPageBtn_OnClick(object sender, RoutedEventArgs e) {
			this.ApplicationMainFrame.NavigationService.Navigate(userInfoPage);
		}

		private void PomodoroTimerBtn_OnClick(object sender, RoutedEventArgs e) {
			this.ApplicationMainFrame.NavigationService.Navigate(pomodoroTimerPage);
		}

		
	}
}
