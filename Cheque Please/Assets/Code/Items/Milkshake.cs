using UnityEngine;
using System.Collections;

public class Milkshake : MonoBehaviour {

	public ItemManager iManager;
	public playerController checkingPC;
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
				checkingPC.addToItemInventory ("Milkshake");
			}			
		}else{
			distance = false;
		}
	}
}
