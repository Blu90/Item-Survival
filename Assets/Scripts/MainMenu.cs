using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

public static bool OnMainMenu = true;

public void PlayGame ()
{
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	// The lines below is for development purposes. It serves no purpose in game.
	OnMainMenu = false;
	DeathMenu.YouAreDead = false;
}
public void QuitGame ()
{
	Debug.Log("QUIT!");
	Application.Quit();
}

}
