using UnityEngine;
using System.Collections;

public class GiveItem : MonoBehaviour {


	public GameObject addedItem;

	

	void OnTriggerEnter(Collider other)
	{
		int i = 1;
	
		if(i <= Character.itemMax)
		{
			Inventory.addItem(addedItem);
			i++;
		}
		
	
	
	
	}







}
