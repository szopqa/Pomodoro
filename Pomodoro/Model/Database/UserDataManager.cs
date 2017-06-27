using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Model.Database{

	public class UserDataManager : IExecutable{
		public string ConnectionString { get; }

		
		//Constructor
		public UserDataManager() {
			this.ConnectionString = @"";
		}


		public User ExecuteQuery(string username, string password, string email) {
			throw new NotImplementedException();
		}
	}
}
