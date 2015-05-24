using UnityEngine;
using System.Collections;

public class CharacterSelectionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevelOne(string lvlName){
		Application.LoadLevel (lvlName);;
	}
}
