using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private float asteroid_speed = Random.Range(3.5F, 6F);
	private float destroy_time = 30.0f;
	public GameObject BrownExplosion;
	public int asteroidType;
	public bool destroyable = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (Wait());
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if ( screenPosition.x < 0 && screenPosition.y > Screen.height) { //top left
			Vector2 dir = Vector2.right;
			dir.y = Random.Range (-0.3F, -1.3F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;
		} else if ( screenPosition.x > Screen.width && screenPosition.y > Screen.height ) { //top right
			Vector2 dir = Vector2.left;
			dir.y = Random.Range (-0.3F, -1.3F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.x < 0 && screenPosition.y < 0 ) { //bottom left
			Vector2 dir = Vector2.right;
			dir.y = Random.Range (0.3F, 1.3F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.x > Screen.width && screenPosition.y < 0 ) {  //bottom right
			Vector2 dir = Vector2.left;
			dir.y = Random.Range (0.3F, 1.3F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.x > Screen.width) {  //right
			Vector2 dir = Vector2.left;
			dir.y = Random.Range (-0.3F, 0.3F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.x < 0) {  //left
			Vector2 dir = Vector2.right;
			dir.y = Random.Range (-0.3F, 0.3F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		}
		Destroy (this.gameObject, destroy_time);  //destroy asteroids that have flown off screen

	}

	void FixedUpdate() {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if(destroyable) {
			if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0) {
				Destroy (this.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "moon" && this.asteroidType == 3) {
			PlayExplosion (this.asteroidType);
		} else if (col.gameObject.name == "satellite3(Clone)(Clone)" && this.asteroidType == 3) {
			// Do Nothing for the Asteroids
		}
		else if (col.gameObject.name == "earth") {
			PlayExplosion (this.asteroidType);
		} else if (col.gameObject.name == "missile(Clone)" || col.gameObject.name == "satellite(Clone)" || col.gameObject.name == "satellite2(Clone)" || col.gameObject.name == "satellite3(Clone)" || col.gameObject.name == "satellite3(Clone)(Clone)") {
			PlayExplosion (this.asteroidType);

			if (this.asteroidType == 2) {  //bigger asteroids give this much additional ore
				OreKeeper.increaseOre (25);
			}
			if (this.asteroidType == 3) {  //bigger asteroids give this much additional ore
				OreKeeper.increaseOre (75);
			}
			OreKeeper.increaseOre (25);  //smaller asteroids give the baseline ore
		}
	}


	public void PlayExplosion(int x) {
		if (x == 1) {
			GameObject explosion = (GameObject)Instantiate (BrownExplosion);
			explosion.transform.position = transform.position;
			Earth.AsteroidExplode ();
			Destroy (this.gameObject);
		} else if (x == 2) {
			GameObject explosion = (GameObject)Instantiate (BrownExplosion);
			explosion.transform.position = transform.position;
			explosion.transform.localScale = new Vector2 (2f, 2f);
			Earth.AsteroidExplode ();
			Destroy (this.gameObject);
		} else {
			GameObject explosion = (GameObject)Instantiate (BrownExplosion);
			explosion.transform.position = transform.position;
			explosion.transform.localScale = new Vector2 (.5f, .5f);
			Earth.AsteroidExplode ();
			Destroy (this.gameObject);
		}
	}

	IEnumerator Wait() //turn level text off after 3 seconds
	{
		yield return new WaitForSeconds(3.0f);
		destroyable = true;
	}
}
