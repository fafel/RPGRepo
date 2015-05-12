using UnityEngine;
using System.Collections;

public class BurningHands : Spell {

	private int damage = 9000;
	private float coolDown = 5.0f;
	private Sprite hitMarker;

	private Transform bomb;

	void Start(){

	}

	public override void Fire(Vector2 location){

	}

	public override double GetDamage(){
		return damage;
	}
	
	public override float GetCD(){
		return coolDown;
	}

	public override Sprite GetHitMarker(){
		return hitMarker;
	}
	
	public override string GetElement(){
		return "fire";
	}
}
