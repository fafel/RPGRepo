using UnityEngine;
using System.Collections;

public abstract class Spell : MonoBehaviour {

	public abstract void Fire(Vector2 location);

	public abstract double  GetDamage();

	public abstract float GetCD();

	public abstract Sprite GetHitMarker();

	public abstract string GetElement();
}
