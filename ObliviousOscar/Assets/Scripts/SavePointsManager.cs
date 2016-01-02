using UnityEngine;
using System.Collections.Generic;

public class SavePointsManager
{
	SavePointsManager () {}

	static readonly Dictionary<int, OscarState> latestStates = new Dictionary<int, OscarState> ();
	static readonly Dictionary<int, OscarState> initialStates = new Dictionary<int, OscarState> ();

	static public OscarState LatestState {
		get { return latestStates[LevelManager.CurrentIndex]; }
		set { latestStates[LevelManager.CurrentIndex] = value; }
	}

	static public OscarState InitialState {
		get { return initialStates[LevelManager.CurrentIndex]; }
		set { initialStates[LevelManager.CurrentIndex] = value; }
	}

	static public bool HasLatestState {
		get { return latestStates.ContainsKey (LevelManager.CurrentIndex); }
	}
}
