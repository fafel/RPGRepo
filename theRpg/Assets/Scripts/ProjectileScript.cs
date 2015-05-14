using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {


	public Vector3 direction;
	public int speed;
	public Transform explosion;
	public LayerMask enemy;
	public float fuse;

	void Start(){
		//direction.Normalize ();
		fuse = 0.03f;
	}

	void Update(){
		fuse -= Time.deltaTime;
		transform.position = transform.position + (direction * Time.deltaTime) * speed;
		Collider2D col = Physics2D.OverlapCircle (transform.position, .05f, enemy);
		if (col != null && fuse < 0) {
			HealthScript hs = col.gameObject.GetComponent<HealthScript>();
			if (hs != null){
				hs.Damage(10);
			}
			Transform t = Instantiate(explosion) as Transform;
			t.position = transform.position;
			Explode();
			Destroy(transform.gameObject);
		}		

	}

	public virtual void Explode() {

	}


}
