using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

	public GameObject missilePrefab;
	private float missile_speed = 6.0f;
	public bool gameOver;
	public bool firstTime = true;
	public GameObject EarthExplode;
	public GameObject gameOverText;


	void Start() {
		gameOver = true;
		gameOverText.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !gameOver) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
			Vector2 earthPos = new Vector2(transform.position.x, transform.position.y);
			Vector2 direction = mousePos - earthPos;
			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			GameObject projectile = (GameObject)Instantiate(missilePrefab, earthPos, rotation);
			projectile.GetComponent<Rigidbody2D>().velocity = direction * missile_speed;
		}

		if (gameOver) {
			gameOverText.SetActive(true);
		}
		else {
			gameOverText.SetActive(false);
		}

		if (Input.GetKeyDown("space") && gameOver) {
			if (firstTime) {
				gameOver = false;
			} else {
				Application.LoadLevel (Application.loadedLevel);
				firstTime = false;
				gameOver = false;
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "asteroid(Clone)" || col.gameObject.name == "asteroid2(Clone)") {
			this.transform.localScale = new Vector2 (0, 0);
			PlayExplosion();
			gameOver = true;
			firstTime = false;
			gameOverHelp ();
		}
	}

	void gameOverHelp() {
		// blow everything up

		GameObject moon = GameObject.Find("moon");
		if (moon != null) {
			moon.GetComponent<Moon> ().PlayExplosion ();
		}

		foreach (var gameObj in FindObjectsOfType(typeof(Asteroid)) as Asteroid[]) {
			gameObj.GetComponent<Asteroid> ().PlayExplosion(gameObj.GetComponent<Asteroid> ().asteroidType);
		}

		foreach (var gameObj in FindObjectsOfType(typeof(Satellite)) as Satellite[]) {
			gameObj.GetComponent<Satellite> ().PlayExplosion(gameObj.GetComponent<Satellite>().satType);
		}
	}

	void PlayExplosion() {
		GameObject explosion = (GameObject)Instantiate(EarthExplode);
		explosion.transform.position = transform.position;
	}
}
