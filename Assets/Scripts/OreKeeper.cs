using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OreKeeper : MonoBehaviour {

	public int totalOre = 0;
	
	// Update is called once per frame
	void Update () {
		UpdateOreText ();
		UpdateButton ();
	}

	private void UpdateOreText () {
		GameObject oreTextObject = this.gameObject;
		Text textComponent = oreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Ore: {0}", totalOre);
	}

	private void UpdateButton () {
		GameObject buyButton = GameObject.Find("purchaseSatellite");  
		Button button = buyButton.GetComponent<Button> ();
		if (totalOre <= 250) {
			button.enabled = false;
		} else
			button.enabled = true;
	}

	public void increaseOre (int amount) {
		totalOre += amount;
	}

	public void decreaseOre (int amount) {
		totalOre -= amount;
	}



}
