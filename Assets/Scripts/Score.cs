using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public float multiplicatorResetTime;
	public int multiplicatorIncrease;

	private int multiplicator;
	private int score;

	public int GetScore(){
		return score;
	}

	public void AddPoints(int points){
		multiplicator += multiplicatorIncrease;
		score += multiplicator * points;
		CancelInvoke ("RemoveMultiplicator");
		Invoke ("RemoveMultiplicator", multiplicatorResetTime);
		UpdateScore ();
	}

	void RemoveMultiplicator(){
		multiplicator = 0;
		UpdateScore();
	}

	void UpdateScore(){
		string text = "";

		if (multiplicator > 0) {
			text += multiplicator + " x ";
		}

		text += score;
		GetComponent<GUIText> ().text = text;
	}
		
}
