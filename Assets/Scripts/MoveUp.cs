using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {

	public float vSpeed;

	void Update () {
		Vector3 pos = transform.position;
		pos.y += vSpeed * Time.deltaTime;
		transform.position = pos;
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
