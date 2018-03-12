using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int maxLife = 100;                                   // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.

	bool isAlive = true;
	bool isActive = false;

	void Start ()
	{
		// Set the initial health of the player.
		currentHealth = maxLife;
		isAlive = true;
		healthSlider.minValue = 0;
		healthSlider.maxValue = maxLife;
	}


	void Update ()
	{
	}
		
	public void TakeDamage (int amount)
	{
		// Reduce the current health by the damage amount.
		currentHealth -= amount;

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if (currentHealth <= 0) {
			Death ();
			healthSlider.value = 0;
		} else {
			healthSlider.value = currentHealth;
		}
	}

	public void Heal (int amount)
	{
		currentHealth += amount;
		if(currentHealth > maxLife)
		{
			currentHealth = maxLife;
		}

		healthSlider.value = currentHealth;
	}

	public bool IsAlive {
		get {
			return isAlive;
		}
	}
		
	void Active ()
	{
		isActive = true;
	}

	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isAlive = false;

	}


	public Slider HealthSlider {
		get {
			return healthSlider;
		}
	}

	public bool IsActive {
		get {
			return isActive;
		}
	}
}
