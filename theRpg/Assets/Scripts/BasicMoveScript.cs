using UnityEngine;
using System.Collections;

public class BasicMoveScript : MonoBehaviour {


	private Animator anim;

	public enum Type {UpDown, LefRight, Circle, TargetMode} 
	public Type type;
	public int length;
	public float speed;
	public LayerMask player;

	Vector3 p1;
	Vector3 p2;
	private bool there;

	Vector3 target;
	Transform targetTrans;

	float x = 0;


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
		switch (type) {
		case Type.LefRight:
			if (there){
				transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x > p2.x){
					there = false;
					anim.SetTrigger("RunLeft");
				}
			}else {
				transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
				if (transform.position.x < p1.x){
					there = true;
					anim.SetTrigger("RunRight");
				}
			}
			break;
		case Type.UpDown:
			if (there){
				transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
				if (transform.position.y > p2.y){
					there = false;
					anim.SetTrigger("Run");
				}
			}else {
				transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
				if (transform.position.y < p1.y){
					there = true;
					anim.SetTrigger("RunUp");
				}
			}
			break;
		case Type.Circle:
			x += Time.deltaTime;

			transform.position += new Vector3(Mathf.Sin(5*x), Mathf.Cos(5*x), 0) / 100;
			//if (

			break;
		case Type.TargetMode:
			if (Mathf.Abs (target.x - transform.position.x) < speed * 5 && 
			    Mathf.Abs (target.y - transform.position.y) < speed * 5){
				Vector3 mov = target - transform.position;
				mov.Normalize();
				transform.position += (mov * Time.deltaTime);
			}

			if (target.x < transform.position.x && there == true){
				anim.SetTrigger("RunLeft");
				there = false;
			} else if (target.x > transform.position.x && there == false){
				there = true;
				anim.SetTrigger("RunRight");
			}


			break;
		}
		Collider2D c = Physics2D.OverlapCircle (transform.position, 1.5f, player);
		if (c != null && targetTrans == null) {
			targetTrans = c.gameObject.transform;
			target = c.gameObject.transform.position;
			type = Type.TargetMode;
		}
		if (targetTrans != null) {
			target = targetTrans.position;
		}
	}





}
