using UnityEngine;
using System.Collections;

public class CheckBack : MonoBehaviour {

	public static bool back;
	
	
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "surface")
		{
			back = true;
		}
		
		
	}
	
	
	void OnTriggerExit(Collider other )
	{
		
		if(other.tag == "surface")
		{
			back = false;
		}
		
		
	}
}
