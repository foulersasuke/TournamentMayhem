using UnityEngine;
using System.Collections;

public class MainWeapon : MonoBehaviour {

	Vector3 position;
	GameObject temp;
	Transform tran;
	public bool isShootable;
	public bool isSwingable;
	public float reloadTime;
	public int ammunition;
	public int bulletSet;
	int bulletNum;
	public float zoomDist;
	float normalFOV; //probably should be 60
	public GameObject bullet;
	public bool isInfiniteAmmo;
	public bool isZoomable;
	GameObject cam;
	bool zoom;
	float t;
	bool reloading;
	
	public AudioSource reloadSound;
	public AudioSource noAmmoSound;
	public AudioSource useSound;
	
	
	//////////crosshairs???

	
	void Start () 
	{
		reloading = false;
		
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
	
		if (Input.GetMouseButtonDown(0) && !reloading)
		{
			shoot();
		}
		if(Input.GetMouseButton(1))
		{
			if(isZoomable && !reloading)
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
		
		}
		else
		{
			zoomOut();
		}
		
		if (Input.GetKeyDown("r") && !isInfiniteAmmo && (ammunition != 0) && (reloading == false) && (bulletNum != bulletSet))
		{
			zoomOut();
			reloadSound.Play();
			reloading = true;
			t = Time.time + reloadTime;
			Debug.Log(t);
		}
		
		if(reloading && (t <= Time.time))
		{
			reload();
			reloading = false;
		}
	
		Debug.Log ("ammo: " +ammunition + "   bullet num: " + bulletNum );
	
	}
	
	public void shoot()
	{
	
		if(isShootable && !reloading)
		{
			if(bulletNum > 0)
			{
			
				useSound.Play();
				
				Instantiate(bullet);
			
				
				if(!isInfiniteAmmo)
				{
					bulletNum--;
				}
					
				
			}
			else if(ammunition > 0 && !reloading)
			{
				noAmmoSound.Play();
				zoomOut();
				reloading = true;
				reloadSound.Play();
				t = Time.time + reloadTime;
					
				Debug.Log ("reloading");
			}
			else
			{
				noAmmoSound.Play();
			}
			
		}
		
	}
	
	public void reload()
	{
		
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
	
		t = Time.timeSinceLevelLoad - Time.time;
		
		zoom = true;
		cam.camera.fieldOfView = Mathf.Lerp(cam.camera.fieldOfView, zoomDist, (t + .01f) * Time.deltaTime * 1000);
	
	}
	
	public void zoomOut()
	{
		zoom = false;
		cam.camera.fieldOfView = Mathf.Lerp(cam.camera.fieldOfView,normalFOV,(t + .01f) * Time.deltaTime * 1500);
	}
	
	
	
}
