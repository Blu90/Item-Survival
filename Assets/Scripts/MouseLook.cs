using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
	public float mouseSensitivity = 100f;
	
	public Transform playerBody;
	
	float xRotation = 0f;
	
	// Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
		MainMenu.OnMainMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
		// I wrote this if-else code myself.
		if (PauseMenu.GameIsPaused || MainMenu.OnMainMenu)
		{
			Cursor.lockState = CursorLockMode.None;
		} else
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		// Everything below this isn't mine anymore.
		
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
		
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
    }
}
