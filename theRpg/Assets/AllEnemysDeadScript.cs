using UnityEngine;
using System.Collections;

public class AllEnemysDeadScript : MonoBehaviour {

	public Transform successPanel;


	
	// Update is called once per frame
	void Update () {
		if (transform.childCount == 0) {
			successPanel.gameObject.SetActive(true);
		}
	}
}
