using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private float asteroid_speed = Random.Range(3.5F, 6F);
	private float destroy_time = 30.0f;
	public GameObject BrownExplosion;
	public int asteroidType;

	// Use this for initialization
	void Start () {

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

		Destroy (this.gameObject, destroy_time);

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "earth") {
			PlayExplosion (this.asteroidType);
		} else if (col.gameObject.name == "missile(Clone)" || col.gameObject.name == "satellite(Clone)" || col.gameObject.name == "satellite2(Clone)") {
			PlayExplosion (this.asteroidType);
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			OreText.increaseOre (25);
		}
	}


	public void PlayExplosion(int x) {
		if (x == 1) {
			GameObject explosion = (GameObject)Instantiate(BrownExplosion);
			explosion.transform.position = transform.position;
			Destroy (this.gameObject);
		} else {
			GameObject explosion = (GameObject)Instantiate(BrownExplosion);
			explosion.transform.position = transform.position;
			explosion.transform.localScale = new Vector2 (2f, 2f);
			Destroy (this.gameObject);
		}
	}

}
