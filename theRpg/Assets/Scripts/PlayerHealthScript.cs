using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthScript : HealthScript {

	public Transform panel;


	private static bool isdead;

	public static bool isDead(){
		return isdead;
	}

	void Update(){
		base.Update ();

		isdead = dead;
	}

	public override void OnDeath(){
		panel.gameObject.SetActive (true);
		Time.timeScale = 0;

	}

	public void ReLoadLevel(){
		if (CoreDataScript.coreDataScript != null) {
			CoreDataScript.coreDataScript.TransferScore();
		}
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void LoadLevel(string lvlName){
		if (CoreDataScript.coreDataScript != null) {
			CoreDataScript.coreDataScript.TransferScore();
		}
		Time.timeScale = 1.0f;
		Application.LoadLevel (lvlName);
	}
}
