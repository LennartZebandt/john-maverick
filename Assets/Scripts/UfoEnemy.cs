using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoEnemy : Enemy {

	public int points;
	public float minSpeed;
	public float maxSpeed;

	private float speed;

	void Start () {
		speed = Random.Range (minSpeed, maxSpeed);
	}

	void Update () {
		GameObject target = GameObject.FindWithTag ("Hero");

		if (target != null) {
			Vector3 heading = target.transform.position - transform.position;
			hSpeed = heading.x -1;
			vSpeed = heading.y -1;
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		}
	}

}
