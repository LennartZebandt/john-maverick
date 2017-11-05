using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner: MonoBehaviour {
	
	public float spawnInterval;
	public int spawnAmountMin;
	public int spawnAmountMax;
	public GameObject cloudPart;
	public int cloudPartAmountMin;
	public int cloudPartAmountMax;
	public float cloudPartSpawnRadius;

	void Start () {
		int randomAmount = Random.Range (spawnAmountMin, spawnAmountMax);
		for (int i = 0; i < randomAmount; i++) {
			InvokeRepeating ("SpawnCloud", spawnInterval,spawnInterval);
		}
	}

	void SpawnCloud(){
		Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), -100, 0));
		int randomAmount = Random.Range(cloudPartAmountMin, cloudPartAmountMax);
		for(int i=0;i<randomAmount;i++){
			spawnPos = Random.insideUnitCircle * cloudPartSpawnRadius + new Vector2(spawnPos.x, spawnPos.y);
			Instantiate(cloudPart, spawnPos, Quaternion.identity);
		}
	}

}
