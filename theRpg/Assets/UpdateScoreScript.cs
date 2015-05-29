using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScoreScript : MonoBehaviour {

	public bool total = false;

	// Use this for initialization
	void Start () {
		text = transform.GetComponent<Text> ();
	}

	Text text;

	// Update is called once per frame
	void Update () {
		if (CoreDataScript.coreDataScript != null) {
			string s = "";
			if (total){
				s = "TOTAL ";
			}
			s = s + "SCORE: ";
			if (total){
				s = s + CoreDataScript.coreDataScript.totalScore;
			} else {
				s = s + CoreDataScript.coreDataScript.score;
			}
			text.text = s;
		}
	}
}
