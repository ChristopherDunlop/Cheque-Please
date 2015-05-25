using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPlayerManager : MonoBehaviour {

	public ItemManager iManager;
	public List<inventory> items = new List<inventory>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addToItemInverntory(int itemId, int amount)
	{
		for (int i = 0; i < iManager.items.Count; i++) {
			if(iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
			{
				inventory inv = new inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
				items.Add(inv);
				//items.Add(iManager.items[i].itemTransform.GetComponent<Item>());
			}
		}
	}

	public void removeItemInverntory(int itemId, int amount)
	{
		for (int i = 0; i < iManager.items.Count; i++) {
			if(iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
			{
				inventory inv = new inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
				items.Remove(inv);
				//items.Add(iManager.items[i].itemTransform.GetComponent<Item>());
			}
		}
	}
}

[System.Serializable]
public class inventory
{
	public Item item;
	public int amountOfItem;

	public inventory(Item item, int amountOfItem)
	{
		this.item = item;
		this.amountOfItem = amountOfItem;
	}
}
