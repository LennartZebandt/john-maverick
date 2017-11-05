using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject hero;

	void Update () {
		if (Input.anyKey) {
			DummyBullet dummyBullet = GameObject.FindObjectOfType (typeof(DummyBullet)) as DummyBullet;
			dummyBullet.enabled = true;
		}
	}
		
	public void StartGame(Vector3 spawnPos){
		StartMoving ();
		ActivateGameBehaviours ();
		Instantiate (hero, spawnPos, Quaternion.identity);
		this.enabled = false;
	}

	void StartMoving(){
		MoveUp[] all = GameObject.FindObjectsOfType (typeof(MoveUp)) as MoveUp[];
		foreach(MoveUp moveUp in all){
			moveUp.vSpeed = 1;
		}
	}

	void ActivateGameBehaviours(){
		EnemySpawner[] enemySpawners = GameObject.FindObjectsOfType (typeof(EnemySpawner)) as EnemySpawner[];
		CloudSpawner cloudSpawner = GameObject.FindObjectOfType (typeof(CloudSpawner)) as CloudSpawner;
		GUIText guiText = GameObject.Find ("Score").GetComponent<GUIText>() as GUIText;
		CamShake camShake = GameObject.FindObjectOfType (typeof(CamShake)) as CamShake;
		enemySpawners [0].enabled = true;
		enemySpawners [1].enabled = true;
		cloudSpawner.enabled = true;
		guiText.enabled = true;
		camShake.enabled = true;
	}
}
