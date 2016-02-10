using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

	public GameObject missilePrefab;
	private float missile_speed = 6.0f;
	public bool gameOver = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !gameOver) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
			Vector2 earthPos = new Vector2(transform.position.x, transform.position.y);
			Vector2 direction = mousePos - earthPos;
			direction.Normalize();
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			GameObject projectile = (GameObject)Instantiate(missilePrefab, earthPos, rotation);
			projectile.GetComponent<Rigidbody2D>().velocity = direction * missile_speed;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "asteroid(Clone)") {
			this.transform.localScale = new Vector2 (0, 0);
			gameOver = true;
		}
	}
}
