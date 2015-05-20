using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {


	public Vector3 direction;
	public int speed;
	public Transform explosion;
	public LayerMask enemy;
	public float fuse;

	public Transform cantHit;

	void Start(){
		//direction.Normalize ();
		//fuse = 0.05f;
		//cantHit = null;
	}

	void Update(){
		fuse -= Time.deltaTime;
		transform.position = transform.position + (direction * Time.deltaTime) * speed;
		Collider2D col = Physics2D.OverlapCircle (transform.position, .05f, enemy);
		if (col != null && fuse < 0 && (cantHit == null || col.gameObject != cantHit.gameObject)) {
			HealthScript hs = col.gameObject.GetComponent<HealthScript>();
			if (hs != null){
				hs.Damage(10);
			}
			Transform t = Instantiate(explosion) as Transform;
			t.position = transform.position;
			Explode(col.gameObject.transform);
			Destroy(transform.gameObject);
		}		

	}

	public virtual void Explode(Transform hit) {

	}


}
