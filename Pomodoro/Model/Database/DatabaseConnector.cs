using System;
using System.Data.SqlClient;

/*DB tutorial
https://www.codeproject.com/Articles/823854/How-to-connect-SQL-Database-to-your-Csharp-program */

namespace Pomodoro.Model.Database {
	public class DatabaseConnector {

		public static void Connect() {

			string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
										C:\Databases\PomodoroDatabase.mdf;
										Integrated Security=True;Connect Timeout=30";

			
			using (SqlConnection conn = new SqlConnection(ConnectionString)) {
				
				conn.Open();

				SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE user_id = @0", conn);
				//command.Parameters.Add("0", 1);
				command.Parameters.AddWithValue("0", 1);


				using (SqlDataReader reader = command.ExecuteReader()) {
					System.Console.WriteLine("ID\tLogin\tPassword\t");
					while (reader.Read()) {
						System.Console.WriteLine(String.Format("{0} \t | {1} \t | {2}", reader[0], reader[1], reader[2]));
					}
				}

				Console.WriteLine("Data displayed! Now press enter to move to the next section!");
				Console.ReadLine();
				Console.Clear();

				/* Above code was used to display the data from the Database table!
                 * This following section explains the key features to use 
                 * to add the data to the table. This is an example of another
                 * SQL Command (INSERT INTO), this will teach the usage of parameters and connection.*/
				
				/*
				System.Console.WriteLine("\nInsert into command");

				SqlCommand insertCommand = new SqlCommand("INSERT INTO Users(username,password) VALUES (@0,@1)", conn);
				insertCommand.Parameters.Add(new SqlParameter("0", "administrator"));
				insertCommand.Parameters.Add(new SqlParameter("1", "administrator"));

				System.Console.WriteLine("Command Executed! Total rows affected are " + insertCommand.ExecuteNonQuery());

				Console.WriteLine("Done! Press enter to move to the next step");
				Console.ReadLine();
				Console.Clear();
				*/

				/* In this section there is an example of the Exception case
                 * Thrown by the SQL Server, that is provided by SqlException 
                 * Using that class object, we can get the error thrown by SQL Server.
                 * In my code, I am simply displaying the error! */
				Console.WriteLine("Now the error trial!");

				try {
					SqlCommand errorCommand = new SqlCommand("Select * From someWrongTable", conn);
					errorCommand.ExecuteNonQuery();
				}
				catch (SqlException er) {
					Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
				}

				

			}

		}
		
	}
}
