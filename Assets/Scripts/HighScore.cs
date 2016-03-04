using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	private void UpdateBestText () {
		GameObject bestTextObject = this.gameObject;
		Text textComponent = bestTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Best: {0}", Earth.highScore);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBestText ();
	}
}
