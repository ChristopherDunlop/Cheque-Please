using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	public string nextLevel;
	public string thisLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restartLevel(){
		
		Application.LoadLevel (thisLevel);
	}

	public void loadNextLevel(){
		
		Application.LoadLevel (nextLevel);
	}

	public void mainMenu(){
		
		Application.LoadLevel ("TitleMenu");
	}
}
