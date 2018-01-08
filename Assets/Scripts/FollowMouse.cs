using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	public float smoothSpeed = 4f;

    public Vector3 plan;

	// Update is called once per frame
	void Update () {
		Vector3 desiredPos = Camera.main.GetComponent<Camera> ().ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 6f));
		Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPos;

        transform.LookAt(desiredPos + plan); 
	}
}
