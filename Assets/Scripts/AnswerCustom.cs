using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabric.Answers;

public class AnswerCustom : MonoBehaviour {


	public static void LogLevel (string LevelName, string Attribute, object Detail) {

		Answers.LogLevelStart ( LevelName, new Dictionary<string, object> { {Attribute, Detail} } );
	}

	public static void LogDroneFocusMiss (string FocusMiss, string Attribute, object Detail) {

		Answers.LogCustom (FocusMiss, new Dictionary<string, object> { {Attribute, Detail} } );
	}

	public static void LogDroneJamTime (string JamTime, string Attribute, object Detail) {

		Answers.LogCustom (JamTime, new Dictionary<string, object> { {Attribute, Detail} } );
	}

	public static void LogDroneJamInterval (string JamInterval, string Attribute, object Detail) {

		Answers.LogCustom (JamInterval, new Dictionary<string, object> { {Attribute, Detail} } );
	}

	public static void LogMazeEscapeInterval (string EscapeInterval, string Attribute, object Detail) {

		Answers.LogCustom (EscapeInterval, new Dictionary<string, object> { {Attribute, Detail} } );
	}

	public static void LogDroneJamError (string JamError, string Attribute1, object Detail1, string Attribute2, object Detail2) {

		Answers.LogCustom (JamError, new Dictionary<string, object> { 
			{Attribute1, Detail1}, 
			{Attribute2, Detail2} 
		} );
	}


}
