using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private float asteroid_speed = Random.Range(4F, 6F);
	private float destroy_time = 30.0f;
	public GameObject BrownExplosion;

	// Use this for initialization
	void Start () {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);

		if ( screenPosition.x < 0 && screenPosition.y > Screen.height) {
			Vector2 dir = Vector2.right;
			dir.y = Random.Range (-0.1F, -2.0F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;
		} else if ( screenPosition.x > Screen.width && screenPosition.y > Screen.height ) {
			Vector2 dir = Vector2.left;
			dir.y = Random.Range (-0.1F, -2.0F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.x < 0 && screenPosition.y < 0 ) {
			Vector2 dir = Vector2.right;
			dir.y = Random.Range (0.1F, 2.0F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.x > Screen.width && screenPosition.y < 0 ) {
			Vector2 dir = Vector2.left;
			dir.y = Random.Range (0.1F, 2.0F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		}

		Destroy (this.gameObject, destroy_time);

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "earth") {
			PlayExplosion ();
			Destroy (this.gameObject);
		} else if (col.gameObject.name == "missile(Clone)" || col.gameObject.name == "satellite(Clone)" || col.gameObject.name == "satellite2(Clone)") {
			PlayExplosion ();
			Destroy (this.gameObject);
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			OreText.increaseOre (25);
		}
	}


	public void PlayExplosion() {
		GameObject explosion = (GameObject)Instantiate(BrownExplosion);
		explosion.transform.position = transform.position;
	}

}
