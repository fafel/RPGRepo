﻿using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
    
	public float time;

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0){
			Destroy(transform.gameObject);
		}
	}
}
