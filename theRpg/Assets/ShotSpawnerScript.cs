using UnityEngine;
using System.Collections;

public class ShotSpawnerScript : MonoBehaviour {

	public float frequency = 1.0f;

	private float timer;

	public Transform projectile;

	public Vector3 direction;

	public LayerMask target;

	public float speed = 1.0f;

	public float acceleration = 0;
	public float deltaA = 0;
	public float targetFrequency = 1.0f;

	private bool up;
	private float time = 1.0f;

	// Use this for initialization
	void Start () {
		timer = frequency;
		up = (targetFrequency > frequency);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			timer = frequency;
			SpawnProjectile();
		}
		time -= Time.deltaTime;
		if (time < 0) {
			time = 1.0f;

			if ((up && (frequency  < targetFrequency)) || (!up && (frequency  > targetFrequency))){
				frequency += acceleration;
				acceleration += deltaA;
			}
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
