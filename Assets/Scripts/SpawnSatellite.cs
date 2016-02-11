using UnityEngine;
using System.Collections;

public class SpawnSatellite : MonoBehaviour {

	public GameObject satellitePrefab;

	public void buySatellite() {
		Vector2 satPos = new Vector2(10, 10);
		GameObject satellite = (GameObject)Instantiate(satellitePrefab, satPos, Quaternion.identity);
	}
}
