using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour {

	public int points;
	protected float hSpeed;
	protected float vSpeed;

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
		explosionSpawnPos.y += hSpeed * Time.deltaTime;
		explosionSpawnPos.x += vSpeed * Time.deltaTime;
		ExplosionSpawner explosionSpawner = GetComponent<ExplosionSpawner> ();
		if (explosionSpawner != null) {
			explosionSpawner.spawn (explosionSpawnPos);
		}
		Destroy(gameObject);
	}

}
