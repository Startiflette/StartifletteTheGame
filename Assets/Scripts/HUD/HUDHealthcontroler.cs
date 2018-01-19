using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthcontroler : MonoBehaviour {

	public Slider[] healthBarList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0;i < healthBarList.Length;i++){
			Slider healtBar = healthBarList [i];
			changeBarColor (healtBar);
		}

		
	}

	public void changeState(Slider healthbar){
	}

	private void changeBarColor(Slider healthBar){

		Image healthBarImage = healthBar.fillRect.GetComponent<Image> ();
		Color green = new Color (0f, 255f, 0f,255f);
		Color orange = new Color (255f, 140f, 0f,255f);
		Color red = new Color (255f, 0f, 0f,255f);

		if (healthBar.value > healthBar.maxValue * 0.66) {
			setColor (healthBarImage, Color.green);
		} else if (healthBar.value > healthBar.maxValue * 0.3) {
			setColor (healthBarImage, orange);
		} else {
			setColor (healthBarImage, Color.red);
		}
	}

	private void setColor(Image healBarImage, Color color){
		healBarImage.color = color;
	}
}
