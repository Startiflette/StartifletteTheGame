using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StateHealthBar : MonoBehaviour {

	public StateBarList.stateList stateHealthBar;
	public Image icone;


	
	void Update () {
		IconeUpdate ();
		BarUpdate ();
	}

	public void ChangeState(StateBarList.stateList etat){
		stateHealthBar = etat;
	}
		
	private void IconeUpdate(){
		switch (stateHealthBar) {
		case StateBarList.stateList.ENABLE:
			icone.color = Color.white;
				break;
		case StateBarList.stateList.DISABLE:
			icone.color = Color.black;
				break;
		case StateBarList.stateList.DEATH:
			icone.color = Color.red;
				break;
		} 
	}

	private void BarUpdate(){

		RectTransform rect = GetComponent<RectTransform> ();

		switch (stateHealthBar) {
		case StateBarList.stateList.ENABLE:
			expanseBar (rect);
				break;
		case StateBarList.stateList.DISABLE:
			reduceBar (rect);
			break;
		case StateBarList.stateList.DEATH:
			reduceBar (rect);
			break;
		} 
	}

	private void reduceBar(RectTransform rect ){
		rect.localScale = new Vector3 (0.5f, 0.5f, 1f);
	}

	private void expanseBar(RectTransform rect ){
		rect.localScale = new Vector3 (1f, 1f, 1f);
	}

}
