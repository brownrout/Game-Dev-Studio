using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnSatellite : MonoBehaviour {

	public GameObject satellitePrefab;
	public GameObject satellite2Prefab;

	void Update() {
		if (Input.GetKeyDown("1")) {
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			if (OreText.totalOre >= 250) {
				print("Satellite Purchased");
				OreText.decreaseOre (250);
				buySatellite (1);
			}
		}
		else if (Input.GetKeyDown("2")) {
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			if (OreText.totalOre >= 450) {
				print("Satellite Purchased");
				OreText.decreaseOre (450);
				buySatellite(2);
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
		}
	}

}
