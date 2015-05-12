using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float dealay;
	Animator anim;

	void Start(){
	//	anim = transform.GetComponent (Animator);
		//anim.StopPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
		//dealay -= Time.deltaTime;
		if (dealay <= 0) {
			//anim.StartPlayback();
		}
		if (dealay < -(0.31f)){
			//Destroy(transform.gameObject);
		}
	}
}
