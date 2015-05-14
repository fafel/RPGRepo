using UnityEngine;
using System.Collections;

public class BasicMoveScript : MonoBehaviour {


	private Animator anim;

	public enum Type {UpDown, LefRight} 
	public Type type;
	public int length;
	public float speed;

	Vector3 p1;
	Vector3 p2;
	private bool there;


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
			break;
		}

	}





}
