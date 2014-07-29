using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

		
	GameObject temp;
	Transform tran;

	public bool isShootable;
	public bool isSwingable;
	public bool isThrowable;
	
	public float reloadTime;
	public int ammunition;
	public int bulletSet;
	int bulletNum;
	public int throwSpeed;
	
	public float zoomSpeed;
	public float zoomDist;
	float normalFOV; //probably should be 60
	
	
	public GameObject bullet;
	
	public bool isInfiniteAmmo;
	public bool isZoomable;
	
	GameObject cam;
	
	bool zoom;
	
	
	
	//////////crosshairs???


	
	void Start () 
	{
	
		rigidbody.isKinematic = true;
		
		cam = GameObject.Find("Main Camera");

		normalFOV = cam.camera.fieldOfView;
	
	
	
	
		if(!isInfiniteAmmo)
		{
			bulletNum = bulletSet;
		}
		else
		{
			ammunition = 10;
			bulletNum = 5; //randomly chosen irreleant number ammunition must be higher than bulletNum
		}
	
		
	
	
	
	}
	
	
	
	void Update()
	{
	
		if (Input.GetMouseButtonDown(0))
		{
		
			shoot();
		
		
		
		}
		if(Input.GetMouseButton(1))
		{
			
			
			if(isZoomable)
			{
			
				zoomIn();
				
			}
			
			
		}
		if(Input.GetMouseButtonUp(1))
		{
			
			
			if(isZoomable)
			{
				
				zoomOut();
				
			}
			
			
		}
		
		
		
		if(zoom)
		{
		
			cam.camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,zoomDist,zoomSpeed);
		
		
		}
		else
		{
			
			cam.camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,normalFOV,zoomSpeed);
		
		
		}
		
		
		
		
		
		/*if(Input.GetMouseButtonDown(2))
		{
		
			if(isThrowable)
			{
				//throw
				
				throw();
				
				
			
			}
		
			
			
		}*/
	
		if (Input.GetKeyDown("r"))
		{
			reload();
		}
	
	
		Debug.Log ("ammo: " +ammunition + "   bullet num: " + bulletNum );
	
	
	}
	
	
	
	
	
	
	
	
	public void shoot()
	{
	
		if(isShootable)
		{
			if(bulletNum > 0)
			{
				
				Instantiate(bullet);
			
				
				if(!isInfiniteAmmo)
				{
					bulletNum--;
				}
					
				
			}
			else
			{
				reload();	
				Debug.Log ("reloading");
			}
			
		}
		
	
	
	}
	
	public void reload()
	{
	
		
		//reloadTime? 
		
		
		if(!isInfiniteAmmo)
		{
			int need = bulletSet - bulletNum;
		
		
			if(ammunition >= need)
			{
				ammunition -= need;
				bulletNum += need;
			
			}
			else
			{
				bulletNum += ammunition;
				ammunition = 0;
			}
			
		
		}
		else
		{
			bulletNum = bulletSet;
		}
		
		
	
	}
	
	
	
	public void addAmmo(int num)
	{
	
		ammunition += num;
	
	}
	
	
	
	
	public void zoomIn()
	{
	
	
		zoom = true;
		
	
	}
	
	public void zoomOut()
	{
		
		zoom = false;
		
	}
	
	
	
	
	
	/*public void throw()
	{
	
	
		temp = GameObject.Find("Character");
		tran = temp.transform;
		mePref.transform.position = tran.position;
		
		mePref.rigidbody.isKinematic = false;
		mePref.rigidbody.velocity = temp.transform.forward * throwSpeed * 100;
		
	
		Instantiate(mePref);
	
	
	}*/
	
	
	
	
	
	

	
	
	
	
}
