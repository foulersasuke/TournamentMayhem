using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	Vector3 position;
	public bool isThrowable;
	public int forceThrow;
	long itemId;
	
	//weaponStuff
	public bool isShootable;
	public bool isSwingable;
	public float reloadTime;
	public int ammunition;
	public int bulletSet;
	public int bulletNum;
	public float zoomDist;
	float normalFOV; //probably should be 60
	public GameObject bullet;
	public bool isInfiniteAmmo;
	public bool isZoomable;
	GameObject cam;
	bool zoom;
	float t2;
	bool reloading;
	bool thrown;
	Transform dude;
	public static GameObject emit;
	public static Item snizz;
	
	
	public AudioSource reloadSound;
	public AudioSource noAmmoSound;
	public AudioSource useSound;
	public AudioSource itemLand;
	
	
	//add crosshairs????
	
	
	void Start () 
	{
			
		Character.itemCounter++;								////////////////
		itemId = Character.itemCounter;
		
		rigidbody.isKinematic = true;
	
		position = GameObject.Find("ItemPosition").transform.position;
		transform.position = position;
		
		transform.rotation = GameObject.Find("ItemPosition").transform.rotation;
		
		thrown = false;
		dude = GameObject.Find("Inventory").transform;
		
		rigidbody.constraints = RigidbodyConstraints.None;
		
		//weapon stuff
		reloading = false;
		
		cam = GameObject.Find("Main Camera");
		normalFOV = cam.camera.fieldOfView;
		
		snizz = GetComponent<Item>();
		
		if(!isInfiniteAmmo)
		{
			
		}
		else
		{
			ammunition = 10;
			bulletNum = 5; //randomly chosen irreleant number ammunition must be higher than bulletNum
		}
	
	}
	
	void Update()
	{
	
	
	if(!thrown)
	{
	
		if(!transform.IsChildOf(dude))
		{
			thrown = true;
		}
	
		if (Input.GetMouseButtonDown(0))
		{
			
			use();
			
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
			t2 = Time.time + reloadTime;
			Debug.Log(t2);
		}
		
		if(reloading && (t2 <= Time.time))
		{
			reload();
			reloading = false;
			Debug.Log(t2);
		}
	
		Debug.Log ("ammo: " +ammunition + "   bullet num: " + bulletNum );
		
		
		if((Character.throwing == true) && (Character.itemIndex != 0))			//////////////+
		{
			if(isThrowable && (itemId == Character.itemCounter))
			{

				rigidbody.isKinematic = false;
				rigidbody.AddForce(forceThrow * 100 * transform.forward);
				
				thrown = true;
				Character.throwing = false;
				
			}
			
		}
	
	
	
	}
	}
	
	
	
	public void use()
	{
		
		
		//item's function
		
		if(isShootable)
		{
			shoot();
		}
		else
		{
			useSound.Play();
		}
		
	
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
			else if(ammunition > 0 && (!reloading))
			{
			
				noAmmoSound.Play();
				zoomOut();
				reloading = true;
				reloadSound.Play();
				t2 = Time.time + reloadTime;
				
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
		
		t2 = Time.timeSinceLevelLoad - Time.time;
		
		zoom = true;
	
		cam.camera.fieldOfView = Mathf.Lerp(cam.camera.fieldOfView, zoomDist, (t2 + .01f) * Time.deltaTime * 1200);
		
	}
	
	public void zoomOut()
	{
		zoom = false;
		
		cam.camera.fieldOfView = Mathf.Lerp(cam.camera.fieldOfView,normalFOV, (t2 + .01f) * Time.deltaTime * 1500);
	}
	
	
	
	void OnCollisionEnter(Collision other)
	{
		
		
		
		if(!isInfiniteAmmo && isShootable && (ammunition == 0) && (bulletNum == 0))
		{
			if(other.gameObject.tag == "surface")
			{
				Destroy(gameObject);
			}
		}
		
		rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		
		itemLand.Play();
		
	}
	
	
}
