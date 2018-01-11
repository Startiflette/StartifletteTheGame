using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseMovement : MonoBehaviour {

	public float speed = 30.0F;
	public Canvas canvas;
	Transform[] imageTransform;

	float yMinLimit = -Screen.height / 2;
	float yMaxLimit = Screen.height / 2;
	float xMinLimit = - Screen.width / 2;
	float xMaxLimit = Screen.width / 2;
	float distance;
	// Use this for initialization
	void Start () {
		
		distance = Screen.height * 0.5f / Mathf.Tan (60 * 0.5f * Mathf.Deg2Rad);
		float initialX = 0;
		float initialY = 0;
		imageTransform = canvas.GetComponentsInChildren<RectTransform> ();

		imageTransform[1].position = new Vector3(initialX, initialY, distance);
	}
	
	// Update is called once per frame
	void Update () {

		float origineX = imageTransform[1].position.x;
		float origineY = imageTransform[1].position.y;
		float translationX = Input.GetAxis ("Vertical");
		float translationY = Input.GetAxis("Horizontal");

		float translationFinalX = origineX + translationX * Time.deltaTime*speed;
		translationFinalX = checkXlimit (translationFinalX);

		float translationFinalY = origineY + translationY * Time.deltaTime*speed;
		translationFinalY = checkYlimit (translationFinalY);

		imageTransform[1].position = new Vector3(translationFinalX, translationFinalY, distance);
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
