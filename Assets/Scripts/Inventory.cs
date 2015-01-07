using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public GameObject setWeapon1;
	public GameObject setWeapon2;
	public static GameObject[] items;
	public static Vector3 itemPos;
	
	public static GameObject weapon1;
	public static GameObject weapon2;
	
	public GameObject empty;

	public GameObject testItem; //hard coding
	public GameObject testItem2;
	
	public static GameObject itemClone1;
	public static GameObject itemClone2;
	public static GameObject itemClone3;
	public static GameObject itemClone4;
	public static GameObject itemClone5;
	
	public static Transform t;
	
	GameObject temp;


	// Use this for initialization
	void Start () 
	{
	
		itemClone1 = new GameObject();
		itemClone2 = new GameObject();
		itemClone3 = new GameObject();
		itemClone4 = new GameObject();
		itemClone5 = new GameObject();
	
		temp = GameObject.Find("Inventory");
		t = temp.transform;
	
		items = new GameObject[10];
	
		weapon1 = setWeapon1;
		weapon2 = setWeapon2;
	
		weapon1.SetActive(true);
		weapon2.SetActive(false);
		
		
	
	}
	
	public static void changeWeaponItem()
	{
	
		Character.itemCounter++;				/////////////////////// + if statements
		
		if(Character.weaponIndex == 1)
		{
		
			weapon1.SetActive(true);
			weapon2.SetActive(false);
			
			itemClone1.SetActive(false);
			itemClone2.SetActive(false);
			itemClone3.SetActive(false);
			itemClone4.SetActive(false);
			itemClone5.SetActive(false);
		
		}
		else if(Character.weaponIndex == 2)
		{
			weapon1.SetActive(false);
			weapon2.SetActive(true);
		
			itemClone1.SetActive(false);
			itemClone2.SetActive(false);
			itemClone3.SetActive(false);
			itemClone4.SetActive(false);
			itemClone5.SetActive(false);
			
		}
		else if(Character.itemIndex != 0)
		{
			weapon1.SetActive(false);
			weapon2.SetActive(false);
			
			chooseItem(Character.itemIndex);
		}
		
	
	}
	
	static void chooseItem(int index)
	{
		if(items[index] != null)
		{
			chooseItemClone(index);
		}
	
	}
	
	static void chooseItemClone(int i)
	{
		switch(i)
		{
		
			case 1: 
					itemClone1.SetActive(true);
					
					if(itemClone1.tag != "item" )
					{
						itemClone1 = (GameObject)Instantiate(items[i]);
						itemClone1.transform.parent = t;
					}
					
					itemClone2.SetActive(false);
					itemClone3.SetActive(false);
					itemClone4.SetActive(false);
					itemClone5.SetActive(false);
				
					break;
					
			
			case 2: 
					itemClone2.SetActive(true);
					
					if(itemClone2.tag != "item")
					{
						itemClone2 = (GameObject)Instantiate(items[i]);
						itemClone2.transform.parent = t;
					}
					
					itemClone1.SetActive(false);
					itemClone3.SetActive(false);
					itemClone4.SetActive(false);
					itemClone5.SetActive(false);
				
					break;
					
			case 3: 
					itemClone3.SetActive(true);
					
					if(itemClone3.tag != "item")
					{
						itemClone3 = (GameObject)Instantiate(items[i]);
						itemClone3.transform.parent = t;
					}
					
					itemClone1.SetActive(false);
					itemClone2.SetActive(false);
					itemClone4.SetActive(false);
					itemClone5.SetActive(false);
						
					break;
					
			case 4: 
					itemClone4.SetActive(true);
					
					if(itemClone4.tag != "item")
					{
						itemClone4 = (GameObject)Instantiate(items[i]);
						itemClone4.transform.parent = t;
					}
					
					itemClone1.SetActive(false);
					itemClone2.SetActive(false);
					itemClone3.SetActive(false);
					itemClone5.SetActive(false);
			
					break;
					
			case 5: 
					itemClone5.SetActive(true);
					
					if(itemClone5.tag != "item")
					{
						itemClone5 = (GameObject)Instantiate(items[i]);
						itemClone5.transform.parent = t;
					
					}
					
					itemClone1.SetActive(false);
					itemClone2.SetActive(false);
					itemClone3.SetActive(false);
					itemClone4.SetActive(false);
				
					break;
		
		}
	
	
	}
	
	public static void addItem(GameObject newItem)
	{
		int pos = findSlot();
		
		if(pos > 0)
		{
			items[pos] = newItem;
		}
		else
		{
			Debug.Log ("No room :( "); //no room
		
		}
		
	}
	
	static int findSlot()
	{
		for(int i = 1; i <= Character.itemMax; i++)				//////////////
		{
			if(items[i] == null)
			{
				return i;
			
			}
		}
		
		return -1;
	}
	
	public static void removeItem(int index)
	{
	
		items.SetValue(null, index);
		
		switch(index)
		{
		
		case 1:	Destroy(itemClone1.gameObject);
				itemClone1 = new GameObject();
				break;
			
		case 2: Destroy(itemClone2.gameObject);
				itemClone2 = new GameObject();
				break;
			
		case 3: Destroy(itemClone3.gameObject);
				itemClone3 = new GameObject();
				break;
			
		case 4: Destroy(itemClone4.gameObject);
				itemClone4 = new GameObject();
				break;
			
		case 5: Destroy(itemClone5.gameObject);
				itemClone5 = new GameObject();
				break;
		
		}
	
	}
	
}
