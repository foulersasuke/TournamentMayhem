using UnityEngine;
using System.Collections;

public class CheckRight : MonoBehaviour {


	public static bool right;
	
	
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "surface")
		{
			right = true;
		}
		
		
	}
	
	
	void OnTriggerExit(Collider other )
	{
		
		if(other.tag == "surface")
		{
			right = false;
		}
		
		
	}





}