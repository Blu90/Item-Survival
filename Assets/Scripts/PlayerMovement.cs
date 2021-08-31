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
		if (DeathMenu.YouAreDead) return;

		bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		
        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		move = transform.right * x + transform.forward * z;
		controller.Move(move * speed * Time.deltaTime);
		
		// physics for deep water
		if(player.transform.position.y < deepWater.transform.position.y)
		{

			// update velocity relative to gravity
			velocity.y += -1f * gravity * Time.deltaTime;

		}
		// physics for surface water
		else if(player.transform.position.y < surfaceWater.transform.position.y)
		{
			


			// check if player is holding jump button
			if(Input.GetButton("Jump") || velocity.y > Mathf.Sqrt(jumpHeight * -2f * gravity))
				velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

			// TODO: Add sinking by pressing Ctrl. Will be the opposite effect compared to pressing space.
			// Noah: "Feel free to change this in any way you see fit. For now I'm doing a copy-paste maneuver to get this working."

			if (Input.GetKeyDown(KeyCode.LeftControl) || velocity.y < -9.8f)
				velocity.y = -9.8f;

			// TODO: Add maintain position by pressing both Ctrl and Space. Will counteract the water's natural upward force.	
            // Noah: "I tried and this one is too hard."		


			// update velocity relative to buoyancy
			velocity.y += -0.05f * gravity * Time.deltaTime;

			// possibly cap upward velocity here so you don't float increasingly faster up
			// very bouncy at the moment but some tweaks could help
		}
		// physics for land
		else
		{
			// check if jump first pressed on ground
			if(Input.GetButtonDown("Jump") && isGrounded)
			{
				velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
			}

			// update velocity relative to gravity
			velocity.y += gravity * Time.deltaTime;
		}
		
		// cap downward velocity when on ground
		if(isGrounded && velocity.y <0)
		{
			velocity.y = -2f;
		}

		controller.Move(velocity * Time.deltaTime);

    }
}
