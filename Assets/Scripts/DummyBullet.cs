using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBullet : MonoBehaviour {

	public float hSpeed;

	void Update(){
		Vector3 pos = transform.position;
		pos.x -= hSpeed;
		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy"){
			Menu menu = GameObject.FindObjectOfType (typeof(Menu)) as Menu;
			menu.StartGame (transform.position);
			Destroy (gameObject);
		}
	}

}
