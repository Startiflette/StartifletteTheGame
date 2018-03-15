using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
	public GameObject gameControler;
    public GameObject[] shipList;
    public Camera mainCamera;

	private int shipActive = 0;
	private int shipsAlive = 3;
	private bool gameOver = false;

	private bool isCoroutineReady;

    // Use this for initialization
    void Start()
    {
		shipList [shipActive].SetActive (true);
		gameControler.GetComponent<EventsController>().ActiveBarEvent.Invoke (shipList [0].GetComponent<PlayerHealth> ().HealthSlider);
		gameControler.GetComponent<EventsController>().SwapEvent.AddListener (SwapShips);
		shipList [1].SetActive (false);
		shipList [2].SetActive (false);
		isCoroutineReady = true;
    }

    // Update is called once per frame
    void Update()
	{
		if (!gameOver) {
			if (Input.GetButtonDown ("Switch droite")) {
				SwapShips ("SUIVANT");
			} else if (Input.GetButtonDown ("Switch gauche")) {
				SwapShips ("PRECEDENT");
			}
		}
	}

	private void SwapShips (string action) {

		if (isCoroutineReady) {

			if (shipsAlive > 1) {

				if ("SUIVANT".Equals (action) || "DEATH".Equals (action)) {

					if ("DEATH".Equals (action)) {
						shipsAlive--;
						Debug.Log (shipsAlive);
						if (shipsAlive == 0) {
							gameOver = true;
						}
					}

					int firstNext = nextNumber (shipActive + 1);
					int secondNext = nextNumber (shipActive + 2);

					if (shipList [firstNext].GetComponent<PlayerHealth> ().IsAlive) {
						StartCoroutine (SwapShipsCoroutine (shipList [shipActive], shipList [firstNext], "SUIVANT"));
						shipActive = firstNext;
					} else {
						StartCoroutine (SwapShipsCoroutine (shipList [shipActive], shipList [secondNext], "SUIVANT"));
						shipActive = secondNext;
					}
				} else if ("PRECEDENT".Equals (action)) {

					int firstPrevious = previousNumber (shipActive - 1);
					int secondPrevious = previousNumber (shipActive - 2);
					if (shipList [firstPrevious].GetComponent<PlayerHealth> ().IsAlive) {
						StartCoroutine (SwapShipsCoroutine (shipList [shipActive], shipList [firstPrevious], "PRECEDENT"));
						shipActive = firstPrevious;
					} else {
						StartCoroutine (SwapShipsCoroutine (shipList [shipActive], shipList [secondPrevious], "PRECEDENT"));
						shipActive = secondPrevious;
					}
				}
			} else if (shipsAlive == 0) {
				Debug.Log ("Game Over");
			}
		}
	}

	IEnumerator SwapShipsCoroutine(GameObject actual, GameObject next, string action)
    {
        isCoroutineReady = false;

		actual.GetComponent<FollowPointer> ().enabled = false;
		actual.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		next.SetActive(true);

        float angle;

		if (action.Equals("SUIVANT"))
        {
            angle = 90f;
        } else {
            angle = -90f;
        }

		Vector3 standByPosition = new Vector3(actual.transform.position.x,actual.transform.position.y,-15);
		Vector3 attackPosition = actual.transform.position;



        Vector3 origin = mainCamera.transform.position;
        Vector3 axis = new Vector3(0, 1f, 0);

        for (float itCompteur = 0f; itCompteur <= 7f; itCompteur += 1f)
        {
			
			Vector3 moveToAttack = new Vector3(standByPosition.x, standByPosition.y, standByPosition.z + 2);
			next.transform.position = moveToAttack;

            actual.transform.RotateAround(origin, axis, angle*Time.deltaTime*6);
			yield return new WaitForEndOfFrame();
        }

        
        
		next.GetComponent<FollowPointer> ().enabled = true;

		isCoroutineReady = true;

		actual.SetActive (false);
		actual.transform.position = standByPosition;
		actual.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

		next.GetComponent<FollowPointer> ().enabled = true;
		gameControler.GetComponent<EventsController>().ActiveBarEvent.Invoke (next.GetComponent<PlayerHealth> ().HealthSlider);

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
}