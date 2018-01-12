using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseMovement : MonoBehaviour {

	public float speed = 30.0F;
	GameObject[] pointeurListe;
	GameObject pointeur;

	float yMinLimit = 0;
	float yMaxLimit = Screen.height;
	float xMinLimit = 0;
	float xMaxLimit = Screen.width;

	// Use this for initialization
	void Start () {
		

		float initialX = Screen.width/2;
		float initialY = Screen.height/2;
		pointeurListe = GameObject.FindGameObjectsWithTag ("Pointeur");
		pointeur = pointeurListe [0];
		pointeur.transform.position = new Vector3(initialX, initialY, 0);
		Debug.Log (initialX);
	}
	
	// Update is called once per frame
	void Update () {

		float origineX = pointeur.transform.position.x;
		float origineY = pointeur.transform.position.y;
		float translationX = Input.GetAxis ("Horizontal");
		float translationY = Input.GetAxis("Vertical");

		float translationFinalX = origineX + translationX * Time.deltaTime*speed;
		translationFinalX = checklimit (translationFinalX, xMinLimit, xMaxLimit);

		float translationFinalY = origineY + translationY * Time.deltaTime*speed;
		translationFinalY =checklimit (translationFinalY, yMinLimit, yMaxLimit); 

		pointeur.transform.position = new Vector3(translationFinalX, translationFinalY, 0f);
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
