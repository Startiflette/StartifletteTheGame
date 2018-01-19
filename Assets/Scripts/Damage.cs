using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int damage = 15;

	// Use this for initialization
	public int getDamage () {
        return damage;
    }

    // Use this for initialization
    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }
}
