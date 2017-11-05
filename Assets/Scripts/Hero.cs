using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	public GameObject blood;
	public float maxHSpeed;
	public float maxVSpeed;
	public float maxRotation;
	public float restartDelay;

	void Update () {
		Move ();
		KeepInView ();
		ApplyAngle ();
	}

	void Move(){
		float hSpeed = Input.GetAxis ("Horizontal") * maxHSpeed * Time.deltaTime; 
		float vSpeed = Input.GetAxis ("Vertical") * maxVSpeed * Time.deltaTime;

		Vector3 position = transform.position;
		position.x += hSpeed;
		position.y += vSpeed;
		transform.position = position;
	}

	void KeepInView(){
		Vector3 left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		Vector3 right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
		Vector3 top = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
		Vector3 down = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

		Vector3 newPos = transform.position;

		if (newPos.x < left.x) {
			newPos.x = left.x;
		} else if (newPos.x > right.x) {
			newPos.x = right.x;
		}


		if (newPos.y < down.y) {
			newPos.y = down.y;
		} else if (newPos.y > top.y) {
			newPos.y = top.y;
		}
			
		transform.position = newPos;
	}

	void ApplyAngle(){
		float angle = Input.GetAxis ("Horizontal") * maxRotation;
		transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			gameObject.SetActive(false);
			Vector3 bloodSpawnPos = transform.position;
			float vSpeed = Input.GetAxis ("Vertical") * maxVSpeed * Time.deltaTime;
			bloodSpawnPos.y += vSpeed;
			Instantiate (blood, bloodSpawnPos, Quaternion.identity);
			Invoke ("Restart", restartDelay);
		}
	}

	void Restart(){
		CheckHighscore ();
		Application.LoadLevel(Application.loadedLevel);
		Destroy(gameObject);
	}

	void CheckHighscore(){
		Score score = GameObject.FindObjectOfType (typeof(Score)) as Score;
		if (PlayerPrefs.HasKey ("Highscore")) {
			if (score.GetScore () > PlayerPrefs.GetInt ("Highscore")) {
				PlayerPrefs.SetInt ("Highscore", score.GetScore ());
			}
		} else {
			PlayerPrefs.SetInt ("Highscore", score.GetScore ());
		}
		PlayerPrefs.Save ();
	}
		
}

