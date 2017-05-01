using System.Windows;
using System.Windows.Controls;
using Pomodoro.Model;
using Pomodoro.ViewModel;

namespace Pomodoro.View.Pages {
	/// <summary>
	/// Interaction logic for CreateNewAccountPage.xaml
	/// </summary>
	public partial class CreateNewAccountPage : Page {

		private CreateNewAccountPageViewModel viewModel;
		
		public CreateNewAccountPage () {
			InitializeComponent();

			viewModel = new CreateNewAccountPageViewModel();
		}



		private void CreateBtn_Click ( object sender, RoutedEventArgs e ) {

			//Checking if all boxes are filled
			if (viewModel.AreAllTextBoxesFilled(NewUsernameTextBox.Text,
				PasswordTextBox.Password,
				RePasswordTextBox.Password,
				NewEmailTextBox.Text)) {
				
				//Checking if both passwords are the same
				if (viewModel.PasswordsAreEqual(PasswordTextBox.Password, RePasswordTextBox.Password)) {
					viewModel.CreateNewAccountPage = this;
					//calling method creating new account
					viewModel.NewUser = new User(NewUsernameTextBox.Text, PasswordTextBox.Password, NewEmailTextBox.Text);
				}
				else {
					viewModel.ShowErrorMessage(this,"PasswordsAreNotEqual");
				}

			}
			else {
				viewModel.ShowErrorMessage(this,"TextBoxesEmpty");
			}

		}



		/// <summary>
		/// Loads back Login Page
		/// </summary>
		private void BackBtn_Click ( object sender, RoutedEventArgs e ) {
			this.NavigationService.Navigate(new LoginPage());
		}


		
	}
}
