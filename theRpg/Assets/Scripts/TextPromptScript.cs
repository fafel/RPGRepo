using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextPromptScript : MonoBehaviour {

	public float radius;
	public string text;
	public LayerMask player;
	public Text textT;

	bool stoped = false;

	void Start(){
		textT.text = "";
	}


	void FixedUpdate(){
		Collider2D col = Physics2D.OverlapCircle (transform.position, radius, player);
		if (col != null) {
			stoped = true;
			Time.timeScale = 0.0f;
			textT.text = text;
		}
	}

	void Update(){
		if (stoped) {
			if (Input.GetMouseButtonDown(0)){
				if (Input.mousePosition.y < 70 ){
					textT.text = "";
					Time.timeScale = 1.0f;
					stoped = false;
					Destroy (transform.gameObject);
				}
			}

		}
	}








}
