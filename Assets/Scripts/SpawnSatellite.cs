﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnSatellite : MonoBehaviour {

	public GameObject satellitePrefab;
	public GameObject satellite2Prefab;
	public GameObject satellite3Prefab;
	public AudioSource sfxSuccess;
	public AudioSource sfxFail;

	void Update() {

		GameObject EarthDestroyed = GameObject.Find("earth");  
		Earth earth = EarthDestroyed.GetComponent<Earth> ();

		//first satellite, simple orbit
		if (Input.GetKeyDown("1") && !Earth.gameOver) {
			if (OreKeeper.totalOre >= 250) {
				sfxSuccess.Play ();
				print ("Satellite Purchased");
				OreKeeper.decreaseOre (250);
				buySatellite (1);
			} else {
				sfxFail.Play ();
			}
		}
		//second satellite, inception
		else if (Input.GetKeyDown("2") && !Earth.gameOver) {
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			if (OreKeeper.totalOre >= 450) {
				sfxSuccess.Play ();
				print("Satellite Purchased");
				OreKeeper.decreaseOre (450);
				buySatellite(2);
			} else {
				sfxFail.Play ();
			}
		}
		//third satellite, homing missiles
		else if (Input.GetKeyDown("3") && !Earth.gameOver) {
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			if (OreKeeper.totalOre >= 600) {
				sfxSuccess.Play ();
				print("Satellite Purchased");
				OreKeeper.decreaseOre (600);
				buySatellite(3);
			} else {
				sfxFail.Play ();
			}
		}
	}

	public void buySatellite(int type) {
		if (type == 1) {
			Vector2 satPos = new Vector2(10, 10);
			print("First Satellite");
			GameObject satellite = (GameObject)Instantiate(satellitePrefab, satPos, Quaternion.identity);
			satellite.GetComponent<Satellite>().satType = type;
		} else if (type == 2) {
			Vector2 satPos = new Vector2(10, 10);
			print("Second Satellite");
			GameObject satellite2 = (GameObject)Instantiate(satellite2Prefab, satPos, Quaternion.identity);
			satellite2.GetComponent<Satellite>().satType = type;
			GameObject satellite2Help = (GameObject)Instantiate(satellite2Prefab, satellite2.transform.position , Quaternion.identity);
			satellite2Help.transform.localScale = new Vector2 (.5f, .5f);
			satellite2Help.GetComponent<CircleCollider2D>().transform.localScale = new Vector2 (.5f, .5f);
			satellite2Help.GetComponent<Satellite>().parent = satellite2;
			satellite2Help.GetComponent<Satellite>().satType = 0;
			satellite2.GetComponent<Satellite>().child = satellite2Help;
		} else if (type == 3) {
			Vector2 satPos = new Vector2(10, 10);
			print("Third Satellite");
			GameObject satellite3 = (GameObject)Instantiate(satellite3Prefab, satPos, Quaternion.identity);
			satellite3.GetComponent<Satellite>().satType = type;
		}
	}

}
