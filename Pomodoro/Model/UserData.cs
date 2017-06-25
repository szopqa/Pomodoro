namespace Pomodoro.Model {
	public class UserData {

		#region Properties

		private int _workLengthInSeconds;
		public int WorkLengthInSeconds {
			get { return _workLengthInSeconds; }
			set { _workLengthInSeconds = value; }
		}


		private int _restLengthInSeconds;
		public int RestLengthInSeconds {
			get { return _restLengthInSeconds; }
			set { _restLengthInSeconds = value; }
		}
		#endregion


		//Ctor
		public UserData ( ) {
			_workLengthInSeconds = 0;
			_restLengthInSeconds = 0;
		}

	}	
}
