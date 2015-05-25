﻿using UnityEngine;
using System.Collections;

public class Fries : MonoBehaviour {

	public ItemManager iManager;
	public playerController checkingPC;
	public bool test;
	public bool distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector2.Distance (GetComponent<Rigidbody2D> ().transform.position, checkingPC.GetComponent<Rigidbody2D> ().transform.position) < 0.55) 
		{
			distance = true;
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				test = !test;
				checkingPC.addToItemInventory ("Fries");
			}			
		}else{
			distance = false;
		}
	}
}
