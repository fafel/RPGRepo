using UnityEngine;
using System.Collections;

public class SpreadScript : ProjectileScript {

	public Transform shots;

	public override void Explode(){

		Transform t = Instantiate (shots) as Transform;
		t.GetComponent<ProjectileScript> ().direction = new Vector3 (-1, -1, 0);
		t.position = transform.position;

		t = Instantiate (shots) as Transform;
		t.GetComponent<ProjectileScript> ().direction = new Vector3 (1, -1, 0);
		t.position = transform.position;
		t = Instantiate (shots) as Transform;
		t.GetComponent<ProjectileScript> ().direction = new Vector3 (-1, 1, 0);
		t.position = transform.position;
		t = Instantiate (shots) as Transform;
		t.GetComponent<ProjectileScript> ().direction = new Vector3 (1, 1, 0);
		t.position = transform.position;
	}

}
