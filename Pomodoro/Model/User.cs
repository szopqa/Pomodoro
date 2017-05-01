using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomodoro.Model.Database;

namespace Pomodoro.Model {

	public class User {

	#region Properties with getters and setters

		private string _username;
		public string Username {
			get { return _username; }
			set { _username = value; }
		}

		private string _password;
		public string Password { 
			get { return _password; }
			set { _password = value; }
		}

		private string _emailAddress;
		public string EmailAddress {
			get { return _emailAddress; }
			set { _emailAddress = value; }
		}

	#endregion

		//Constructors
		public User() { }

		public User ( string username, string password, string emailAddress ) {
			this._username = username;
			this._password = password;
			this._emailAddress = emailAddress;
		}

	}
}
