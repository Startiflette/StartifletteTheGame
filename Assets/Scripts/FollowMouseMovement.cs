using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseMovement : MonoBehaviour {

	public float speed = 30.0F;
	float yMinLimit = -Screen.height / 2;
	float yMaxLimit = Screen.height / 2;
	float xMinLimit = - Screen.width / 2;
	float xMaxLimit = Screen.width / 2;

	// Use this for initialization
	void Start () {
		Debug.Log ("y max =" + yMaxLimit);
		Debug.Log ("x max =" + xMaxLimit);
		float initialX = 0;
		float initialY = 0;
		transform.position = new Vector3(initialX, initialY, 700);
	}
	
	// Update is called once per frame
	void Update () {

		float origineX = transform.position.x;
		float origineY = transform.position.y;
		float translationX = Input.GetAxis ("Mouse X");
		float translationY = Input.GetAxis("Mouse Y");

		float translationFinalX = origineX + translationX * Time.deltaTime*speed;
		translationFinalX = checkXlimit (translationFinalX);

		float translationFinalY = origineY + translationY * Time.deltaTime*speed;
		translationFinalY = checkYlimit (translationFinalY);

		transform.position = new Vector3(translationFinalX, translationFinalY, 700);
	}

	private float checkXlimit(float position){
		return checklimit (position, xMinLimit, xMaxLimit); 
	}

	private float checkYlimit(float position){
		return checklimit (position, yMinLimit, yMaxLimit);   
	}

	private float checklimit(float position, float lowLimit, float maxlimit){
		if (position < lowLimit) {
			return lowLimit;
		} else if (position > maxlimit) {
			return maxlimit;
		}  else {
			return position;
		}
	}
}
