using UnityEngine;
using System.Collections;

public class Satellite : MonoBehaviour {

	public float satellite_angle = 0.0f;
	public float radius;

	void Start () {
		radius = Random.Range(2.5f, 5.5f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		this.gameObject.transform.position = new Vector2 (Mathf.Sin (satellite_angle)*radius, Mathf.Cos (satellite_angle)*radius);
		satellite_angle -= .03f;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "missile(Clone)")  {
			Destroy (this.gameObject);
		}
	}
}

