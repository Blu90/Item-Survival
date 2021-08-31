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

	public void SetHunger(int hunger)
	{
		slider.value = hunger;
	}

	public void SetMaxOxygen(int oxygen)
	{
		slider.maxValue = oxygen;
		slider.value = oxygen;
	}

	public void SetOxygen(int oxygen)
	{
		slider.value = oxygen;
	}

	public void SetMaxSwim(int swim)
	{
		slider.maxValue = swim;
		slider.value = swim;
	}

	public void SetSwim(int swim)
	{
		slider.value = swim;
	}
}
