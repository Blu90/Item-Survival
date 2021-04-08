using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	
public Slider slider;

public void SetMaxHealth(int health)
{
	slider.maxValue = health;
	slider.value = health;
}

   public void SetHealth(int health)
   {
	   slider.value = health;
   }

	public void SetMaxHunger(int hunger)
	{
		slider.maxValue = hunger;
		slider.value = hunger;
	}

	public int hunger = 100;

	public void SetHunger(int hunger)
	{
		slider.value = hunger;
	}

	void Start()
    {
        InvokeRepeating("Hungry", 0f, 30f);
    }

    void Hungry()
    {
        hunger += -1;
		Debug.Log("hunger subtracted");
    }
}
