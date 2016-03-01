using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour { 

	public GameObject ExplosionGOprefab;


	void FixedUpdate() {
		GameObject Earth2 = GameObject.Find("earth");
		Physics2D.IgnoreCollision(Earth2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "asteroid(Clone)" || col.gameObject.name == "asteroid2(Clone)" || col.gameObject.name == "asteroid3(Clone)" || col.gameObject.name == "moon" || col.gameObject.name == "satellite(Clone)" || col.gameObject.name == "satellite2(Clone)" || col.gameObject.name == "satellite3(Clone)")  {
			Destroy (this.gameObject);
		}
	}		
}
