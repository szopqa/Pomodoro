using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Pomodoro.ViewModel.MainApplicationPagesViewModel;

namespace Pomodoro.View.Pages.MainApplicationPages {
	/// <summary>
	/// Interaction logic for PomodoroTimerPage.xaml
	/// </summary>
	public partial class PomodoroTimerPage : Page {

		private PomodoroTimerPageViewModel _viewModel;
		public PomodoroTimerPageViewModel ViewModel {
			get { return _viewModel; }
			set { _viewModel = value; }
		}

		public PomodoroTimerPage() {
			InitializeComponent();
		}
		private void PomodoroTimerOnload ( object sender, RoutedEventArgs e ) {
			//TODO : Check if timer is running. If yes set current timer value not default
			_viewModel.SetUserPreferences();
		}

		private void StartWorkingSession_Click ( object sender, RoutedEventArgs e ) {
			ViewModel.ActivateCountdown();
		}

	}
}
