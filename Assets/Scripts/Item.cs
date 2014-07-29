using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {


	public bool isThrowable;
	
	void Start () 
	{
	
		rigidbody.isKinematic = false;
	
	}
	
	void Update()
	{
	
		if (Input.GetMouseButtonDown(0))
		{
			
			use();
			
		}
		
		if(Input.GetMouseButton(1))
		{
			
			//need right click stuff?
			
		}
	

	
	
	}
	
	
	
	public void use()
	{
	
	
	
		//item's function
		Debug.Log ("using item");
	
	
	
	
	}
	

	
	
}
