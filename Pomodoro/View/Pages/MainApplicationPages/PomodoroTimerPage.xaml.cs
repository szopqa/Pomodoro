using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Pomodoro.ViewModel.MainApplicationPagesViewModel;
using Action = Pomodoro.ViewModel.MainApplicationPagesViewModel.Action;

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

			if(_viewModel.IsTimerRunning == false)
				_viewModel.SetUserPreferences();

			StartRestBtn.Visibility = Visibility.Hidden;

		}

		private void StartWorkingSession_Click ( object sender, RoutedEventArgs e ) {

			ViewModel.ActivateTimer(Action.StartWorkingSession);

			if (ViewModel.IsTimerRunning){
				StartWorkingBtn.Visibility = Visibility.Hidden;
				StartRestBtn.Visibility = Visibility.Visible;
			}

		}

		private void BreakButtonClick ( object sender, RoutedEventArgs e )
		{

			


		}
	}
}
