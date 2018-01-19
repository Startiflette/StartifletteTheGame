using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateHealthBar : MonoBehaviour {

	public stateList stateHealthBar;
	public Image icone;

	public enum stateList { ENABLE,DISABLE,DEATH };
	
	void Update () {
		IconeUpdate ();
		BarUpdate ();
	}

	public void ChangeState(string state){
	}
		
	private void IconeUpdate(){
		switch (stateHealthBar) {
			case stateList.ENABLE:
			icone.color = Color.white;
				break;
			case stateList.DISABLE:
			icone.color = Color.black;
				break;
			case stateList.DEATH:
			icone.color = Color.red;
				break;
		} 
	}

	private void BarUpdate(){

		RectTransform rect = GetComponent<RectTransform> ();

		switch (stateHealthBar) {
		case stateList.ENABLE:
			expanseBar (rect);
				break;
		case stateList.DISABLE:
			reduceBar (rect);
			break;
		case stateList.DEATH:
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
