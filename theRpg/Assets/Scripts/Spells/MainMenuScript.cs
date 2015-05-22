using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {



	public void ClickNewGame(){
		Application.LoadLevel ("NewGame");
	}

	public void ClickLoadGame(){
		Application.LoadLevel ("LoadGame");
	}

	public void ClickQuit(){
		Application.Quit ();
	}

}
