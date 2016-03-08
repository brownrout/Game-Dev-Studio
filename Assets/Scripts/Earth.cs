using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

	public GameObject missilePrefab;
	private float missile_speed = 6.0f;
	public static bool gameOver;
	public bool firstTime = true;
	public GameObject EarthExplode;
	public GameObject gameOverText;
	public GameObject helperText;
	public GameObject titleText;
	public static int highScore;
	public AudioSource gameOverSFX;
	public AudioSource satDeadSFX2;
	public static AudioSource satDeadSFX;
	public static AudioSource AsteroidSFX;
	public AudioSource AsteroidSFX2;


	void Start() {
		print(highScore);
		gameOver = true;
		gameOverText.SetActive (true);
		helperText.SetActive (true);
		titleText.SetActive (true);
		ScoreKeeper.counter = 0.0f;
		satDeadSFX = satDeadSFX2;
		AsteroidSFX = AsteroidSFX2;
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

		if (ScoreKeeper.counter > highScore) {
			highScore = (int)ScoreKeeper.counter;
		}

		if (gameOver) {
			gameOverText.SetActive(true);
			helperText.SetActive (true);
			titleText.SetActive (true);
		}
		else {
			gameOverText.SetActive(false);
			titleText.SetActive (false);
			helperText.SetActive(false);
		}

		if (Input.GetKeyDown("space") && gameOver) {

			Level.lvl = 1;
			OreKeeper.totalOre = 0;

			if (firstTime) {
				gameOver = false;
				foreach (var gameObj in FindObjectsOfType(typeof(Spawn)) as Spawn[]) {
					gameObj.GetComponent<Spawn> ().StartAlt();
				}
			} else {
				Application.LoadLevel (Application.loadedLevel);
				firstTime = false;
				gameOver = false;
				foreach (var gameObj in FindObjectsOfType(typeof(Spawn)) as Spawn[]) {
					gameObj.GetComponent<Spawn> ().StartAlt();
				}
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "asteroid(Clone)" || col.gameObject.name == "asteroid2(Clone)") {
			this.transform.localScale = new Vector2 (0, 0);
			PlayExplosion();
			gameOver = true;
			firstTime = false;
			gameOverSFX.Play ();
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

	public static void SatDiedSound(){
		satDeadSFX.Play ();
	}

	public static void AsteroidExplode(){
		AsteroidSFX.Play ();
	}
}
