using System.Data.SqlClient;

namespace Pomodoro.Model.Database{


	public class UserAuthorizer :IExecutable {

		public string ConnectionString { get; }

		public UserAuthorizer() {
			//setting connection string 
			this.ConnectionString = @"Data Source=pomidor.database.windows.net;
									Initial Catalog=Pomodoro;Persist Security Info=True;
									User ID=szopqa96;Password=Pomodoro.app";
		}

		/// <summary>
		/// Checking if username exists in database
		/// </summary>
		/// <returns>Returns User object if found in DB or null if not</returns>
		public User ExecuteQuery(string username, string password, string email) {

			int resultsFound = 0;

			int _userID = 0;
			string _userEmail = "";


			using ( var connection = new SqlConnection(ConnectionString) ) {

				try {

				connection.Open();

				//Making query
				var command = new SqlCommand("SELECT * FROM Users WHERE username=@0 AND password=@1", connection);
				command.Parameters.AddWithValue("0", username);
				command.Parameters.AddWithValue("1", password);

				

					using (var reader = command.ExecuteReader()) {

						//Reading results
						while ( reader.Read()) {
							resultsFound++;
							_userID = (int)reader[0];
							_userEmail = reader[3].ToString();
						}

						//User found in database
						if (resultsFound > 0) {
							User loggedUser = new User() {UserId = _userID,
														  Username = username,
														  Password = password,
														  EmailAddress = _userEmail};
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
