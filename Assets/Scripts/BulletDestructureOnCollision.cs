using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestructureOnCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("J'ai touché un missile");
		if (col.gameObject.tag.Equals("rocket"))
		{
			Destroy (col.gameObject);
		}
		Destroy(gameObject);
	}
}
