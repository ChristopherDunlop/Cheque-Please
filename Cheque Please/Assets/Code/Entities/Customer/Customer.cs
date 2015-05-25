using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Customer : Entity {

	private Animator animator;
	private float speed;
	public bool active = false;
	public bool served = false;
	public bool outOfTime = false;
	public int time;
	public int counter = 0;
	public int seatNo;
	public playerController checkingPC;
	//System.Random rnd = new System.Random();	
	public List<string> iList = new List<string>();
	public List<string> orderList = new List<string>();		
	public InventoryDisplay iDisplay;
	public GameController gController;
	public bool distance;
	public string order;
	public bool orderIsSet;
	public int orderSize;
	public bool seated;
	public bool orderDisplayed;
	//private int mySeatNo;



	//  Use this for initialization
	void Start () {
		//DontDestroyOnLoad (gameObject);
		animator = this.GetComponent<Animator>();
		checkingPC = GameObject.Find("Player").GetComponent<playerController>();
		iDisplay = GameObject.Find ("OrderDisplay").GetComponent<InventoryDisplay>();
		gController = GameObject.Find ("GameController").GetComponent<GameController>();
		//time = 5000; //time = random
		time = gController.playerPatience;
		speed = gController.playerSpeed;

		//GetComponent<Rigidbody2D> ().transform.position = new Vector3((float)-4.9, (float)(1.4 - (0.7 * mySeatNo)), 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (active == true) {//if the game controller has activated a customer
			counter++;
			if (counter >= time || outOfTime == true){//if customer has waited too long
				outOfTime = true;
				orderList = new List<string>();	
				iDisplay.refresh(orderList, true);
				walkOut();
				seated = false;
			}else if (served == false) {//if the customer has not ben served
				walkIn();
				seated = true;
			} else {
				//leave tip then...
				if (seated == true){
					gController.score = gController.score + 25;
					seated = false;
				}
				walkOut();
			}
		}

		if (Vector2.Distance (GetComponent<Rigidbody2D> ().transform.position, checkingPC.GetComponent<Rigidbody2D> ().transform.position) < 1.48) {
			distance = true;
			iDisplay.refresh (orderList, true);
			orderDisplayed = true;
			
			if (Input.GetKeyDown (KeyCode.Space)) {
				for (int i = 0; i < checkingPC.pList.Count; i++) {
					for(int j =0; j < orderList.Count;j++){
						if (checkingPC.pList [i].Equals (orderList[j])) {
							addToItemInventory (orderList[j]);
							checkingPC.removeItemFromInventory (orderList[j]);
							orderList.Remove (orderList[j]);
							gController.score = gController.score + 10;
							iDisplay.refresh (orderList, true);
							break;
						}
						if(checkingPC.pList.Count == 0)
						{
							break;
						}
					}
				}
				if (orderList.Count == 0)
					served = true;
			}
		}else{

			distance = false;
		}

		if(orderDisplayed == true && distance == false) {
			iDisplay.clear();
			orderDisplayed = false;
		}
	}

	private void walkOut()
	{
		if (GetComponent<Rigidbody2D> ().transform.position.x > -5.5) {
			animator.SetInteger ("Direction", 1);
			GetComponent<Rigidbody2D> ().transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			animator.SetInteger ("Direction", 0);
			active = false;
			served = false;
			outOfTime = false;
			counter = 0;
			orderIsSet = false;
			seated = false;
			orderDisplayed = false;
			iList = new List<string>();
			//time = new random
		}
	}
	private void walkIn()
	{
		if (GetComponent<Rigidbody2D> ().transform.position.x < -2.9) {
			animator.SetInteger ("Direction", 2);
			GetComponent<Rigidbody2D> ().transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			animator.SetInteger ("Direction", 0);//set animation to idle

		}
	}

	public void addToItemInventory(string itemId)
	{
		if (iList.Count < 3) {
			iList.Add(itemId);
		}
	}
}
