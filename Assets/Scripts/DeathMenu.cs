using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
	public static bool YouAreDead = false;

	public GameObject deathMenuUI;

	// Update is called once per frame
	void Update()
	{
		if (HP.Death)
		{
			Die();
		}
	}

	public void Die()
	{
		deathMenuUI.SetActive(true);
		YouAreDead = true;
		Debug.Log("activatedeathmenu");
		HP.Death = false;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		YouAreDead = false;
		MainMenu.OnMainMenu = true;
		SceneManager.LoadScene("MainMenu");
	}
	public void QuitGame()
	{
		Debug.Log("Quitting game...");
		Application.Quit();
	}
}
