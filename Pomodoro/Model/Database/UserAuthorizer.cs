using System.Data.SqlClient;

namespace Pomodoro.Model.Database{


	public class UserAuthorizer :IExecutable {

		private string _connectionString;
		public string ConnectionString => _connectionString;

		public UserAuthorizer() {
			//setting connection string 
			this._connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
											C:\Databases\PomodoroDatabase.mdf;
											Integrated Security=True;Connect Timeout=30";
		}

		/// <summary>
		/// Checking if username exists in database
		/// </summary>
		/// <returns>Returns User object if found in DB or null if not</returns>
		public User ExecuteQuery(string username, string password, string email) {

			int resultsFound = 0;

			using ( var connection = new SqlConnection(ConnectionString) ) {
				connection.Open();

				//Making query
				var command = new SqlCommand("SELECT * FROM Users WHERE username=@0 AND password=@1", connection);
				command.Parameters.AddWithValue("0", username);
				command.Parameters.AddWithValue("1", password);

				try {

					using (var reader = command.ExecuteReader()) {

						//Reading results
						while ( reader.Read()) {
							resultsFound++;
						}

						//User found in database
						if (resultsFound > 0) {
							User loggedUser = new User() {Username = username, Password = password};
							return loggedUser;
						}
						else {
							//If user was not found in database, return null
							return null;
						}
					}

				}catch (SqlException ex) {
					return null;
				}
				
			}

		}





	}
}
