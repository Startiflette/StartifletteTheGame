using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {
	public float speed;
	private bool started = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			started = true;
		}
		if (started) {
			
			transform.Translate (new Vector3 (0, 0, speed));
		}
	
	}

}
