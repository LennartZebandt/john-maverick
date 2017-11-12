using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	public float fireRate;
	public float recoil;

	private float nextFire = 0.5F;
	private GameObject newProjectile;
	private float elapsed = 0.0F;
	private GameObject muzzle;

	void Start(){
		muzzle = transform.Find ("Muzzle").gameObject;
	}

	void Update(){
		muzzle.GetComponent<SpriteRenderer> ().enabled = false;
		elapsed += Time.deltaTime;
		if (Input.GetButtonDown("Fire1") && elapsed > nextFire){
			Vector3 heroPos = transform.parent.position;
			heroPos.y += recoil;
			transform.parent.position = heroPos;
			muzzle.GetComponent<SpriteRenderer> ().enabled = true;
			nextFire = elapsed + fireRate;
			newProjectile = Instantiate(projectile, muzzle.transform.position, transform.rotation) as GameObject;
			nextFire -= elapsed;
			elapsed = 0.0F;
		}
	}

}
