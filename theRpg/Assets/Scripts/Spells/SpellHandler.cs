using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpellHandler : MonoBehaviour {


//	private List<Spell> spells;

	int spellSelected;

	public Transform projectile1;
	public Transform projectile2;
	public Transform projectile3;
	public Transform projectile4;

	public Text cdText1;
	public Text cdText2;
	public Text cdText3;
	public Text cdText4;

	private float cd;

	private Transform projectile;

	public float cdone = 1.0f;
	public float cdtwo = 1.0f;
	public float cdthree = 1.0f;
	public float cdfour = 1.0f;

	float cd1;
	float cd2;
	float cd3;
	float cd4;

	void Start(){
//		spells = new List<Spell> ();
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

		if (cd1 > 0.1)
			cd1 -= Time.deltaTime;
		else 
			cd1 = 0;
		if (cd2 > 0.1)
			cd2 -= Time.deltaTime;
		else 
			cd2 = 0;
		if (cd3 > 0.1)
			cd3 -= Time.deltaTime;
		else 
			cd3 = 0;
		if (cd4 > 0.1)
			cd4 -= Time.deltaTime;
		else
			cd4 = 0;

		cdText1.text = "" + cd1;
		cdText2.text = "" + cd2;
		cdText3.text = "" + cd3;
		cdText4.text = "" + cd4;


		if (projectile == projectile1)
			cd = cd1;
		else if (projectile == projectile2)
			cd = cd2;
		else if (projectile == projectile3)
			cd = cd3;
		else if (projectile == projectile4)
			cd = cd4;
	

		Vector3 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		//var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		dir.z = 0;
		dir.Normalize ();

		//dir = dir.normalized;

		if (Input.GetButtonDown ("Fire1") && cd <= 0 && Time.timeScale > 0) {
			Transform t = Instantiate (projectile) as Transform;
			t.position = transform.position;
			if (t.GetComponent<ProjectileScript>() != null){
				t.GetComponent<ProjectileScript>().direction = dir;
				t.GetComponent<ProjectileScript>().speed = 10;
			}

			if (projectile == projectile3){
				PlayerMoveScript pms = transform.GetComponent<PlayerMoveScript>();
				if (pms != null){
					pms.StopMove();
				}
			}

			if (t.childCount != 0){

				t = t.GetChild(0);


				if (t.GetComponent<BarScript>() != null){
					t.GetComponent<BarScript>().direction = dir;
					var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
					t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
					t.transform.position = t.transform.position + dir/5;
				}
			}
			cd = 0.25f;

			if (projectile == projectile1)
				cd1 = cdone;
			else if (projectile == projectile2)
				cd2 = cdtwo;
			else if (projectile == projectile3)
				cd3 = cdthree;
			else if (projectile == projectile4)
				cd4 = cdfour;
		}


	}


}


