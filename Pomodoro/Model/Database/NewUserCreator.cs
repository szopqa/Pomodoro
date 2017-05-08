using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Model.Database {
	public class NewUserCreator : IExecutable {
		public string ConnectionString { get; }

		public NewUserCreator() {
			//setting connection string
			this.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
										C:\Databases\PomodoroDatabase.mdf;
										Integrated Security=True;Connect Timeout=30";
		}

		/// <summary>
		/// Adds new user to database 
		/// </summary>
		/// <returns>Returns new User object if succeded, if not returns null</returns>
		public User ExecuteQuery(string username, string password, string email) {

			using (SqlConnection conn = new SqlConnection(this.ConnectionString)) {
				conn.Open();

				SqlCommand insertCommand = new SqlCommand("INSERT INTO Users(username,password,email_address) VALUES (@0,@1,@2)",conn);
				insertCommand.Parameters.Add(new SqlParameter("0", username));
				insertCommand.Parameters.Add(new SqlParameter("1", password));
				insertCommand.Parameters.Add(new SqlParameter("2", email));

				try {
					insertCommand.ExecuteNonQuery();
					return new User(username, password, email);
				}
				catch (SqlException ex) {
					return null;
				}

			}

		}




	}
}
