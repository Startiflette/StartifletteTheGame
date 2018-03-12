using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour {

    public GameObject playerShip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerShip.transform.position + new Vector3(0,-1,0);
        transform.rotation = Quaternion.identity;
    }
}
