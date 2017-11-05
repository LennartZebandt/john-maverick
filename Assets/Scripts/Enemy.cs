using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject explosion;
	public int points;
	public float minVSpeed;
	public float maxVSpeed;
	public float hSpeed;
	private float vSpeed;

	void Start () {
		vSpeed = Random.Range (minVSpeed, maxVSpeed);
	}
	
	void Update () {
		Vector3 position = this.transform.position;
		position.x += vSpeed * Time.deltaTime;
		position.y += hSpeed * Time.deltaTime;
		this.transform.position = position;
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Bullet"){
			Destroy ();
		}
	}

	void Destroy(){
		//add to score
		GameObject score = GameObject.Find ("Score");
		score.GetComponent<Score>().AddPoints(points);
		//create explosion
		Camera.main.GetComponent<CamShake> ().StartHeavyShake ();
		Vector3 explosionSpawnPos = transform.position;
		explosionSpawnPos.y += vSpeed * Time.deltaTime;
		Instantiate (explosion, explosionSpawnPos, Quaternion.identity);
		Destroy(gameObject);
	}

}
