using UnityEngine;
using System.Collections;

public class PickupCatch : MonoBehaviour {

	Transform tr;
	
	public AudioSource pickupSound;

	void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.tag == "item")
		{	
			
			pickupSound.Play();
			
			Inventory.addItem(other.gameObject);
			
			other.gameObject.transform.position = new Vector3(0,-100000,0);
			other.gameObject.rigidbody.isKinematic = true;
			
		}
		
	}

}
