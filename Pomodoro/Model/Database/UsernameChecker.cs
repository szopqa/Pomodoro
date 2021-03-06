﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Model.Database {
	public class UsernameChecker : IExecutable {
		public string ConnectionString { get; }

		public UsernameChecker () {
			//setting connection string 
			this.ConnectionString = @"Data Source=pomidor.database.windows.net;
									Initial Catalog=Pomodoro;Persist Security Info=True;
									User ID=szopqa96;Password=Pomodoro.app";
		}

		/// <summary>
		/// Sends Sql command with username
		/// </summary>
		/// <returns>Returns null if username is available</returns>
		public User ExecuteQuery(string username, string password, string email) {

			int resultsFound = 0;

			using ( var connection = new SqlConnection(ConnectionString) ) {
				connection.Open();

				//Making query
				var command = new SqlCommand("SELECT * FROM Users WHERE username=@0", connection);
				command.Parameters.AddWithValue("0", username);

				try {

					using ( var reader = command.ExecuteReader() ) {

						//Reading results
						while ( reader.Read() ) {
							resultsFound++;
						}

						//Username found in database
						if ( resultsFound > 0 ) {
							User existingUser = new User() { Username = username};
							return existingUser;
						}
						else {
							//If username was not found in database, return null
							return null;
						}
					}

				}
				catch ( SqlException ex ) {
					return null;
				}

			}


		}



		public bool IsUsernameAvailable(string username) {

			var userFound = ExecuteQuery(username, null, null);

			if (userFound == null)
				return true;


			return false;
		}
	}
}
