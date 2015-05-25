using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryDisplay : MonoBehaviour {

	public GameObject itemParent;
	public Transform[] foodItems;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clear(){
		foreach (Transform child in itemParent.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void refresh(List<string> newPList, bool order){

		bool holdingObject = false;
		Vector2 pos;
		float x, y;

		if (order == true) {
			x = (float)-4;
			y = (float)2.3;
			itemParent = GameObject.Find("Order");
		} else {
			x = (float)2.4;
			y = (float)2.3;
		}

		//delets all child objects
		foreach (Transform child in itemParent.transform) {
			GameObject.Destroy(child.gameObject);
		}

		for (int i = 0; i < newPList.Count; i++) {

			if(holdingObject == true)
			{
				pos = new Vector2(x, y);				
				holdingObject = false;
			}else{
				pos = new Vector2(x+(float)0.8, y);
				holdingObject = true;
			}

			switch (newPList[i])
			{
			case "Burger":
				Instantiate(foodItems[0], pos, Quaternion.identity);
				GameObject newItem = GameObject.Find("Burger(Clone)");
				newItem.name=("Burger" + i);
				newItem.transform.parent = itemParent.transform;
				break;

			case "Soda":
				Instantiate(foodItems[1], pos, Quaternion.identity);
				GameObject newItem2 = GameObject.Find("Soda(Clone)");
				newItem2.name=("Soda" + i);
				newItem2.transform.parent = itemParent.transform;
				break;

			case "Fries":
				Instantiate(foodItems[2], pos, Quaternion.identity);
				GameObject newItem3 = GameObject.Find("Fries(Clone)");
				newItem3.name=("Fries" + i);
				newItem3.transform.parent = itemParent.transform;
				break;
			case "Hotdog":
				Instantiate(foodItems[3], pos, Quaternion.identity);
				GameObject newItem4 = GameObject.Find("Hotdog(Clone)");
				newItem4.name=("Hotdog" + i);
				newItem4.transform.parent = itemParent.transform;
				break;
			}
		}
	}
}
