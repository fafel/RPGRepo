using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

	public float speed = 2.0f;
	
	public Vector3 targetPos;
	
	void Init() {
		//targetPos = transform.position;
	}

	void Start() {
		targetPos = transform.position;
	}
	
	void Update () {
		
		//var targetPos = transform.position;
		
		if (Input.GetMouseButton (1)) {
			targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetPos.z = transform.position.z;
			//transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		}
		if (Mathf.Abs (targetPos.x - transform.position.x) < speed * 5 && 
		    Mathf.Abs (targetPos.y - transform.position.y) < speed * 5)
			transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);
		
	}

}
