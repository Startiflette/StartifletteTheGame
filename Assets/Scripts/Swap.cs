using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
	public GameObject gameControler;
    public GameObject[] shipList;
    public Camera mainCamera;

    private int compteur = 0;

	private bool isCoroutineReady;

    // Use this for initialization
    void Start()
    {
		shipList [compteur].SetActive (true);
		gameControler.GetComponent<EventsController>().activeBarEvent.Invoke (shipList [0].GetComponent<PlayerHealth> ().HealthSlider);
		shipList [1].SetActive (false);
		shipList [2].SetActive (false);
		isCoroutineReady = true;
    }

    // Update is called once per frame
    void Update()
	{
		
		if (isCoroutineReady) {
			bool onlyOneShip = isOneAliveShip ();
			Debug.Log (onlyOneShip);

			if (!onlyOneShip) {


				if (Input.GetButtonDown ("Switch droite")) {

					int firstNext = nextNumber (compteur + 1);
					int secondNext = nextNumber (compteur + 2);

					if (shipList [firstNext].GetComponent<PlayerHealth> ().IsAlive) {
						StartCoroutine(Fade (shipList [compteur], shipList [firstNext], "SUIVANT"));
					} else {
						StartCoroutine(Fade (shipList [compteur], shipList [secondNext], "SUIVANT"));
					}
				} else if (Input.GetButtonDown ("Switch gauche")) {

					int firstPrevious = previousNumber (compteur - 1);
					int secondPrevious = previousNumber (compteur - 2);
					if (shipList [firstPrevious].GetComponent<PlayerHealth> ().IsAlive) {
						StartCoroutine(Fade (shipList [compteur], shipList [firstPrevious], "PRECEDENT"));
					} else {
						StartCoroutine(Fade (shipList [compteur], shipList [secondPrevious], "PRECEDENT"));
					}
				}
			}
		}
	}
		
	IEnumerator Fade(GameObject actual, GameObject next, string action)
    {
        isCoroutineReady = false;

        float angle;
		int nextInt;
		if (action.Equals("SUIVANT"))
        {
            angle = -180f;
			if (compteur + 1 > 2) {
				nextInt = 0;
			} else {
				nextInt = (compteur + 1);
			}

        } else {
            angle = 180f;
			if (compteur - 1 < 0) {
				nextInt = 2;
			} else {
				nextInt = compteur - 1;
			}
        }

		Vector3 posIn = next.transform.position;
        Vector3 posAway = actual.transform.position;
		next.SetActive(!next.activeSelf);

        Vector3 origin = mainCamera.transform.position;
        Vector3 axis = new Vector3(0, 10f, 0);

        for (float itCompteur = 0f; itCompteur <= 7f; itCompteur += 0.1f)
        {
            Vector3 moveIn = new Vector3(posIn.x, posIn.y, posIn.z + itCompteur);
			next.transform.position = moveIn;

            actual.transform.RotateAround(origin, axis, angle*Time.deltaTime*2);
            //Debug.Log(moveIn);

            

            yield return null;
        }
        actual.SetActive(!actual.activeSelf);
        actual.transform.position = new Vector3(0, 0, -6);
        actual.transform.rotation = Quaternion.Euler(new Vector3(-90f, 0, 0));
        isCoroutineReady = true;

		gameControler.GetComponent<EventsController>().activeBarEvent.Invoke (next.GetComponent<PlayerHealth> ().HealthSlider);

    }

	int nextNumber (int number)
	{
		if (number == 3) {
			return 0;
		} else if(number == 4){
			return 1;
		} else {
			return number;
		}
	}

	int previousNumber (int number)
	{
		if (number == -1) {
			return 2;
		} else if(number == -2){
			return 1;
		} else {
			return number;
		}
	}

	bool isOneAliveShip(){
		int count = 0;

		foreach(GameObject ship in shipList){
			if (ship.GetComponent<PlayerHealth> ().IsAlive) {
				count++;
			}
		}

		if (count <= 1) {
			return true;
		} else {
			return false;
		}
	}
}