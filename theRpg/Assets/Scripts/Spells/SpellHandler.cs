using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellHandler : MonoBehaviour {


	private List<Spell> spells;

	int spellSelected;

	public Transform projectile1;
	public Transform projectile2;
	public Transform projectile3;
	public Transform projectile4;

	private Transform projectile;

	float cd;

	void Start(){
		spells = new List<Spell> ();
		cd = 1.0f;
		projectile = projectile1;
	}

	void Update(){


		if (Input.GetButton ("spell1")) {
			projectile = projectile1;
		} else if (Input.GetButton ("spell2")) {
			projectile = projectile2;
		} else if (Input.GetButton ("spell3")) {
			projectile = projectile3;
		} else if (Input.GetButton ("spell4")) {
			projectile = projectile4;
		}

		cd -= Time.deltaTime;

		Vector3 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		//var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		dir.z = 0;
		dir.Normalize ();

		//dir = dir.normalized;

		if (Input.GetButtonDown ("Fire1") && cd < 0 && Time.timeScale > 0) {
			cd = 1.0f;
			Transform t = Instantiate (projectile1) as Transform;
			t.position = transform.position;
			t.GetComponent<ProjectileScript>().direction = dir;
			t.GetComponent<ProjectileScript>().speed = 10;
		}


	}


}
