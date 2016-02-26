using UnityEngine;
using System.Collections;

public class Satellite : MonoBehaviour {

	public float satellite_angle = 0.0f;
	public float radius;
	public int satType;
	public GameObject RedExplosion;
	public GameObject parent;
	public GameObject child;

	void Start () {
		radius = Random.Range(2.5f, 5.5f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (satType != 0) {
			this.gameObject.transform.position = new Vector2 (1.55f * Mathf.Sin (satellite_angle) * radius, 0.86f * Mathf.Cos (satellite_angle) * radius);
			if (satType == 1) {
				satellite_angle -= .03f;
			} else if (satType == 2) {
				satellite_angle -= .01f;
			}
		} else {
			this.gameObject.transform.position = new Vector2 (parent.transform.position.x + Mathf.Sin (satellite_angle) * .95f, parent.transform.position.y + Mathf.Cos (satellite_angle) * .95f);
			satellite_angle -= .07f;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "missile(Clone)" || col.gameObject.name == "earth") {
			if (this.satType != 0) {
				PlayExplosion (1);
			} else {
				PlayExplosion (2);
			}

			if (this.satType == 2) {
				this.child.GetComponent<Satellite>().PlayExplosion(2);
			}
			Destroy (this.gameObject);
		} else if (col.gameObject.name == "satellite2(Clone)" || col.gameObject.name == "satellite(Clone)" || col.gameObject.name == "moon") {
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	public void PlayExplosion(int x) {
		if (x == 1) {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			explosion.transform.position = transform.position;
			Destroy (this.gameObject);
		} else {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			explosion.transform.localScale = new Vector2 (.5f, .5f);
			explosion.transform.position = transform.position;
			Destroy (this.gameObject);
		}
	}
}

