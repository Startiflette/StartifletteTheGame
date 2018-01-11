using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Bullet") {
			Destroy (gameObject);
		}
	}
}
