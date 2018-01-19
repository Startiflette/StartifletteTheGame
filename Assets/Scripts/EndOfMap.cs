using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndOfMap : MonoBehaviour {
	public Button button;
	public GameObject gameManager;
	private Scene scene;
	// Use this for initialization
	void Start () {
		button.gameObject.SetActive (false);
		scene = gameManager.GetComponentInChildren<Scene> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			
			button.gameObject.SetActive (true);	
			Cursor.visible = true;

		}
	}
}
