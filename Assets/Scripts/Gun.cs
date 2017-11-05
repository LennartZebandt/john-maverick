using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	public float fireRate = 0.5F;

	private float nextFire = 0.5F;
	private GameObject newProjectile;
	private float elapsed = 0.0F;

	void Update()
	{
		elapsed += Time.deltaTime;

		if (Input.GetButtonDown("Fire1") && elapsed > nextFire)
		{
			nextFire = elapsed + fireRate;
			newProjectile = Instantiate(projectile, transform.Find("FirePoint").position, transform.rotation) as GameObject;
			nextFire -= elapsed;
			elapsed = 0.0F;
		}
	}

}
