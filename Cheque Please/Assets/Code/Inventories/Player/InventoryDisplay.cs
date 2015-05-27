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
			case "Milkshake":
				Instantiate(foodItems[4], pos, Quaternion.identity);
				GameObject newItem5 = GameObject.Find("Milkshake(Clone)");
				newItem5.name=("Milkshake" + i);
				newItem5.transform.parent = itemParent.transform;
				break;
			case "Icecream":
				Instantiate(foodItems[5], pos, Quaternion.identity);
				GameObject newItem6 = GameObject.Find("Icecream(Clone)");
				newItem6.name=("Icecream" + i);
				newItem6.transform.parent = itemParent.transform;
				break;
			case "CheesyFries":
				Instantiate(foodItems[6], pos, Quaternion.identity);
				GameObject newItem7 = GameObject.Find("CheesyFries(Clone)");
				newItem7.name=("CheesyFries" + i);
				newItem7.transform.parent = itemParent.transform;
				break;
			case "Pizza":
				Instantiate(foodItems[7], pos, Quaternion.identity);
				GameObject newItem8 = GameObject.Find("Pizza(Clone)");
				newItem8.name=("Pizza" + i);
				newItem8.transform.parent = itemParent.transform;
				break;
			case "Salad":
				Instantiate(foodItems[8], pos, Quaternion.identity);
				GameObject newItem9 = GameObject.Find("Salad(Clone)");
				newItem9.name=("Salad" + i);
				newItem9.transform.parent = itemParent.transform;
				break;
			case "Cake":
				Instantiate(foodItems[9], pos, Quaternion.identity);
				GameObject newItem10 = GameObject.Find("Cake(Clone)");
				newItem10.name=("Cake" + i);
				newItem10.transform.parent = itemParent.transform;
				break;
			case "Chicken":
				Instantiate(foodItems[10], pos, Quaternion.identity);
				GameObject newItem11 = GameObject.Find("Chicken(Clone)");
				newItem11.name=("Chicken" + i);
				newItem11.transform.parent = itemParent.transform;
				break;
			}
		}
	}
}
