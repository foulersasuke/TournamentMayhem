using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed;

	GameObject g;
	Transform tran;

	// Use this for initialization
	void Start () 
	{
	
		g = GameObject.Find("Emitter");
		tran = g.transform;
		transform.position = tran.position;
		
	
		rigidbody.velocity = g.transform.forward * speed * 100;
	
	}
	
	
	
	
	
	
	
	void OnCollisionEnter(Collision other)
	{
	
		if(other.gameObject.tag != "weapon")
		{
			Destroy(gameObject);
		
		}
		
	
	}
	
	


	
	
}
