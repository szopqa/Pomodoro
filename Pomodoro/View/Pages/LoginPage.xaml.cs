using System.Windows;
using System.Windows.Controls;
using Pomodoro.Model;
using Pomodoro.ViewModel;

namespace Pomodoro.View.Pages {
	/// <summary>
	/// ButtonClicks sends data from textboxes to ViewModel class
	/// </summary>
	public partial class LoginPage : Page {

		private LoginPageViewModel viewModel;

		public LoginPage () {
			InitializeComponent();
			viewModel = new LoginPageViewModel();
		}

		/// <summary>
		/// Sends login and password to ViewModel Class
		/// </summary>
		private void LoginButton_Click ( object sender, RoutedEventArgs e ) {

			//Checking weather user typed anything into boxes
			if (viewModel.AreAllTextBoxesFilled(LoginTextBox.Text, PasswordTextBox.Password)) {
				viewModel.NewUser = new User(LoginTextBox.Text, PasswordTextBox.Password, "");
				ClearTexboxes();
			}
			else {
				MessageBox.Show("Boxes are not filled!");
			}
			
		}

		/// <summary>
		/// Loads CreateNewAccount Page
		/// </summary>
		private void CreateAccountButton_Click ( object sender, RoutedEventArgs e ) {

			this.NavigationService.Navigate(new CreateNewAccountPage());

		}


		/// <summary>
		/// Removes data in textboxes
		/// </summary>
		private void ClearTexboxes() {
			LoginTextBox.Clear();
			PasswordTextBox.Clear();
		}

	}
}
