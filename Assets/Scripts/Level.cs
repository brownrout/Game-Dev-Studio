using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int lvl;

	// Use this for initialization
	void Start () {
		lvl = 1;
		print (lvl);
		InvokeRepeating ("LevelUp",1.0f,1.5f);
	}
	
	// Update is called once per frame
	void LevelUp () {
		
		GameObject currentScore = GameObject.Find("TimeText");  
		ScoreKeeper scoreText = currentScore.GetComponent<ScoreKeeper> ();

		GameObject EarthDestroyed = GameObject.Find("earth");  
		Earth earth = EarthDestroyed.GetComponent<Earth> ();

		if ( (int)scoreText.counter % 10 == 0 && !earth.gameOver) {
			lvl += 1;
			print (lvl);
		}

	}

}
