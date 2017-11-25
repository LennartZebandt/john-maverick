using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy {

	public float minVSpeed;
	public float maxVSpeed;

	void Start () {
		vSpeed = Random.Range (minVSpeed, maxVSpeed);
	}

	void Update () {
		Vector3 position = this.transform.position;
		position.x += vSpeed * Time.deltaTime;
		position.y += hSpeed * Time.deltaTime;
		this.transform.position = position;
	}

}
