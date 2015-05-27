﻿using UnityEngine;
using System.Collections;

public class Chicken : MonoBehaviour {

	public ItemManager iManager;
	public playerController checkingPC;
	public bool distance;
	
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector2.Distance (GetComponent<Rigidbody2D> ().transform.position, checkingPC.GetComponent<Rigidbody2D> ().transform.position) < 0.7) 
		{
			distance = true;
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				checkingPC.addToItemInventory ("Chicken");
			}			
		}else{
			distance = false;
		}
	}
}
