using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour {

	float speed;
	bool moving;
	int landing;
	int bigLanding;
	public float walkingSoundSpeed;
	float sprintSoundSpeed;
	public float sprint;
	public float jog;
	public float jumpSpeed;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	Vector3 destination = Vector3.zero;
	bool jumping = false;
	public Vector3 jumpHeight;
	public int jumpMax;
	bool backwards;
	bool sprinting;
	float backWalk;
	float backSprint;
	int jumpIndex;
	CharacterController controller;
	
	public AudioSource jumpSound;
	public AudioSource landSound;
	public AudioSource bigLandSound;
	public AudioSource walkingSoundLeft;
	public AudioSource walkingSoundRight;
	
	void Start () 
	{
		backwards = false;
		speed = jog;
		gravity = gravity * 100;
		jumpIndex = 0;
		controller = GetComponent<CharacterController>();
		backWalk = jog - jog/4;
		backSprint = sprint - sprint / 3;
		sprintSoundSpeed = walkingSoundSpeed / 2;
		landing = 1;
		bigLanding = 1;
		moving = false;
			
	}
	
	void Update () 
	{
		
		if(controller.isGrounded) 
		{
			jumpIndex = 0;
			
			if(landing == 0)
			{
				landSound.Play();
				landing++;
			}
			else if(bigLanding == 0)
			{
				bigLandSound.Play();
				bigLanding++;
			}
			
			
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));	
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}
		else
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed / 2;
		}
		
		if (Input.GetKeyDown("space"))
		{
			jump();
		}
		
		if(jumping)
		{
			if((transform.position.y < destination.y) && !CheckTop.top)
			{
				transform.position += new Vector3(0,jumpSpeed * Time.deltaTime,0);
			}
			else
			{
				jumping = false;
				
				if(transform.position.y >= 50)
				{
					bigLanding = 0;
				}
				else
				{
					landing = 0;
				}
				
			}
			
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		
		
		if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
		{
			moving = true;
			
		}
		else
		{
			moving = false;
		}
		
		
		if(Input.GetKey("s"))
		{
			backwards = true;
			
		}
			
		if(Input.GetKeyDown("s"))
		{
			backwards = true;
			
			speed = backWalk;
		}
		else if(Input.GetKeyUp("s"))
		{
			backwards = false;
			speed = jog;
			
		}
	
		if (Input.GetKey("left shift") && controller.isGrounded)
		{
			speed = sprint;
			sprinting = true;
			
			if(backwards)
			{
				speed = backSprint;
				
			}
		}
		
		if(Input.GetKeyUp("left shift") && controller.isGrounded) // jog
		{
			speed = jog;
			sprinting = false;
			
			if(backwards)
			{
				speed = backWalk;
			}
		}
		
		controller.Move(Vector3.ClampMagnitude(moveDirection,speed) * Time.deltaTime);
		
		
		
		playMovementSound();
		
		
		
	}
	
	
	void jump()
	{
		jumpIndex++;
	
		if(jumpIndex < jumpMax)
		{
			jumpSound.Play();
		
			moveDirection.y -= gravity * 2 * Time.deltaTime;
			
			destination = transform.position + jumpHeight;
			jumping = true;
			jumpIndex++;
		
		}
		else
		{
			//strong attack down?
		}
		
	
	}
	
	void playMovementSound()
	{
	
		if(controller.isGrounded && moving)
		{
			
			if(sprinting)
			{
				
				if(!(walkingSoundLeft.isPlaying || walkingSoundRight.isPlaying))
				{
					walkingSoundLeft.Play();
					walkingSoundRight.PlayDelayed(sprintSoundSpeed);
					
					Invoke("wait",sprintSoundSpeed);
						
				}	
				
			}
			else
			{
				
				if(!(walkingSoundLeft.isPlaying || walkingSoundRight.isPlaying))
				{
					walkingSoundLeft.Play();
					walkingSoundRight.PlayDelayed(walkingSoundSpeed);
					
					Invoke("wait",walkingSoundSpeed);
					
				}
				
				
			}
			
		}
	
	
	
	}
	
	
	void wait()
	{
		//////waiting
	}

	
	
}
