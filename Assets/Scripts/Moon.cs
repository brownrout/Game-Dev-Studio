﻿using UnityEngine;
using System.Collections;

public class Moon : MonoBehaviour {

	public float moon_angle = 90.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.gameObject.transform.position = new Vector2 (Mathf.Sin (moon_angle)*2.2f,Mathf.Cos (moon_angle)*2.2f);
		moon_angle -= .025f;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "missile(Clone)")  {
			Destroy (this.gameObject);
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			OreText.increaseOre (250);
		}
	}
}

