using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	GameObject guy;

	// Use this for initialization
	void Start () 
	{
	
		guy = GameObject.Find("Inventory");
	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(!transform.IsChildOf(guy.transform))
		{
		
			gameObject.name = "Notemitting";
			
		}
		else
		{
			gameObject.name = "Emitter";
		
		}
		
	
	}
}
