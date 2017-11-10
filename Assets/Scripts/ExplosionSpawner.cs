using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour {

	public GameObject explosion;
	public int minCount;
	public int maxCount;
	public float maxSpawnRadius;

	public void spawn(Vector3 explosionSpawnPos){
		int explosionCount = Random.Range(minCount, maxCount);
		for (int i = 0; i < explosionCount; i++) {
			Vector3 spawnPos = explosionSpawnPos;
			spawnPos.x += Random.Range (-maxSpawnRadius, maxSpawnRadius);
			spawnPos.y += Random.Range (-maxSpawnRadius, maxSpawnRadius);
			Instantiate (explosion, spawnPos, Quaternion.identity);
		}
	}

}
