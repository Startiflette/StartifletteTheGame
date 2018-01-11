using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	// the speed of the ship
	public float speed = 5f;

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
	}
}
