using System;
using System.Windows;
using System.Windows.Controls;
using Pomodoro.Model;
using Pomodoro.Model.Database;
using Pomodoro.View.Pages;

namespace Pomodoro.ViewModel {
	public class CreateNewAccountPageViewModel {

	#region Properties

		private IExecutable executable;

		private Page _createNewAccountPage;
		public Page CreateNewAccountPage {
			set { _createNewAccountPage = value; }
			get { return _createNewAccountPage; }
		}

		private User _newUser = new User();
		public User NewUser {
			get { return this._newUser; }
			set {
				this._newUser = value;

				//calling method creating new account
				if( CheckIfUsernameIsAvailable() )
					CreateNewAccount();
				else
					ShowErrorMessage(CreateNewAccountPage, "UsernameUsed");
			}
		}

	#endregion


		/// <summary>
		/// Checking if username is available to use
		/// </summary>
		/// <returns>True if username was not found</returns>
		private bool CheckIfUsernameIsAvailable() {

			var exec = new UsernameChecker();

			if (exec.IsUsernameAvailable(NewUser.Username))
				return true;

			return false;


		}


		/// <summary>
		/// Method executing Sql command adding new user to database
		/// </summary>
		private void CreateNewAccount() {

			this.executable = new NewUserCreator();

			var newUser  = executable.ExecuteQuery(NewUser.Username, NewUser.Password, NewUser.EmailAddress);

			if (newUser == null) {
				ShowErrorMessage(CreateNewAccountPage,"CreateFailed");
			}
			else {
				MessageBox.Show("Account successfully created! You can now log in");
				
				//Showing back login page
				var mainWindow = Application.Current.MainWindow as MainWindow;
				mainWindow.MainAppFrame.NavigationService.Navigate(new LoginPage());
			}

			//TODO: Handle returned User object
		}


		/// <summary>
		/// Checking if all fields in CreateNewPage are filled
		/// </summary>
		/// <returns>Returns true if at least one of them is empty</returns>
		public bool AreAllTextBoxesFilled(string loginBox, string passwordOneBox, string passwordTwoBox, string emailBox) {
			if (string.IsNullOrWhiteSpace(loginBox)
						|| string.IsNullOrWhiteSpace(passwordOneBox)
						|| string.IsNullOrWhiteSpace(passwordTwoBox)
						|| string.IsNullOrWhiteSpace(emailBox)) {
				return false;
			}

			return true;
		}


		/// <summary>
		/// Checks if user typed same passwords in both password boxes
		/// </summary>
		/// <returns>Returns true if they are equal</returns>
		public bool PasswordsAreEqual ( string firstPassword, string secondPassword ) {
			if ( firstPassword.Equals(secondPassword) )
				return true;
			
			return false;
		}



		/// <summary>
		/// Shows error message which depends on errorReason passed as an argument
		/// </summary>
		public void ShowErrorMessage ( Page createNewPage, string errorReason ) {
			
			//Creating objects of PasswordBoxes to clear them, every time error occures 
			TextBox usernameBox = createNewPage.FindName("NewUsernameTextBox") as TextBox;
			TextBox emailBox = createNewPage.FindName("NewEmailTextBox") as TextBox;
			PasswordBox pass1 = createNewPage.FindName("PasswordTextBox") as PasswordBox;
			PasswordBox pass2 = createNewPage.FindName("RePasswordTextBox") as PasswordBox;


			switch ( errorReason ) {

				case "TextBoxesEmpty":

					MessageBox.Show("All boxes have to be filled!");

				break;

				case "PasswordsAreNotEqual":
					
					MessageBox.Show("Passwords are not the same!");
		
					pass1.Clear();
					pass2.Clear();

				break;

				case "CreateFailed":
					MessageBox.Show("Connection problem. Try again!");

					pass1.Clear();
					pass2.Clear();

				break;

				case "UsernameUsed":
					MessageBox.Show($"Username \"{NewUser.Username}\" already exists in databse!");
					usernameBox.Clear();
					emailBox.Clear();
					pass1.Clear();
					pass2.Clear();
				break;

			}

		}



	}
}
