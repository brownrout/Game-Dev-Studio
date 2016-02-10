using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private float asteroid_speed = Random.Range(4F, 6F);
	private float destroy_time = 20.0f;

	// Use this for initialization
	void Start () {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);

		if ( screenPosition.x < 0) {
			Vector2 dir = Vector2.right;
			dir.y = Random.Range (-0.7F, 0.7F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;
		} else if ( screenPosition.x > Screen.width ) {
			Vector2 dir = Vector2.left;
			dir.y = Random.Range (-0.7F, 0.7F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.y < 0 ) {
			Vector2 dir = Vector2.up;
			dir.x = Random.Range (-0.7F, 0.7F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		} else if ( screenPosition.y > Screen.height ) {
			Vector2 dir = Vector2.down;
			dir.x = Random.Range (-0.7F, 0.7F);
			GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;	
		}

		Destroy (this.gameObject, destroy_time);

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "earth") {
			Destroy (this.gameObject);
		} else if (col.gameObject.name == "missile(Clone)") {
			Destroy (this.gameObject);
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			OreText.increaseOre (50);
		}
	}

}
