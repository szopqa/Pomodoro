using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Model.Database {
	interface IExecutable {

		string ConnectionString { get; }

		User ExecuteQuery(string username, string password, string email);

	}
}
