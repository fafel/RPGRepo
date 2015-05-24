using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryElementScript : MonoBehaviour {

	public float radius;
	public string[] texts;
	public Sprite img;
	public Image image;
	public LayerMask player;
	public Text textT;
	
	bool stoped = false;

	private int i;
	
	void Start(){
		textT.text = "";
		i = 0;
	}
	
	
	void FixedUpdate(){
		Collider2D col = Physics2D.OverlapCircle (transform.position, radius, player);
		if (col != null) {
			stoped = true;
			Time.timeScale = 0.0f;
			image.gameObject.SetActive(true);
			image.sprite = img;
			textT.text = texts[i];
		}
	}
	
	void Update(){
		if (stoped) {
			if ((Input.GetMouseButtonDown(0) && Input.mousePosition.y < 70 ) || Input.anyKeyDown){
				if (i < texts.Length - 1){
					i++;
					textT.text = texts[i];
				} else {
					ResetWindow();
				}
			}
			
		}
	}
	
	private void ResetWindow(){
		textT.text = "";
		Time.timeScale = 1.0f;
		stoped = false;
		image.gameObject.SetActive(false);
		Destroy (transform.gameObject);
	}
	
	
	

}
