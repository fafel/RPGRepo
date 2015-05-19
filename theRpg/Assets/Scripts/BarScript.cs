using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour {



	public float fuse = 0.25f;
	private bool moved = false;
	public Vector3 direction;
	public LayerMask enemys;
	public Transform explosion;

	public void Start(){
		direction.Normalize ();
	}


	public void Update(){
		fuse -= Time.deltaTime;
		if (fuse < 0.2f && !moved) {
			AddBar();
			moved = true;
		}
		if (fuse < 0)
			Destroy (transform.gameObject);
		transform.position += direction * Time.deltaTime;



	}

	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			HealthScript hp = coll.gameObject.GetComponent<HealthScript>();
			if (hp != null)
				hp.Damage(10);
			Transform t = Instantiate (explosion) as Transform;
			t.position = transform.position;
		}
		//Transform ta = Instantiate (explosion) as Transform;
		//ta.position = transform.position;
	}



	private void AddBar(){
		Transform t = Instantiate (transform) as Transform;
		t.GetComponent<BarScript> ().fuse = 0.25f;
		t.position = transform.position + direction/5;
	}
}
