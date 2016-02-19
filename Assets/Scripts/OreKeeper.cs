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
		GameObject buyButton2 = GameObject.Find("purchaseSatellite2");  

		Button button = buyButton.GetComponent<Button> ();
		Button button2 = buyButton2.GetComponent<Button> ();

		if (totalOre < 250) {
			button.enabled = false;
		} else {
			button.enabled = true;
		}

		if (totalOre < 450) {
			button2.enabled = false;
		} else {
			button2.enabled = true;
		}
	}

	public void increaseOre (int amount) {
		totalOre += amount;
	}

	public void decreaseOre (int amount) {
		totalOre -= amount;
	}



}
