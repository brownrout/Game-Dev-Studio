using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject asteroidPrefab;

	//spawn every 'interval' seconds
	public float interval = 3;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnAsteroid", interval, interval);
	}
	
	void SpawnAsteroid() {
		Instantiate (asteroidPrefab, transform.position, Quaternion.identity);

	}
}
