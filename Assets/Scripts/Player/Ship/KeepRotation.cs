using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour {

	private GameObject player;
    public GameObject playerShip;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (playerShip.GetComponent<PlayerHealth> ().IsActive) {
			transform.position = new Vector3 (playerShip.transform.position.x, playerShip.transform.position.y - 1, playerShip.transform.position.z);
		} else {
			transform.position = new Vector3 (0, 0, -15);
		}
    }
}
