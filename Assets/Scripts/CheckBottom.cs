using UnityEngine;
using System.Collections;

public class CheckBottom : MonoBehaviour {


	public static bool bottom;
	int bottomIndex;
	
	void Start()
	{
	
		bottomIndex = 0;
	
	}
	
	
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "surface")
		{
			bottom = true;
			Character.jumpIndex = 0;
			bottomIndex++;
		}
		
		
	}
	
	
	void OnTriggerExit(Collider other )
	{
		
		
		if(other.tag == "surface")
		{
				
			bottomIndex--;
			
			if(bottomIndex == 0)
			{
				
				bottom = false;
				
			}
			
		}
		
	
		
		
	}


}
