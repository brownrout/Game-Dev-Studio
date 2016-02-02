using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private float asteroid_speed = 5.0f;

	// Use this for initialization
	void Start () {
		Vector2 dir = Vector2.right;
		dir.y = Random.Range(-0.5F, 0.5F);
		GetComponent<Rigidbody2D> ().velocity = dir.normalized * asteroid_speed;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "earth") {
			Destroy (this.gameObject);
		} else if (col.gameObject.name == "missile(Clone)") {
			Destroy (this.gameObject);
		}
	}
}
