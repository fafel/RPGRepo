﻿using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public Transform thing;

	public float frequency = 1.0f;
	public float duration = 10.0f;
	public float delay = 0.0f;

	private float timer;

	private bool spawn = false;

	void Start(){
		timer = frequency;
	}

	public void Update(){
		delay -= Time.deltaTime;
		if (delay < 0) {
			spawn = true;
		}
		if (spawn && duration > 0) {
			duration -= Time.deltaTime;
			timer -= Time.deltaTime;
			if (timer <= 0){
				timer = frequency;
				SpawnObject();
			}
		}

		if (duration < 0) {
			Destroy(transform.gameObject);
		}

	}

	private void SpawnObject(){
		Transform obj = Instantiate (thing) as Transform;
		obj.transform.position = transform.position;
	}

}
