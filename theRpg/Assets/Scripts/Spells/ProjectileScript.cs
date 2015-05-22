using UnityEngine;
using System.Collections;
using System.Collections;

public class ProjectileScript : MonoBehaviour {


	public Vector3 direction;
	public int speed;
	public Transform explosion;
	//public LayerMask enemy;
	public float fuse;

	public LayerMask[] enemys;

	public Transform cantHit;

	void Start(){
		//direction.Normalize ();
		//fuse = 0.05f;
		//cantHit = null;
	}

	void Update(){
		fuse -= Time.deltaTime;
		transform.position = transform.position + (direction * Time.deltaTime) * speed;
		Collider2D col = null;
		for (int i = 0; i < enemys.Length; i++) {
			if (col != null)
				break;
			else if (col == null){
				col = Physics2D.OverlapCircle (transform.position, 0.05f, enemys[i]);
			}
		}


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
