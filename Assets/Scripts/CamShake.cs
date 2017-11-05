using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {

	public float intensity;
	public float heavyIntensity;
	public float heavyLength;

	private float currentIntensity;

	void Start(){
		currentIntensity = intensity;
	}

	public void StartHeavyShake(){
		currentIntensity = heavyIntensity;
		Invoke("StopHeavyShaking", heavyLength);
	}

	void StopHeavyShaking(){
		currentIntensity = intensity;
	}

	void Update(){
		Vector3 pos = transform.position;
		pos.y += Random.Range (-currentIntensity, currentIntensity) * Time.deltaTime; 
		pos.x += Random.Range (-currentIntensity, currentIntensity) * Time.deltaTime;
		transform.position = pos;
	}
}