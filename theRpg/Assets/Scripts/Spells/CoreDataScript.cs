using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

public class CoreDataScript : MonoBehaviour {


	//DATA
	public int xp;
	public int hp;
	public string lvl;
	public string saveFile;

	//static reference to data
	public static CoreDataScript coreDataScript;

	void Awake (){
		if (coreDataScript == null) {
			coreDataScript = this;
			DontDestroyOnLoad (gameObject);
		} else if (coreDataScript != this) {
			Destroy(gameObject);
		}
	}


	public void Load(string fileName){
		string path = Application.persistentDataPath + "/" + fileName;
		saveFile = fileName;
		if (File.Exists (path)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(path, FileMode.Open);
			CoreDataO cd = (CoreDataO)bf.Deserialize(file);
			file.Close();
			SetFields(cd);
			lvl = cd.lvl;
			Application.LoadLevel(lvl);
		} else {
			Debug.LogError("No File found of name: " + fileName);
		}
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/" + saveFile);
		CoreDataO cdO = new CoreDataO (this.hp, this.xp, this.lvl);
		bf.Serialize (fs, cdO);
		fs.Close ();
	}

	private void SetFields(CoreDataO cd){
		this.hp = cd.health;
		this.xp = cd.xp;
	}


}

//DataShell

[Serializable]
class CoreDataO 
{
	public CoreDataO(int health, int xp, string lvl){		
		this.health = health;
		this.xp = xp;
		this.lvl = lvl;
	}

	public int health;
	public int xp;
	public string lvl;

}

