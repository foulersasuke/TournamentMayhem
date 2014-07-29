using UnityEngine;
using System.Collections;

public class CheckLeft : MonoBehaviour {



	public static bool left;
	
	
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "surface")
		{
			left = true;
		}
		
		
	}
	
	
	void OnTriggerExit(Collider other )
	{
		
		if(other.tag == "surface")
		{
			left = false;
		}
		
		
	}





}
