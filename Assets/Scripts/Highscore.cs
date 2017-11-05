using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {

	void Start () {
		if (PlayerPrefs.HasKey ("Highscore")) {
			GUIText highscoreText = GetComponent<GUIText> ();
			highscoreText.enabled = true;
			highscoreText.text = "Highscore: " + PlayerPrefs.GetInt ("Highscore");
		}
	}

}
