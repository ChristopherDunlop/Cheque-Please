using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

	private Animator animator;
	private float speed = 2;
	public List<string> pList = new List<string>();
	//public Transform[] foodItems;
	//public bool holdingObject = false;
	//public GameObject itemParent;
	public InventoryDisplay iDisplay;
	public AudioSource pickUp;
	//public ItemPlayerManager ipManager;
	
	// Use this for initialization
	void Start()
	{
		//ipManager.addToItemInverntory (0, 5);
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
		if (Input.GetKeyDown (KeyCode.F)) {
			pList = new List<string>();
			iDisplay.refresh(pList, false);
			pickUp.Play ();
		}
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		
		if (vertical > 0) {
			GetComponent<Rigidbody2D> ().transform.position += Vector3.up * speed * Time.deltaTime;
			animator.SetInteger ("Direction", 2);
		} else if (vertical < 0) {
			GetComponent<Rigidbody2D> ().transform.position += Vector3.down * speed * Time.deltaTime;
			animator.SetInteger ("Direction", 0);
		} else if (horizontal > 0) {
			GetComponent<Rigidbody2D> ().transform.position += Vector3.right * speed * Time.deltaTime;
			animator.SetInteger ("Direction", 3);
		} else if (horizontal < 0) {
			GetComponent<Rigidbody2D> ().transform.position += Vector3.left * speed * Time.deltaTime;
			animator.SetInteger ("Direction", 1);
		} else {
			animator.SetInteger ("Direction", 5);
		}
	}

	public void addToItemInventory(string itemName)
	{
		if (pList.Count < 2) {
			pList.Add(itemName);
			pickUp.Play ();
			iDisplay.refresh(pList, false);
		}
	}
	public void removeItemFromInventory(string itemName)
	{
		if (pList.Count > 0) {
			pList.Remove(itemName);	
			pickUp.Play ();
			iDisplay.refresh(pList, false);
		}
	}
}
