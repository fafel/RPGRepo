using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	float g;

	// Use this for initialization
	void Start () {
		g = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		g -= Time.deltaTime;
		if (g < 0)
			Destroy (transform.gameObject);
	}
}
