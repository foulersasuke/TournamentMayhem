using UnityEngine;
using System.Collections;

public class CheckTop : MonoBehaviour {


	public static bool top;
	
	
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "surface")
		{
			top = true;
		}
		
		
	}
	
	
	void OnTriggerExit(Collider other )
	{
		
		if(other.tag == "surface")
		{
			top = false;
		}
		
		
	}






}
