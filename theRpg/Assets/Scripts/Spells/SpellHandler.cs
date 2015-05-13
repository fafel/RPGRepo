using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellHandler : MonoBehaviour {


	private List<Spell> spells;
	void Start(){
		spells = new List<Spell> ();
		spells.Add (new BurningHands ());

	}

	void Update(){

		if (Input.GetButtonDown ("Fire1")) {
			if (spells[0] != null){
				spells[0].Fire(transform.position);
			}
		}

	}


}
