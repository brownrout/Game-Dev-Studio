using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Satellite : MonoBehaviour {

	public float satellite_angle = 0.0f;
	public float radius;
	public int satType;
	public GameObject RedExplosion;
	public GameObject parent;
	public GameObject child;
	public GameObject target;
	public GameObject satellite3Prefab;
	public AudioSource explodeSFX;

	void Start () {
		if (satType == 3) {
			ShootHoning ();
		}
		radius = Random.Range(2.5f, 5.5f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (satType == 0) {
			//the inception child
			this.gameObject.transform.position = new Vector2 (parent.transform.position.x + Mathf.Sin (satellite_angle) * .95f, parent.transform.position.y + Mathf.Cos (satellite_angle) * .95f);
			satellite_angle -= .07f;
		} else if (satType == -1) {
			Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
			if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0) {
				Destroy (this.gameObject);
			}
			if (target != null) {
				Vector2 targetPos = new Vector2 (target.transform.position.x, target.transform.position.y);
				Vector2 honePos = new Vector2 (transform.position.x, transform.position.y);
				Vector2 direction = targetPos - honePos;
				// Try it without Normalize
				direction.Normalize ();
				this.GetComponent<Rigidbody2D> ().velocity = direction * 5;
			}
		} else {
			this.gameObject.transform.position = new Vector2 (1.55f * Mathf.Sin (satellite_angle) * radius, 0.86f * Mathf.Cos (satellite_angle) * radius);
			if (satType == 1) {
				satellite_angle -= .03f;
			} else if (satType == 2) {
				satellite_angle -= .01f;
			} else if (satType == 3) {
				satellite_angle -= .02f;
			}
		}
	}

	void ShootHoning () {
		StartCoroutine (Wait ());
		var closestGameObject = GameObject.FindGameObjectsWithTag("Enemy")
			.OrderBy(o => (o.transform.position - transform.position).sqrMagnitude)
			.FirstOrDefault();
		if (closestGameObject != null) {
			GameObject satellite3Help = (GameObject)Instantiate (satellite3Prefab, this.transform.position, Quaternion.identity);
			satellite3Help.transform.localScale = new Vector2 (.4f, .4f);
			satellite3Help.GetComponent<CircleCollider2D> ().transform.localScale = new Vector2 (.4f, .4f);
			satellite3Help.GetComponent<Satellite> ().satType = -1;
			satellite3Help.GetComponent<Satellite> ().target = closestGameObject;
		}
		Invoke("ShootHoning", 2.5f);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "missile(Clone)" || col.gameObject.name == "asteroid3(Clone)") {
			if (this.satType == 0) {
				PlayExplosion (2);
			} else if (this.satType == -1) {
				PlayExplosion (3);
			} else {
				PlayExplosion (1);
			}
			if (this.satType == 2) {
				this.child.GetComponent<Satellite>().PlayExplosion(2);
			}
		} else if (col.gameObject.name == "satellite3(Clone)(Clone)" || col.gameObject.name == "satellite3(Clone)" || col.gameObject.name == "satellite2(Clone)" || col.gameObject.name == "satellite(Clone)" || col.gameObject.name == "moon") {
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		} else if (col.gameObject.name == "asteroid(Clone)" || col.gameObject.name == "asteroid2(Clone)") {
			if (this.satType == -1) {
				PlayExplosion (-1);
			}
		} else if (col.gameObject.name == "earth" && this.satType == -1) {
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}

	public void PlayExplosion(int x) {
		if (x == 1) {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			explosion.transform.position = transform.position;
			Earth.SatDiedSound ();
			Destroy (this.gameObject);
		} else if (x == 0) {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			explosion.transform.localScale = new Vector2 (.5f, .5f);
			explosion.transform.position = transform.position;
			Earth.SatDiedSound ();
			Destroy (this.gameObject);
		} 
		else if (x == 2) {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			// explosion.transform.localScale = new Vector2 (.5f, .5f);
			explosion.transform.position = transform.position;
			Earth.SatDiedSound ();
			Destroy (this.gameObject);
		} else if (x == 3) {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			explosion.transform.localScale = new Vector2 (.4f, .4f);
			explosion.transform.position = transform.position;
			Earth.SatDiedSound ();
			Destroy (this.gameObject);
		}
		else if (x == -1) {
			GameObject explosion = (GameObject)Instantiate (RedExplosion);
			explosion.transform.localScale = new Vector2 (.4f, .4f);
			explosion.transform.position = transform.position;
			Destroy (this.gameObject);
		}
	}

	IEnumerator Wait() //turn level text off after 3 seconds
	{
		yield return new WaitForSeconds(2.0f);
	}
}

