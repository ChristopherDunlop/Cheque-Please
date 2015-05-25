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
	public int level;
	public float timer;
	public int score = 0;
	public int playerPatience;
	public float playerSpeed;
	public int levelScore;

	// Use this for initialization
	void Start () {

		//levelScore = 100;
		timer = 180;
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

		if (timer > 0 && score < levelScore) {
			timer -= Time.deltaTime;
			timeDisplay.text = "Time: " + (int) timer;
			scoreDisplay.text = "Score: $" + score;

			activteRandomCustomer ();
		}
		if (score >= levelScore || timer <= 0) {
			scoreDisplay.text = "Score: $" + score;
			timeOutCustomer ();
			if (timer <= 0){
				failed.text = "Level Failed!";
				//button replay level
			}else{
				complete.text = "Level Complete!";
				//button next level
			}
		}

	}

	private void activteRandomCustomer()
	{
		if(rnd.Next(1000) < 6)
		{
			Customer tempCust = GameObject.Find("Customer" + rnd.Next(6)).GetComponent<Customer> ();
			if(tempCust.active != true){

			tempCust.orderSize = rnd.Next (1, 2);
			
			for (int i=0; i<=tempCust.orderSize; i++) {
				
				int tempOrder = 0;

				switch(level){
				case 1:
					tempOrder = rnd.Next (3);
					break;
				case 2:
					tempOrder = rnd.Next (4);
					break;
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
}
