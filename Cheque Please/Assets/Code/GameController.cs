using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public Transform customer;
	public GameObject custObject;
	public GameObject[] custArray;
	public System.Random rnd = new System.Random();
	public Text scoreDisplay;
	public Text timeDisplay;
	public Text scoreRequired;	
	public Text levelNo;
	public Text complete;
	public Text failed;
	public Button menuButton;
	public Button restartButton;
	public Button pauseButton;	
	public Button nextButton;
	public int level;
	public float timer;
	public int score = 0;
	public int playerPatience;
	public float playerSpeed;
	public int levelScore;
	public bool pause = false;
	public AudioSource completeLevel;
	public AudioSource failLevel;
	public AudioSource gameMusic;
	private bool played;

	// Use this for initialization
	void Start () {

		//levelScore = 100;
		gameMusic.Play ();
		pauseButton.transform.localScale = new Vector3(0, 0, 0);
		restartButton.transform.localScale = new Vector3(0, 0, 0);
		menuButton.transform.localScale = new Vector3(0, 0, 0);
		nextButton.transform.localScale = new Vector3(0, 0, 0);
		timer = 180;
		//timer = 4;
		levelNo.text = "Level " + level;
		//scoreDisplay = GetComponent<Text> ();
		scoreDisplay.text = "Score: $" + score;
		scoreRequired.text = "$" + levelScore + " Required";
		Vector2 pos;
		for (int i = 0; i <= 5; i++) {
			pos = new Vector2((float)-5.5, (float)(-2.1 + (0.7 * i)));

			Instantiate(customer, pos, Quaternion.identity);
			GameObject newCustomer = GameObject.Find("Customer(Clone)");
			//custArray[i] = newCustomer;
			newCustomer.name=("Customer" + i);
			newCustomer.transform.parent = custObject.transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pause = true;
		}

		if (timer > 0 && score < levelScore && pause == false) {
			timer -= Time.deltaTime;
			timeDisplay.text = "Time: " + (int) timer;
			scoreDisplay.text = "Score: $" + score;

			activteRandomCustomer ();
		}
		if (score >= levelScore || timer <= 0 || pause == true) {
			scoreDisplay.text = "Score: $" + score;
			if(pause == true){	
				gameMusic.Pause ();
				pauseButton.transform.localScale = new Vector3(1, 1, 0);
				menuButton.transform.localScale = new Vector3(1, 1, 0);
				complete.text = "Menu";
			}else{
			timeOutCustomer ();
			}
			if (timer <= 0){
				failed.text = "Level Failed!";
				gameMusic.Stop ();
				if(played == false){
					failLevel.Play ();
					played = true;
				}
				restartButton.transform.localScale = new Vector3(1, 1, 0);
				menuButton.transform.localScale = new Vector3(1, 1, 0);
			}else if(score>= levelScore){
				if(level == 10){
					complete.text = "Game Complete!";					
					gameMusic.Stop ();
					if(played == false){
						completeLevel.Play ();
						played = true;
					}
					menuButton.transform.localScale = new Vector3(1, 1, 0);
				}else{
				complete.text = "Level Complete!";
				gameMusic.Stop ();
				if(played == false){
					completeLevel.Play ();
					played = true;
				}
				nextButton.transform.localScale = new Vector3(1, 1, 0);
				menuButton.transform.localScale = new Vector3(1, 1, 0);
				}
			}
		}

	}

	private void activteRandomCustomer()
	{
		if(rnd.Next(1000) < 6)
		{
			Customer tempCust = GameObject.Find("Customer" + rnd.Next(6)).GetComponent<Customer> ();
			if(tempCust.active != true){

				tempCust.orderSize = rnd.Next (1, 3);
			
			for (int i=0; i<tempCust.orderSize; i++) {
				
					int tempOrder;
					if( level == 10){
						tempOrder = rnd.Next(11);
					}else{
						tempOrder = rnd.Next(2+level);
					}
				switch (tempOrder) {
				case 0:
					tempCust.order = "Burger";
					break;
				case 1:
					tempCust.order = "Soda";
					break;
				case 2:
					tempCust.order = "Fries";
					break;
				case 3:
					tempCust.order = "Hotdog";
						break;
				case 4:
					tempCust.order = "Milkshake";
					break;
				case 5:
					tempCust.order = "Icecream";
					break;
				case 6:
					tempCust.order = "CheesyFries";
					break;
				case 7:
					tempCust.order = "Pizza";
					break;
				case 8:
					tempCust.order = "Salad";
					break;
				case 9:
					tempCust.order = "Cake";
					break;
				case 10:
					tempCust.order = "Chicken";
					break;
				}
				
				tempCust.orderList.Add (tempCust.order);
			}
			tempCust.orderIsSet = true;
			tempCust.active = true;
			}
		}

	}

	private void timeOutCustomer()
	{
		for (int i = 0;i<=5; i++)
		{
			Customer tempCust = GameObject.Find("Customer" + i).GetComponent<Customer> ();
			tempCust.outOfTime = true;  
		}
	}

	public void unPause(){
		gameMusic.UnPause ();
		pauseButton.transform.localScale = new Vector3(0, 0, 0);
		menuButton.transform.localScale = new Vector3(0, 0, 0);
		complete.text = "";
		pause = false;

	}
}
