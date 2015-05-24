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
		Time.timeScale = 0;
		panel.gameObject.SetActive (true);
	}

	public void ReLoadLevel(){
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void LoadLevel(string lvlName){
		Time.timeScale = 1.0f;
		Application.LoadLevel (lvlName);
	}
}
