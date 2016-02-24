using UnityEngine;
using System.Collections;

public class Satellite : MonoBehaviour {

	public float satellite_angle = 0.0f;
	public float radius;
	public int satType;
	public GameObject RedExplosion;

	void Start () {
		radius = Random.Range(2.5f, 5.5f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		this.gameObject.transform.position = new Vector2 (1.7f*Mathf.Sin (satellite_angle)*radius, 0.88f*Mathf.Cos (satellite_angle)*radius);
		if (satType == 1) {
			satellite_angle -= .03f;
		} else if (satType == 2) {
			satellite_angle -= .015f;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "missile(Clone)") {
			PlayExplosion ();
			Destroy (this.gameObject);
		} else if (col.gameObject.name == "satellite2(Clone)" || col.gameObject.name == "satellite(Clone)") {
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	void PlayExplosion() {
		GameObject explosion = (GameObject)Instantiate(RedExplosion);
		explosion.transform.position = transform.position;
	}
}

