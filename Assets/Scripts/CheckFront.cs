using UnityEngine;
using System.Collections;

public class CheckFront : MonoBehaviour {

	public static bool front;

	
	
	void OnTriggerEnter(Collider other)
	{
	
		if(other.tag == "surface")
		{
			front = true;
		}
	
	
	}
	
	
	void OnTriggerExit(Collider other )
	{
	
		if(other.tag == "surface")
		{
			front = false;
		}
		
	
	}
	
	
}
