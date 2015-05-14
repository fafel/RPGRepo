using UnityEngine;
using System.Collections;

public class BasicMoveScript : MonoBehaviour {


	private Animator anim;

	public enum Type {UpDown, LefRight, Circle} 
	public Type type;
	public int length;
	public float speed;

	Vector3 p1;
	Vector3 p2;
	private bool there;

	float x = 0;


	void Start(){
		anim = transform.gameObject.GetComponent<Animator> ();
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
		}
	}





}
