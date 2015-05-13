using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int health;
	public int xp;
	public Transform explosion;

	public int Damage(int dmg){
		health -= dmg;
		if (health < 0)
			return xp;
		return 0;
	}


	public void Update(){

		if (health < 0) {
			Transform t = Instantiate (explosion) as Transform;
			t.position = transform.position;
			Destroy(transform.gameObject);
		}

	}

}
