using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string howToPlay;

	public void newGame(){
		Application.LoadLevel (startLevel);
	}

	public void selectLevel(){
		Application.LoadLevel (howToPlay);
	}

	public void exitGame()
	{
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
