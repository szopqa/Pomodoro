﻿using System.Windows;
using System.Windows.Controls;
using Pomodoro.Model;
using Pomodoro.ViewModel;
using System.Windows.Media.Animation;

namespace Pomodoro.View.Pages.MainApplicationPages {
	/// <summary>
	/// Interaction logic for ApplicationStartPage.xaml
	/// </summary>	
	public partial class ApplicationStartPage : Page {

		private ApplicationStartPageViewModel viewModel = new ApplicationStartPageViewModel();
		private bool isSliderMenuVisible;


		public ApplicationStartPage(User loggedUSer) {
			InitializeComponent();

			//Menu is being shown onload of page
			this.isSliderMenuVisible = true;

			//Passing loggedUser and page object 
			viewModel.LoggedUser = loggedUSer;
			viewModel.ApplicationStartPage = this;

			//Loads user data on start page
			loadLoggedUserData();
		}



		/// <summary>
		/// Loads data about logged user onload of start page
		/// </summary>
		private void loadLoggedUserData() {
			//TODO : Use onload method instead of invoking this in constructor
			viewModel.ShowLoggedUserInfo();
		}


		private void MenuButtonClick ( object sender, RoutedEventArgs e ) {

			Storyboard showMenu = this.FindResource("showDockPanel") as Storyboard;
			Storyboard hideMenu = this.FindResource("showDockPanel") as Storyboard;

			if ( ! isSliderMenuVisible ) {
				showMenu = this.FindResource("showDockPanel") as Storyboard;
				showMenu.Begin();
				isSliderMenuVisible = true;
			}
			else {
				hideMenu = this.FindResource("hideDockPanel") as Storyboard;
				hideMenu.Begin();
				isSliderMenuVisible = false;
			}


		}
	}
}