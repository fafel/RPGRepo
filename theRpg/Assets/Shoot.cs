using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Vector3 direction;
	public int speed;
	public LayerMask player;
	
	void Start(){
		//direction.Normalize ();
	}
	
	void Update(){
		transform.position = transform.position + (direction * Time.deltaTime) * speed;
		Collider2D col = Physics2D.OverlapCircle (transform.position, .05f, player);
		if (col != null) {
			HealthScript hs = col.gameObject.GetComponent<HealthScript>();
			if (hs != null){
				hs.Damage(10);
			}
			Destroy(transform.gameObject);
		}		
		
	}
}
