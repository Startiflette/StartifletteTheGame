using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour {

    private bool flash = true;
    private Image image;

    public void Start() {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        if (flash) {
            image.color = new Color(255f, 255f, 255f, image.color.a - Time.deltaTime * 4);
            Debug.Log(image.color);
            if (image.color.a <= 0) {
                image.color = new Color(255f, 255f, 255f, 0);
                flash = false;
            }
        } else {
            Debug.Log(image.color);
            image.color = new Color(255f, 255f, 255f, image.color.a + Time.deltaTime * 4);
            if (image.color.a >= 1) {
                image.color = new Color(255f, 255f, 255f, 0.25f);
                flash = true;
            }
        }
    }
}
