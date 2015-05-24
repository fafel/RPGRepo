using UnityEngine;
using System.Collections;

public class WooshScript : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (1, 0, 0) * speed * Time.deltaTime;

		if (transform.position.x < -20) {
			transform.position = transform.position + new Vector3(40, 0, 0);
		}

	}
}
