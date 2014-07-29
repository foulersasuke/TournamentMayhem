using UnityEngine;
using System.Collections;

public class RemoveItem : MonoBehaviour {

	
	
	
	
	
	void OnTriggerEnter(Collider other)
	{
		
		Inventory.removeItem(1);
		
		//Inventory.removeItem(3);
		
	
		
	}
	
	
	
	
	
	
	
	
}
