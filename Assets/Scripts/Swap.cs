using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{

    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    public Camera mainCamera;

    private GameObject shipMain;
    private GameObject shipLeft;
    private GameObject shipRight;

    private bool isCoroutineReady = true;

    // Use this for initialization
    void Start()
    {
        ship1.SetActive(true);
        ship2.SetActive(false);
        ship3.SetActive(false);

        shipMain = ship1;
        shipLeft = ship2;
        shipRight = ship3;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoroutineReady)
        {
            //swap Right
            if (Input.GetKeyDown("e"))
            {
                IEnumerator coroutine = Fade(shipMain, shipRight, false);

                StartCoroutine(coroutine);
                //  Swapping(ship2);

            }

            //swap left
            if (Input.GetKeyDown("a"))
            {
                IEnumerator coroutine = Fade(shipMain, shipLeft, true);

                StartCoroutine(coroutine);
            }
        }
    }

    void Swapping(GameObject ship)
    {
        if (ship.activeSelf)
        {
            Vector3 backTheFuckUp = new Vector3(0, 0, -7f);
            transform.position = backTheFuckUp;
            ship.SetActive(false);

        }
        else
        {
            ship.SetActive(true);
            Vector3 backTheFuckUp = new Vector3(-5, 10, 7f);
            transform.position = backTheFuckUp;
        }
    }
    IEnumerator Fade(GameObject goingAway, GameObject goingIn, bool isSwapLeft)
    {
        isCoroutineReady = false;
        goingAway.transform.Find("Capsule").gameObject.SetActive(false);
        goingIn.transform.Find("Capsule").gameObject.SetActive(true);

        float angle;
        shipMain = goingIn;
        if (isSwapLeft)
        {
            shipLeft = goingAway;
            angle = -180f;
        }
        else
        {
            shipRight = goingAway;
            angle = 180f;
        }
        Vector3 posIn = goingIn.transform.position;
        Vector3 posAway = goingAway.transform.position;
        goingIn.SetActive(!goingIn.activeSelf);

        Vector3 origin = mainCamera.transform.position;
        Vector3 axis = new Vector3(0, 10f, 0);

        for (float itCompteur = 0f; itCompteur <= 7f; itCompteur += 0.1f)
        {
            Vector3 moveIn = new Vector3(posIn.x, posIn.y, posIn.z + itCompteur);
            goingIn.transform.position = moveIn;

            //Vector3 moveAway = new Vector3(posAway.x, posAway.y, posAway.z - itCompteur
            Debug.Log("origine : " + origin.ToString());

            goingAway.transform.RotateAround(origin, axis, angle*Time.deltaTime*2);
            //Debug.Log(moveIn);

            

            yield return null;
        }
        goingAway.SetActive(!goingAway.activeSelf);
        goingAway.transform.position = new Vector3(0, 0, -6);
        isCoroutineReady = true;
        

    }
}
