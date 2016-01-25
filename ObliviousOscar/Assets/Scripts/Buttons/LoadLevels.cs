using UnityEngine;
using System.Collections;

public class LoadLevels : MonoBehaviour {

	public void Tutorial (){
		LevelManager.Load ("Level 1.1-Tutorial");
	}
	public void Level1_2 (){
		LevelManager.Load ("Level 1.2");
	}
	public void Level1_3 (){
		LevelManager.Load ("Level 1.3");
	}
	public void Level1_4 (){
		LevelManager.Load ("Level 1.4");
	}
	public void Level1_5 (){
		LevelManager.Load ("Level 1.5");
	}
	public void Level2_1 (){
		LevelManager.Load ("Level 2.1");
	}
	public void Level2_2 (){
		LevelManager.Load ("Level 2.2");
	}
	public void Level2_3 (){
		LevelManager.Load ("Level 2.3");
	}

}