using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;

	void takedamage (int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			print ("Dead");
		}
	}
}