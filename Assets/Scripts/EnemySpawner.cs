using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public enum Sides {Left, Right};
	public Sides side;
	public float spawnMargin;
	public float yMin;
	public float yMax;
	public float spawnInterval = 5;
	public float increaseInterval = 10;
	public GameObject[] enemyTypes;

	private float elapsedSinceSpawn = 0;
	private float elapsedSinceIncrease = 0;
	private float spawnAmount = 1;

	void Update () {
		elapsedSinceIncrease += Time.deltaTime;
		elapsedSinceSpawn += Time.deltaTime;
		if (elapsedSinceIncrease > increaseInterval) {
			spawnAmount++;
			elapsedSinceIncrease = 0;
		}
		if (elapsedSinceSpawn > spawnInterval) {
			for (int i = 0; i < spawnAmount; i++) {
				GameObject random = enemyTypes[Random.Range (0, enemyTypes.Length)];
				if (random != null) {
					float left = Camera.main.ScreenToWorldPoint(new Vector3(-spawnMargin, 0, 0)).x;
					float right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + spawnMargin, 0, 0)).x;
					float x = side == Sides.Left ? left : right;
					Vector3 spawnPos = new Vector3 (x, Random.Range(yMin, yMax), 0);
					Instantiate (random, spawnPos, Quaternion.identity);
				}
			}
			elapsedSinceSpawn = 0;
		}
	}
}
