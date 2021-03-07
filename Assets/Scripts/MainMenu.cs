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
	OnMainMenu = false;
}
public void QuitGame ()
{
	Debug.Log("QUIT!");
	Application.Quit();
}

}
