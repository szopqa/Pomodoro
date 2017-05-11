using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Model {
	
	/// <summary>
	/// Class storing all user preferences saved in database
	/// </summary>
	public class UserPreferences {

	#region Properties

		private int _workingSessionLength = 25;
		public int WorkingSessionLength {
			get { return _workingSessionLength; }
			set { _workingSessionLength = value; }
		}

		private int _shortBreakLength = 4;
		public int ShortBreakLength {
			get { return _shortBreakLength; }
			set { _shortBreakLength = value; }
		}

		private int _longBreakLength = 10;
		public int LongBreakLength {
			get { return _longBreakLength; }
			set { _longBreakLength = value; }
		}

	#endregion


		//TODO: Getting data from database
	}
}
