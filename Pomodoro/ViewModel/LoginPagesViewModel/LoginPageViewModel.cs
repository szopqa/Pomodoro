﻿using System.Windows;
using Pomodoro.Model;
using Pomodoro.Model.Database;
using Pomodoro.View.Pages.MainApplicationPages;

namespace Pomodoro.ViewModel {
	public class LoginPageViewModel {

	#region Properties

		private User _newUser = new User();
		private IExecutable executable = new UserAuthorizer();

		public User NewUser {
			get {
				return _newUser;
			}
			set {
				_newUser = value;

				//calling authorisation method
				LoginUser();
			}
		}

	#endregion



		/// <summary>
		/// Sends sql command checking wether user exists in database
		/// </summary>
		private void LoginUser() {

			User loggedUser = executable.ExecuteQuery(NewUser.Username, NewUser.Password, null);

			if (loggedUser == null) {
				ShowLoginFailed();
			}
			else {
				loggedUser.IsLoggedIn = true;
				MessageBox.Show($"Logged as {NewUser.Username}");

				LoadApplicationStartPage(loggedUser);				
			}
		}



		/// <summary>
		/// Loads MainPage after logging in
		/// </summary>
		private void LoadApplicationStartPage ( User loggedUser ) {
			var mainWindow = Application.Current.MainWindow as MainWindow;
			mainWindow.MainAppFrame.NavigationService.Navigate(new MainPage( loggedUser ));


			//TODO : Passint loggedUser to MainPageViewModel
		}


		/// <summary>
		/// Checking if user entered login and password into textboxes
		/// </summary>
		/// <returns>Returns false if textboxes are filled</returns>
		public bool AreAllTextBoxesFilled ( string loginBox, string passwordBox ) {

			if ( string.IsNullOrWhiteSpace(loginBox)
			     || string.IsNullOrWhiteSpace(passwordBox) ) {

				return false;

			}
			else {
				return true;
			}

		}

		/// <summary>
		/// Showing error message 
		/// </summary>
		private void ShowLoginFailed () {
			MessageBox.Show($"Login failed! Username \"{NewUser.Username}\" and password do not match!");
		}



	}

}
