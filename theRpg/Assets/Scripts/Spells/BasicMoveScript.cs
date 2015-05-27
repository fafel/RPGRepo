using UnityEngine;
using System.Collections;

public class BasicMoveScript : MonoBehaviour {


	private Animator anim;

	public enum Type {UpDown, LefRight, Circle, TargetMode} 
	public Type type;
	public int length;
	public int dmg = 5;
	public float speed;
	public LayerMask player;
	public float moveSpeed = 1.0f;


	public float targetRange = 1.5f;

	Vector3 p1;
	Vector3 p2;
	private bool there;
	private bool up = false;

	Vector3 target { get; set; }

	public Vector3 GetTarget(){
		return target;
	}

	Transform targetTrans;

	float x = 0;

	bool attack = false;

	public float attackDistance = 0.3f;

	public float direction = 0;

	void Start(){
		anim = transform.gameObject.GetComponent<Animator> ();
		target = transform.position;
		if (type.Equals (Type.UpDown)) {
			p1 = transform.position;
			p2 = transform.position + new Vector3 (0, length, 0);
		} else if (type.Equals (Type.LefRight)) {
			p1 = transform.position;
			p2 = transform.position + new Vector3 (length, 0, 0);
		}
	}

	void Update(){
		TimeStuff ();
		switch (type) {
		case Type.LefRight:
			if (there){
				transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x > p2.x){
					there = false;
					anim.SetTrigger("RunLeft");
					direction = 0;
				}
			}else {
				transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x < p1.x){
					there = true;
					anim.SetTrigger("RunRight");
					direction = 180;
				}
			}
			break;
		case Type.UpDown:
			if (there){
				transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
				if (transform.position.y > p2.y){
					there = false;
					anim.SetTrigger("Run");
					direction = 270;
				}
			}else {
				transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
				if (transform.position.y < p1.y){
					there = true;
					anim.SetTrigger("RunUp");
					direction = 90;
				}
			}
			break;
		case Type.Circle:
			x += Time.deltaTime;

			transform.position += new Vector3(Mathf.Sin(5*x), Mathf.Cos(5*x), 0) / 100;
			//if (

			break;
		case Type.TargetMode:

			if (attack){
				Attack(direction);
				if ((Mathf.Abs (target.x - transform.position.x) > attackDistance || 
				    Mathf.Abs (target.y - transform.position.y) > attackDistance )){
					attack = false;
					there = !there;
				}
			} else	if (Mathf.Abs (target.x - transform.position.x) > attackDistance || 
			    Mathf.Abs (target.y - transform.position.y) > attackDistance ){
				Vector3 mov = target - transform.position;
				mov.Normalize();
				mov = new Vector3(mov.x * moveSpeed, mov.y * moveSpeed, 0);
				transform.position += (mov * Time.deltaTime);
				if (attack){
					there = !there;
				}
			} else if (!attack){
				anim.SetTrigger("Attack");
				attack = true;
			}

			if (Mathf.Abs(target.x - transform.position.x) > Mathf.Abs (target.y - transform.position.y)){
				if (target.x < transform.position.x && there == true){
					anim.SetTrigger("RunLeft");
					direction = 0;
					attack = false;
					there = false;
				} else if (target.x > transform.position.x && there == false){
					there = true;
					attack = false;
					anim.SetTrigger("RunRight");
					direction = 180;
				}
			} else {
				if (target.y > transform.position.y && up == true){
					anim.SetTrigger("RunUp");
					direction = 270;
					attack = false;
					up = false;
				} else if (target.y < transform.position.y && up == false){
					up = true;
					attack = false;
					anim.SetTrigger("Run");
					direction = 90;
				}
			}



			break;
		}
		Collider2D c = Physics2D.OverlapCircle (transform.position, targetRange, player);
		if (c != null && targetTrans == null) {
			targetTrans = c.gameObject.transform;
			target = c.gameObject.transform.position;
			anim.SetTrigger("RunLeft");
			there = false;
			type = Type.TargetMode;
		}
		if (targetTrans != null) {
			target = targetTrans.position;
		}
	}


	public virtual void Attack(float direction){
		Collider2D col = Physics2D.OverlapCircle (transform.position, 0.15f, player);
		if (col != null){
			HealthScript hp = col.gameObject.GetComponent<HealthScript>();
			if (hp != null){
				hp.Damage(dmg * Time.deltaTime);
			}
		}
	}

	public virtual void TimeStuff(){

	}

}
