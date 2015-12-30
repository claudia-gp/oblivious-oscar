using UnityEngine;
using System.Collections.Generic;

public class SavePointsManager
{
	SavePointsManager () {}

	static readonly Dictionary<int, Vector3> latestPositions = new Dictionary<int, Vector3> ();
	static readonly Dictionary<int, Vector3> initialPositions = new Dictionary<int, Vector3> ();

	static public Vector3 LatestPosition {
		get { return latestPositions[LevelManager.CurrentIndex]; }
		set { latestPositions[LevelManager.CurrentIndex] = value; }
	}

	static public Vector3 InitialPosition {
		get { return initialPositions[LevelManager.CurrentIndex]; }
		set { initialPositions[LevelManager.CurrentIndex] = value; }
	}

	static public bool HasLatestPosition {
		get { return latestPositions.ContainsKey (LevelManager.CurrentIndex); }
	}
}
