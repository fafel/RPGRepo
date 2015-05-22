using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public int health;
	public int xp;
	public Transform explosion;
	public bool die = true;
	public Image img;

	private float hp;

	void Start(){
		hp = health;
	}

	public int Damage(float dmg){
		hp -= dmg;
		if (hp < 0)
			return xp;
		return 0;
	}

    public bool dead = false;


	public void Update(){
		if (hp < 0)
			hp = 0;

		health = (int)hp;

		if (health <= 0 && die && !dead) {
			OnDeath();
			dead = true;
		}
		if (img != null) {
			img.gameObject.transform.localScale = new Vector3(health * 4, 1, 1);
		}

	}

	public virtual void OnDeath(){
		if (explosion != null) {
			Transform t = Instantiate (explosion) as Transform;
			t.position = transform.position;
			Destroy (transform.gameObject);
		}
	}

}
