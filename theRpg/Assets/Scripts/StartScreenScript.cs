using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	public string lvlName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.anyKey) {
			Application.LoadLevel(lvlName);
		}
	}
}
