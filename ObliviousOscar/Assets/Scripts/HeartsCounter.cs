using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartsCounter : MonoBehaviour {

	public static int Hearts = 6;

	public GameObject Heart1;
	public GameObject Heart2;
	public GameObject Heart3;

	public Sprite halfHeart;
	public Sprite emptyHeart;

	void Update(){
		if (Hearts <= 5) {
			Heart3.GetComponent<Image> ().overrideSprite = halfHeart;
			if (Hearts <= 4) {
				Heart3.GetComponent<Image> ().overrideSprite = emptyHeart;
				if (Hearts <= 3) {
					Heart2.GetComponent<Image> ().overrideSprite = halfHeart;
					if (Hearts <= 2) {
						Heart2.GetComponent<Image> ().overrideSprite = emptyHeart;
						if (Hearts == 1) {
							Heart1.GetComponent<Image> ().overrideSprite = halfHeart;
						}
					}
				}
			}
		}
	}

	public static void RemoveALife() {
		if (Hearts > 1) {
			--Hearts;
		} 
		/*
		 * TODO Reset level if no lives left
		 * else {
		}*/
	}
}
