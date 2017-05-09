using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

		public PomodoroTimerPage () {
			InitializeComponent();
		}
	}
}
