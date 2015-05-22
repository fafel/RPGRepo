using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		pause = false;
		panel.gameObject.SetActive(false);
		spells.gameObject.SetActive (false);
		inventory.gameObject.SetActive (false);
		spellsOn = false;
		inventoryOn = false;
	}

	public Transform panel;
	public Transform spells;
	public Transform inventory;

	public static bool pause;
	private bool spellsOn;
	private bool inventoryOn;
	
	// Update is called once per frame
	void Update () {
		if (!PlayerHealthScript.isDead ()) {
			if (Input.GetKeyDown (KeyCode.Escape) && pause == false) {
				Pause ();
			} else if (Input.GetKeyDown (KeyCode.Escape) && pause == true) {
				UnPause ();
			}
		}
	}

	public void UnPause(){
		pause = false;
		panel.gameObject.SetActive(false);
		SpellsOff ();
		InventoryOff ();
		Time.timeScale = 1.0f;
	}

	public void Pause(){
		pause = true;
		panel.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void SpellClick(){
		if (spellsOn)
			SpellsOff ();
		else 
			SpellsOn ();
	}

	public void SpellsOn(){
		InventoryOff ();
		spellsOn = true;
		spells.gameObject.SetActive (true);
	}

	public void SpellsOff(){
		spellsOn = false;
		spells.gameObject.SetActive (false);
	}

	public void InventoryClick(){
		if (inventoryOn)
			InventoryOff ();
		else
			InventoryOn ();
	}

	public void InventoryOn(){
		SpellsOff ();
		inventoryOn = true;
		inventory.gameObject.SetActive (true);
	}

	public void InventoryOff(){
		inventoryOn = false;
		inventory.gameObject.SetActive (false);
	}

}
