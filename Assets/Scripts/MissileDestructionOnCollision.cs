using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDestructionOnCollision : MonoBehaviour {
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("ship"))
        {
            int damage = gameObject.GetComponent<Damage>().getDamage();
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
