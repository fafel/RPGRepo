using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	public static MusicScript theMusic;

	void Start () {

		if (theMusic == null) {
			DontDestroyOnLoad (transform.gameObject);
			theMusic = this;
		} else {
			Destroy(transform.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
