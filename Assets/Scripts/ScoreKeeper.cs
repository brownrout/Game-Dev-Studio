using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	float counter = 0.0f;

	void Update () {
		counter += Time.deltaTime;
		UpdateScoreText();
	}

	private void UpdateScoreText () {
		GameObject scoreTextObject = this.gameObject;
		Text textComponent = scoreTextObject.GetComponent<Text>();
		textComponent.text = string.Format("Time: {0}", (int)counter);
	}
}
