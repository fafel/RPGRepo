using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpiralScript : MonoBehaviour {

	public Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//direction = direction + new Vector3 (Mathf.Sin (Time.deltaTime), -Mathf.Sin(Time.deltaTime), 0);

		//transform.position = transform.position + (direction * Time.deltaTime)/25;

		transform.position = transform.position + new Vector3 (Mathf.Sin (Time.deltaTime), -Mathf.Sin (Time.deltaTime + 1), 0);

	}
}
