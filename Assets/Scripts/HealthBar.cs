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
   
}

public class HungerBar : MonoBehaviour
{

	public Slider slider;

	public void SetMaxHunger(int hunger)
	{
		slider.maxValue = hunger;
		slider.value = hunger;
	}

	public void SetHunger(int hunger)
	{
		slider.value = hunger;
	}

}
