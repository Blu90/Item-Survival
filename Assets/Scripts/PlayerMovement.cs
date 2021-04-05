using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
	
	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;
	
	public Transform groundCheck;
	public Transform waterCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public LayerMask surfaceWaterMask;
	public LayerMask deepWaterMask;
	
	Vector3 velocity;
	bool isGrounded;
	bool isSubmergedSurface;
	bool isSubmergedDeep;
	bool allowJump;
	bool isSubmerged;
	

    // Update is called once per frame
    void Update()
    {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		isSubmergedSurface = Physics.CheckSphere(waterCheck.position, groundDistance, surfaceWaterMask);
		isSubmergedDeep = Physics.CheckSphere(waterCheck.position, groundDistance, deepWaterMask);
		
		if(isGrounded || isSubmergedDeep || isSubmergedSurface)
		{
			allowJump = true;
		} else
		{
			allowJump = false;
		}
		
		
		if(isGrounded && velocity.y <0)
		{
			velocity.y = -2f;
		}
		
        float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x + transform.forward * z;
		
		controller.Move(move * speed * Time.deltaTime);
		
		if(Input.GetButtonDown("Jump") && allowJump)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		
		velocity.y += gravity * Time.deltaTime;
		
		controller.Move(velocity * Time.deltaTime);
		
		if(isSubmergedSurface)
		{
			gravity = 0f;
			velocity.y = 1f;
		}
		
		if(isSubmergedDeep)
		{
			gravity = 5f;
		}
		
    }
}
