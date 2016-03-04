using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static float counter = 0.0f;

	void Update () {
		GameObject EarthDestroyed = GameObject.Find("earth");  
		Earth earth = EarthDestroyed.GetComponent<Earth> ();
		if (!Earth.gameOver) {
			counter += Time.deltaTime;
			UpdateScoreText ();
		}
	}

	private void UpdateScoreText () {
		GameObject scoreTextObject = this.gameObject;
		Text textComponent = scoreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Time: {0}", (int)counter);
	}
}
