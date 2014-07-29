using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int setPowerMax;
	public int setHealthMax;
	public int setWeaponMax;
	public int setItemMax;


	public string characterName;
	public static int healthMax;
	public Vector3 jumpHeight;
	public int numJumpMax;
	public float jumpSpeed;
	public float fallSpeed;
	public int speed;
	public int sprint;
	public static int powerMax;
	public static int weaponMax;
	public static int itemMax;
	public int ePower;
	public int qPower;
	public int fPower;
	
	
	public static int jumpIndex;
	public static int power;
	public static int health;
	public static int weaponIndex;
	public static int itemIndex;
	Vector3 forward;
	Vector3 right;
	float wTemp;
	float wTempCheck;
	Vector3 destination = new Vector3();
	bool movingUp;
	public static bool throwing;
	
	
	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
	
		throwing = false;
		powerMax = setPowerMax;
		healthMax = setHealthMax;
		itemMax = setItemMax;
		weaponMax = setWeaponMax; //whoops
	
		
		movingUp = false;
		jumpIndex = 0;
		power = powerMax;
		health = healthMax;
		Jog();
		weaponIndex = 1;
		wTemp = 0;
		wTempCheck = 0;
		itemIndex = 0;
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//Recieve Input
	
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
	
	
	
		if (Input.GetKeyDown("space"))
		{
			jump();							
		}
		
		if (Input.GetKey("w") && (CheckFront.front == false))
		{
			transform.Translate(forward * Time.deltaTime);
		}
		else if(Input.GetKey("s") && (CheckBack.back == false))
		{
			transform.Translate(-forward * Time.deltaTime);
		}
		
		if (Input.GetKey("d") && (CheckRight.right == false))
		{
			transform.Translate(right * Time.deltaTime);
		}
		else if(Input.GetKey("a") && (CheckLeft.left == false) )
		{
			transform.Translate(-right * Time.deltaTime);
		}
	
			
		if (Input.GetKeyDown("q"))
		{
		
			usePower(qPower);
			Debug.Log(power);
		}
		else if (Input.GetKeyDown("e"))
		{
			usePower(ePower);
			Debug.Log(power);
			
		}
			
		
		
		if(Input.GetMouseButtonDown(2))
		{
			
			
			//throwItem
			throwing = true;
			
			Instantiate(Inventory.items[Character.itemIndex]);
			
			
			Inventory.removeItem(Character.itemIndex);
			
			
			weaponIndex = 1;
			Inventory.changeWeaponItem();
			
		}	
		
	
		
		if (Input.GetKeyDown("f"))
		{
			usePower(fPower);
			Debug.Log(power);
		}
		
		if (Input.GetKeyDown("left shift"))
		{
			Sprint();
		}
		if(Input.GetKeyUp("left shift"))
		{
			Jog();
		}
		
		if (Input.GetKey("x"))
		{
			Debug.Log("x"); //crouch?
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
	
		
		if(movingUp)
		{
		
		
			if((transform.position.y < destination.y) && (CheckTop.top == false))
			{
				transform.position += (Vector3.up * jumpSpeed * Time.deltaTime);
			}
			else
			{
				movingUp = false;
			
			}
		
		}
		else if(CheckBottom.bottom == false)
		{
		
			
			transform.position += (Vector3.down * fallSpeed * Time.deltaTime);
		
		
		}
	

	
	
	





	}
			
		

	
	
	
	
		
	
	
	void jump()
	{
	
		if(jumpIndex < numJumpMax)
		{
			destination = transform.position + jumpHeight;
				
			
			movingUp = true;

				
			jumpIndex++;
				
		}
		
	}
	
	
	void Sprint()
	{
	
		forward = new Vector3(0,0,speed + sprint);
		right = new Vector3(speed + sprint,0,0);
	
	}
	
	void Jog()
	{
		forward = new Vector3(0,0,speed);
		right = new Vector3(speed,0,0);
	
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