using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject asteroidPrefab;

	//spawn every 'interval' seconds
	private float interval1;
	private float interval2;


	// Use this for initialization
	void Start () {
		interval1 = Random.Range (1f, 3f);
		interval2 = Random.Range (1f, 3f);

		// Need to revise this code to not have repeated intervals for each side, must be random each time
		InvokeRepeating ("SpawnAsteroid", interval1, interval2);
        // InvokeRepeating ("SpawnAsteroid", interval, interval);

	}
	
	void SpawnAsteroid() {
		GameObject EarthDestroyed = GameObject.Find("earth");
		Earth earth = EarthDestroyed.GetComponent<Earth> ();
		if (!earth.gameOver) {
			Instantiate (asteroidPrefab, transform.position, Quaternion.identity);
		}
	}
}
