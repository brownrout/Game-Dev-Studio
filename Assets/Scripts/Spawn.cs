using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject asteroidPrefab;
	private float randTime;
	private float initialDelay;

	// Use this for initialization
	void Start () {
		// Need to revise this code to not have repeated intervals for each side, must be random each time
		randTime = Random.Range (3.0f, 7.0f);
		initialDelay = Random.Range (0.5f, 5.0f);
		Invoke ("SpawnAsteroid", initialDelay);
	}

	void Update() {

		// Progressive Difficulty - Hardcoded for now, will update down the line

		GameObject levelObj = GameObject.Find("earth");  
		Level level = levelObj.GetComponent<Level> ();

		switch (level.lvl)
		{
		case 1:
			randTime = Random.Range (5.0f, 8.0f);
			break;
		case 2:
			randTime = Random.Range (4.0f, 7.0f);
			break;
		case 3:
			randTime = Random.Range (3.0f, 6.0f);
			break;
		case 4:
			randTime = Random.Range (2.0f, 5.0f);
			break;
		case 5:
			randTime = Random.Range (1.5f, 3.0f);
			break;
		default:
			randTime = Random.Range (1.0f, 2.0f);
			break;
		}
	}
	
	void SpawnAsteroid() {
		GameObject EarthDestroyed = GameObject.Find("earth");
		Earth earth = EarthDestroyed.GetComponent<Earth> ();
		if (!earth.gameOver) {
//			float offset = Random.Range(0,1.0f);
			Instantiate (asteroidPrefab, transform.position, Quaternion.identity);
			Invoke ("SpawnAsteroid", randTime);
		}
	}
}
