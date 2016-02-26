using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public int lvl;
	public GameObject myText;


	// Use this for initialization
	void Start () {
		lvl = 1;
		print (lvl);
		myText.SetActive(false);
		InvokeRepeating ("LevelUp",1.0f,1.5f);
	}

	void Update() {
		UpdateLevelStatus ();
	}

	void UpdateLevelStatus () {
		GameObject lvlStat = GameObject.Find("LevelStatus"); 
		Text levelStatText = lvlStat.GetComponent<Text>();
		levelStatText.text = string.Format("Level {0}", lvl);
	}
	
	// Update is called once per frame
	void LevelUp () {
		
		GameObject currentScore = GameObject.Find("TimeText");  
		ScoreKeeper scoreText = currentScore.GetComponent<ScoreKeeper> ();

		GameObject EarthDestroyed = GameObject.Find("earth");  
		Earth earth = EarthDestroyed.GetComponent<Earth> ();

		if ( (int)scoreText.counter % 20 == 0 && !earth.gameOver) {
			lvl += 1;
			print (lvl);
			myText.SetActive(true);
			GameObject lvlUp = GameObject.Find("LevelText"); 
			Text levelText = lvlUp.GetComponent<Text>();
			levelText.text = string.Format("Cleared Level {0}", lvl-1);
			StartCoroutine (Wait ());
		}

	}

	IEnumerator Wait() //turn level text off after 3 seconds
	{
		yield return new WaitForSeconds(.5f);
		myText.SetActive( false );
		yield return new WaitForSeconds(.5f);
		myText.SetActive(true);
		yield return new WaitForSeconds(.5f);
		myText.SetActive( false );
		yield return new WaitForSeconds(.5f);
		myText.SetActive(true);
		yield return new WaitForSeconds(.5f);
		myText.SetActive( false );

	}

}
