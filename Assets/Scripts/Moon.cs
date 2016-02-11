using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	public float angle = 90.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.gameObject.transform.position = new Vector2 (Mathf.Sin (angle)*2.5f,Mathf.Cos (angle)*2.5f);
		angle -= .025f;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "missile(Clone)")  {
			Destroy (this.gameObject);

		}
	}
}
