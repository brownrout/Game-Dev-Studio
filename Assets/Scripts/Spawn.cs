using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject asteroidPrefab;
	public GameObject asteroid2Prefab;
	public GameObject asteroid3Prefab;
	private float randTime;
	private float initialDelay;

	// Use this for initialization
	public void StartAlt () {
		// Random time range between each asteroid spawn
		randTime = Random.Range (4.0f, 10.0f);
		initialDelay = Random.Range (0.5f, 5.0f);
		Invoke ("SpawnAsteroid", initialDelay);
	}

	void Update() {

		GameObject levelObj = GameObject.Find("earth");  
		Level level = levelObj.GetComponent<Level> ();
	
		switch (level.lvl)
		{
		// progressive level difficulty
		case 1:
			randTime = Random.Range (8.0f, 12.0f);
			break;
		case 2:
			randTime = Random.Range (6.0f, 9.0f);
			break;
		case 3:
			randTime = Random.Range (3.0f, 7.0f); 
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
		Level level = EarthDestroyed.GetComponent<Level> ();

		if (!earth.gameOver) {	
			if (level.lvl < 3) {
				// spawn larger asteroids after level 2
				GameObject asteroid = (GameObject)Instantiate (asteroidPrefab, transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
				asteroid.GetComponent<Asteroid> ().asteroidType = 1;
			} else if (level.lvl < 5) {
				int x = Random.Range (0, 5);
				if (x == 3) {
					// spawn a larger asteroid every 1 in 4
					GameObject asteroid = (GameObject)Instantiate (asteroid2Prefab, transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
					asteroid.GetComponent<Asteroid> ().asteroidType = 2;
				} else {
					GameObject asteroid = (GameObject)Instantiate (asteroidPrefab, transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
					asteroid.GetComponent<Asteroid> ().asteroidType = 1;
				}
			} else {
				int y = Random.Range (0, 10);
				if (y == 6) {
					// spawn a larger asteroid every 1 in 3
					GameObject asteroid = (GameObject)Instantiate (asteroid3Prefab, transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
					asteroid.GetComponent<Asteroid> ().asteroidType = 3;
				} else {
					int x = Random.Range (0, 4);
					if (x == 3) {
						// spawn a larger asteroid every 1 in 3
						GameObject asteroid = (GameObject)Instantiate (asteroid2Prefab, transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
						asteroid.GetComponent<Asteroid> ().asteroidType = 2;
					} else {
						GameObject asteroid = (GameObject)Instantiate (asteroidPrefab, transform.position, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
						asteroid.GetComponent<Asteroid> ().asteroidType = 1;
					}
				}
			}
			Invoke ("SpawnAsteroid", randTime);
		}
	}
}
