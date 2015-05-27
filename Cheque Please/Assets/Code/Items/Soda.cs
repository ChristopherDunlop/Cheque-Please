using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soda : MonoBehaviour {

	public ItemManager iManager;
	//public List<inventory> items = new List<inventory>();
	public playerController checkingPC;
	public bool test;
	public bool distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector2.Distance (GetComponent<Rigidbody2D> ().transform.position, checkingPC.GetComponent<Rigidbody2D> ().transform.position) < 0.9) 
		{
			distance = true;
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				test = !test;
				checkingPC.addToItemInventory ("Soda");
			}			
		}else{
			distance = false;
		}
	}

	/*public void addToItemInverntory(int itemId, int amount)
	{
		for (int i = 0; i < iManager.items.Count; i++) {
			if(iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
			{
				inventory inv = new inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
				items.Add(inv);
				//items.Add(iManager.items[i].itemTransform.GetComponent<Item>());
			}
		}
	}*/
}