using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OreKeeper : MonoBehaviour {

	public int totalOre = 0;
	
	// Update is called once per frame
	void Update () {
		UpdateOreText ();
	}

	private void UpdateOreText () {
		GameObject oreTextObject = this.gameObject;
		Text textComponent = oreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Ore: {0}", totalOre);
	}

	public void increaseOre (int amount) {
		totalOre += amount;
	}

	public void decreaseOre (int amount) {
		totalOre -= amount;
	}



}
