using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomize : MonoBehaviour {

	public float minScaleFactor;
	public float maxScaleFactor;

	void Start () {
		float scale = Random.Range (minScaleFactor, maxScaleFactor);
		transform.localScale = new Vector3 (scale, scale, scale);
		//transform.rotation = Random.rotation;
		transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
	}

}
