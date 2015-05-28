using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

	public float speed = 2.0f;
	
	public Vector3 targetPos;
	Animator anim;

	private float oldX = 0;
	private float oldY = 0;

	private bool stop = false;
	private float stopMoveTimer = 0;
	
	void Init() {
		//targetPos = transform.position;
	}

	void Start() {
		targetPos = transform.position;
		anim = transform.gameObject.GetComponentInChildren<Animator> ();
	}
	
	void Update () {
		KeyMove ();
		stopMoveTimer -= Time.deltaTime;
		if (stopMoveTimer < 0)
			stop = false;
	}

	void KeyMove(){
		float xAxis = (int)Input.GetAxis ("Horizontal");
		float yAxis = (int)Input.GetAxis ("Vertical");

		if (oldY != yAxis || oldX != xAxis) {
			if (yAxis < -0.1) {
				anim.SetTrigger ("Run");

			} else if (yAxis > 0.1) {
				anim.SetTrigger ("RunUp");
			} else if (yAxis == 0) {
				if (xAxis < -0.1) {
					anim.SetTrigger ("RunLeft");
				} else if (xAxis > 0.1) {
					anim.SetTrigger ("RunRight");
				} else if (xAxis == 0) {
					anim.SetTrigger ("Still");
				}
			}
		}

		if (!stop) {
			Vector3 vect = new Vector3 (xAxis, yAxis, 0) * speed;
			transform.position = transform.position + vect * Time.deltaTime;
		} else {
			anim.SetTrigger("Still");
		}

		oldX = xAxis;
		oldY = yAxis;
	}

	void MouseMove(){
		if (Input.GetMouseButton (1)) {
			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetPos.z = transform.position.z;
			//transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		}
		if (Mathf.Abs (targetPos.x - transform.position.x) < speed * 5 && 
		    Mathf.Abs (targetPos.y - transform.position.y) < speed * 5)
			transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);
	}

	public void StopMove(){
		stop = true;
		stopMoveTimer = 1;
	}

	public void AllowMove(){
		stop = false;
	}

}







