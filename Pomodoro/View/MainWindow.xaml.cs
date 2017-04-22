using System.Windows;
using Pomodoro.View.Pages;

namespace Pomodoro {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow () {
			InitializeComponent();
			//Loading login page onload of main Window
			MainAppFrame.NavigationService.Navigate(new LoginPage());
		}
	}
}
