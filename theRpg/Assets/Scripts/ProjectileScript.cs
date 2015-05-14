using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {


	public Vector3 direction;
	public int speed;
	public Transform explosion;
	public LayerMask enemy;

	void Start(){
		//direction.Normalize ();
	}

	void Update(){
		transform.position = transform.position + (direction * Time.deltaTime) * speed;
		Collider2D col = Physics2D.OverlapCircle (transform.position, .05f, enemy);
		if (col != null) {
			HealthScript hs = col.gameObject.GetComponent<HealthScript>();
			if (hs != null){
				hs.Damage(10);
			}
			Transform t = Instantiate(explosion) as Transform;
			t.position = transform.position;
			Destroy(transform.gameObject);
		}		

	}


}
