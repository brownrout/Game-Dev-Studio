using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour { 

	void FixedUpdate() {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0) {
			Destroy (this.gameObject);
		}

	}
}
