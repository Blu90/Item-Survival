using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
	
	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public int maxHunger = 100;
	public int currentHunger;
	public HealthBar hungerBar;
	public static bool Death = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		currentHunger = maxHunger;
		healthBar.SetMaxHealth(maxHealth);
		hungerBar.SetMaxHunger(maxHunger);
		InvokeRepeating("Hungry", 6f, 6f);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.K))
		{
			TakeDamage(100);
		}
        if (currentHealth < 1)
        {
			currentHealth = 100;
			Death = true;
			Debug.Log("dead");
        }
    }
	
	void TakeDamage(int damage)
	{
	currentHealth -= damage;
	healthBar.SetHealth(currentHealth);
	}


	void Hungry()
	{
		if(currentHunger > 1)
		{
			TakeHunger(1);
			Debug.Log("hunger subtracted");
			hungerBar.SetHunger(currentHunger);
		} else
        {
			TakeDamage(1);
			Debug.Log("health subtracted");
        }
	}

	void TakeHunger(int hungerTaken)
	{
		currentHunger -= hungerTaken;
		hungerBar.SetHunger(currentHunger);
	}
}
