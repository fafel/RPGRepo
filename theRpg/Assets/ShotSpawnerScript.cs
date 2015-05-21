using UnityEngine;
using System.Collections;

public class ShotSpawnerScript : MonoBehaviour {

	public float frequency = 1;

	private float timer;

	public Transform projectile;

	public Vector3 direction;

	public LayerMask target;

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		timer = frequency;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			timer = frequency;
			SpawnProjectile();
		}
	}


	void SpawnProjectile(){
		Transform t = Instantiate (projectile) as Transform;
		t.transform.position = transform.position;
		ProjectileScript ps = t.GetComponent<ProjectileScript> ();
		if (ps != null) {
			ps.direction = direction;
			ps.enemy = target;
			ps.speed = (int)speed;
		}
	}


}
