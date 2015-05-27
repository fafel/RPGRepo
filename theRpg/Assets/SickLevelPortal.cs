using UnityEngine;
using System.Collections;

public class SickLevelPortal : MonoBehaviour {
	
	public LayerMask player;
	public string level;
	public float radius;
	
	
	// Update is called once per frame
	void Update () {
		Collider2D  col = Physics2D.OverlapCircle (transform.position, radius, player);
		if (col != null) {
			Time.timeScale = 1.0f;
			Application.LoadLevel(level);
		}
	}
}

