using System.Windows;
using System.Windows.Controls;
using Pomodoro.Model;
using Pomodoro.ViewModel;

namespace Pomodoro.View.Pages.MainApplicationPages {
	/// <summary>
	/// Interaction logic for ApplicationStartPage.xaml
	/// </summary>
	public partial class ApplicationStartPage : Page {

		private ApplicationStartPageViewModel viewModel = new ApplicationStartPageViewModel();

		public ApplicationStartPage ( User loggedUSer ) {
			InitializeComponent();

			//Passing loggedUser and page object 
			viewModel.LoggedUser = loggedUSer;
			viewModel.ApplicationStartPage = this;

			//TODO : Wywalić to z konstruktora!
			viewModel.ShowLoggedUserInfo();
		}
		
	}
}
