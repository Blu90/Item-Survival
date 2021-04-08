using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
	
	public GameObject player;
	public GameObject surfaceWater;
	public GameObject deepWater;

	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;
	public float groundDistance = 0.4f;

	public Transform groundCheck;
	public LayerMask groundMask;
	
	Vector3 move, velocity;

	void Start()
	{
		player = GameObject.Find("First Person Player");
		surfaceWater = GameObject.Find("SurfaceWater");
		deepWater = GameObject.Find("DeepWater");
	}

    // Update is called once per frame
    void Update()
    {
		
		bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		
        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		move = transform.right * x + transform.forward * z;
		controller.Move(move * speed * Time.deltaTime);
		
		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		else if(Input.GetButton("Jump"))
		{
			if(player.transform.position.y < deepWater.transform.position.y)
			{
				velocity.y = Mathf.Sqrt(jumpHeight * -10f * gravity);
			}
			else if(player.transform.position.y < surfaceWater.transform.position.y)
			{
				velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
			}
		}

		// update velocity relative to gravity
		velocity.y += gravity * Time.deltaTime;
		
		// Caps downward velocity when on ground.
		if(isGrounded && velocity.y <0)
		{
			velocity.y = -2f;
		}

		controller.Move(velocity * Time.deltaTime);

    }
}
