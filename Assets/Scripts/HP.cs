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
	public int maxOxygen = 100;
	public int currentOxygen;
	public HealthBar oxygenBar;
	public int maxSwim = 100;
	public int currentSwim;
	public HealthBar swimBar;
	public static bool isSwimming = false;
	public static bool Death = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		currentHunger = maxHunger;
		currentOxygen = maxOxygen;
		currentSwim = maxSwim;
		healthBar.SetMaxHealth(maxHealth);
		hungerBar.SetMaxHunger(maxHunger);
		oxygenBar.SetMaxOxygen(maxOxygen);
		swimBar.SetMaxSwim(maxSwim);
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

	void TakeOxygen(int oxygenTaken)
    {
		currentOxygen -= oxygenTaken;
		oxygenBar.SetOxygen(currentOxygen);
    }

	void TakeSwim(int swimTaken)
	{
		currentSwim -= swimTaken;
		swimBar.SetSwim(currentSwim);
	}

	void TakeHunger(int hungerTaken)
	{
		currentHunger -= hungerTaken;
		hungerBar.SetHunger(currentHunger);
	}
}
