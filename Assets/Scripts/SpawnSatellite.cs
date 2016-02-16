using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnSatellite : MonoBehaviour {

	public GameObject satellitePrefab;

	void Update() {
		if (Input.GetKeyDown("space")) {
			print("Satellite Purchased");
			GameObject oreScore = GameObject.Find("OreText");  
			OreKeeper OreText = oreScore.GetComponent<OreKeeper> ();
			if (OreText.totalOre >= 250) {
				OreText.decreaseOre (250);
				buySatellite ();
			}
		}
	}

	public void buySatellite() {
		Vector2 satPos = new Vector2(10, 10);
		GameObject satellite = (GameObject)Instantiate(satellitePrefab, satPos, Quaternion.identity);
	}
}
