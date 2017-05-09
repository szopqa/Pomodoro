using System.Windows;
using System.Windows.Controls;
using Pomodoro.ViewModel.MainApplicationPagesViewModel;

namespace Pomodoro.View.Pages.MainApplicationPages {
	/// <summary>
	/// Interaction logic for PomodoroTimerPage.xaml
	/// </summary>
	public partial class UserInfoPage : Page {

		private UserInfoPageViewModel _viewModel;
		public UserInfoPageViewModel ViewModel {
			get { return _viewModel; }
			set { _viewModel = value; }
		}

		public UserInfoPage () {
			InitializeComponent();
		}


		private void UserInfoPage_OnLoaded(object sender, RoutedEventArgs e) {
			ViewModel.ShowUsername();
		}
	}
}
