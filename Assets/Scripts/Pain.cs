using UnityEngine;
using System.Collections;

public class Pain : MonoBehaviour {


	public int bulletDamage;
	

	
	
	void OnCollisionEnter(Collision other)
	{
	
	
		if(other.gameObject.tag == "bullet")
		{
			//figure out what weapon/gameobject to help decide
		
			Character.Hurt(bulletDamage);
		
		}
	
	
	
	}
	
	
	
	
}
