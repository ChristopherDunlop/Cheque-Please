using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public bool click;
	public Button start;
	public Button newGameButton;
	public Button rule;
	public Button exit;
	public Image mona;
	public Image controls;
	public Text rules;
	private float counterUp = 0;
	private float counterDown = 1;


	public void newGame(){
		Application.LoadLevel (startLevel);
	}

	public void selectLevel(){
		click = true;
	}

	public void exitGame()
	{
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
		controls.transform.localScale = new Vector3(0, 0, 0);
		rules.transform.localScale = new Vector3(0, 0, 0);
		start.transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (counterDown <= 0) {
			click = false;
		}

		if (click == true) {
			newGameButton.transform.localScale = new Vector3(counterDown, counterDown, 0);
			rule.transform.localScale = new Vector3(counterDown, counterDown, 0);
			exit.transform.localScale = new Vector3(counterDown, counterDown, 0);
			mona.transform.localScale = new Vector3(counterDown, counterDown, 0);

			controls.transform.localScale = new Vector3(counterUp*3, counterUp*3, 0);
			rules.transform.localScale = new Vector3(counterUp, counterUp, 0);
			start.transform.localScale = new Vector3(counterUp, counterUp, 0);

			counterDown = counterDown - (float)0.01;
			counterUp = counterUp + (float)0.01;
		}

	}
}
