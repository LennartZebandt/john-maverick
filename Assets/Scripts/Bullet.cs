using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public GameObject explosion;
	
	void Update () {
		transform.Translate(-transform.up * speed * Time.deltaTime);
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			Destroy(gameObject);
		}
	}
		
}
