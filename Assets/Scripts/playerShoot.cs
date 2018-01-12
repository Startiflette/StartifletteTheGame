using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

	private Camera camera;
	private GameObject pointer;


	// Use this for initialization
	void Start () {
	
		pointer = GameObject.FindGameObjectWithTag ("Pointeur");
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Input.GetButtonDown("Fire1")){
			Ray ray = camera.ScreenPointToRay(pointer.transform.position);
			Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);
			if(Physics.Raycast(ray,out hit,7f)) {
				Debug.Log (hit.collider.gameObject.name + " was killed");
				Object.Destroy (hit.collider.gameObject);
			}

		}
	}
		
}
