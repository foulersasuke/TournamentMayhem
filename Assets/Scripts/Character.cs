using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int setPowerMax;
	public int setHealthMax;
	public int setWeaponMax;
	public int setItemMax;

	public string characterName;
	public static int healthMax;
	public static int powerMax;
	public static int weaponMax;
	public static int itemMax;
	public int ePower;
	public int qPower;
	public int fPower;
	
	
	public static int power;
	public static int health;
	public static int weaponIndex;
	public static int itemIndex;
	
	float wTemp;
	float wTempCheck;

	bool movingUp;
	public static bool throwing;
	public static long itemCounter;
	
	public static Transform cTrans;
	public static Item snozz;
	GameObject tempy;
	
	public AudioSource throwSound;
	public AudioSource epowerSound;
	public AudioSource qpowerSound;
	public AudioSource fpowerSound;
	
	public AudioSource lowhealthSound;
	
	
	// Use this for initialization
	void Start () 
	{
		cTrans = transform;
	
		itemCounter = 0;
		throwing = false;
		powerMax = setPowerMax;
		healthMax = setHealthMax;
		itemMax = setItemMax;
		weaponMax = setWeaponMax; //whoops
	
		power = powerMax;
		health = healthMax;
		weaponIndex = 1;
		wTemp = 0;
		wTempCheck = 0;
		itemIndex = 0;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Screen.showCursor = false;
	
		wTemp += Input.GetAxis("Mouse ScrollWheel");
		if(wTemp != wTempCheck)
		{
			itemIndex = 0;
		
			if(wTemp > wTempCheck && (weaponIndex < weaponMax))
			{
				
				weaponIndex++;
				Inventory.changeWeaponItem();
			}
			else if(wTemp < wTempCheck && (weaponIndex > 1))
			{
				
				weaponIndex--;
				Inventory.changeWeaponItem();
			}	
			wTempCheck = wTemp;
		}
	
			
		if (Input.GetKeyDown("q") && (qPower != 0))
		{
			qpowerSound.Play();
		
			usePower(qPower);
			Debug.Log(power);
		}
		else if (Input.GetKeyDown("e") && (ePower != 0))
		{
			epowerSound.Play();
		
			usePower(ePower);
			Debug.Log(power);
		}
			
		
		if(((Input.GetMouseButtonDown(2) || Input.GetKeyDown("t"))  && (itemIndex != 0)))
		{
	
			//throwItem
			
			throwSound.Play();
			
			throwing = true;
			
			tempy = (GameObject) Instantiate(Inventory.items[Character.itemIndex]);
			
			snozz = tempy.GetComponent<Item>();
			snozz.ammunition = Item.snizz.ammunition;
			snozz.bulletNum = Item.snizz.bulletNum;
			
	
			Inventory.removeItem(itemIndex);
			
		}
		else if(Input.GetMouseButtonUp(2) || Input.GetKeyUp("t"))
		{
			
			weaponIndex = 1;
			Inventory.changeWeaponItem();
			
		}	
		
		
		if (Input.GetKeyDown("f") && (fPower != 0))
		{
			fpowerSound.Play();
		
			usePower(fPower);
			Debug.Log(power);
		}
		
		
		if (Input.GetKeyDown("1"))
		{
			
		
			if(itemIndex == 1)
			{
				itemIndex = 0;
				Character.weaponIndex = 1;
			}
			else
			{
				if(Inventory.items[1] != null)
				{
					weaponIndex = 0;
					itemIndex = 1;
				}
				
				
			}
			
			Inventory.changeWeaponItem();	
			
		}
		else if (Input.GetKeyDown("2"))
		{
			
		
			if(itemIndex == 2)
			{
				itemIndex = 0;
				Character.weaponIndex = 1;
				
			}
			else
			{
				if(Inventory.items[2] != null)
				{
					weaponIndex = 0;
					itemIndex = 2;
				}
				
			}
			
			Inventory.changeWeaponItem();
			
		}
		else if (Input.GetKeyDown("3"))
		{
			
			
			if(itemIndex == 3)
			{
				itemIndex = 0;
				
				Character.weaponIndex = 1;
			}
			else
			{
				if(Inventory.items[3] != null)
				{
					weaponIndex = 0;
					itemIndex = 3;
				}
				
			
			}
			
			Inventory.changeWeaponItem();
			
		}
		else if (Input.GetKeyDown("4"))
		{
			
		
			if(itemIndex == 4)
			{
				itemIndex = 0;
				Character.weaponIndex = 1;
			}
			else
			{
			
				if(Inventory.items[4] != null)
				{
					weaponIndex = 0;
					itemIndex = 4;
				}
				
			
			}
			
			Inventory.changeWeaponItem();
			
		}
		else if (Input.GetKeyDown("5"))
		{
			
		
			if(itemIndex == 5)
			{
				itemIndex = 0;
				Character.weaponIndex = 1;
			}
			else
			{
				if(Inventory.items[5] != null)
				{
					weaponIndex = 0;
					itemIndex = 5;
				}
				
				
			}
			
			Inventory.changeWeaponItem();
			
		}
		
		
		
	}
	
	
	
	public static void Heal(int healthPoints)
	{
	
		int need = healthMax - health;
		
		
		if(need >= healthPoints)
		{
			
			health += healthPoints;
			
		}
		else
		{
			health += need;
		}
		
	
	}
	
	
	public static void Hurt(int damage)
	{
	
		health -= damage;
		
		if(health <= 0)
		{
			Die();
		}
	
	}
	
	
	public static void Die()
	{
	
		Debug.Log("Deattttthhhhh");
	
	}
	
	
	
	public static int usePower(int spentPower)
	{
		
		if(power >= spentPower )
		{
			power -= spentPower;
			return 0;
		
		}
		else
		{
			return 1;
		}
		
	
	}
	
	
	public static void gainPower(int powerPoints)
	{
	
		int needP = powerMax - power;
		
		if(needP >= powerPoints)
		{
			
			power += powerPoints;
			
		}
		else
		{
			power += needP;
		}
	
	
	}
	
	
	
}