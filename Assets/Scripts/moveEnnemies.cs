using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnnemies : MonoBehaviour {

	public float speed = 5f;
	private Transform[] waypoints;
	private Transform[] children;
    private int[] curWaypoints;
	public bool doLoop = false;
	private Vector3 target;
	private Vector3 moveDirection;
	private Vector3 velocity;

	private Rigidbody ennemyRb;
	private Transform ennemyTransform;

    private Rigidbody[] rbTab;
    private Transform[] transformTab;

    public GameObject ennemy;
    private GameObject ennemyToSpawn;
    private bool goBack = false;

    public int numberOfEnnemies;
    private int currentNumberOfEnnemies;

    private bool isSpawned = false;


    void Start(){
        
        children = this.GetComponentsInChildren<Transform>();
		waypoints = new Transform[children.Length-1];

        rbTab = new Rigidbody[numberOfEnnemies];
        transformTab = new Transform[numberOfEnnemies];
        curWaypoints = new int[numberOfEnnemies];

        int i = 0;
		foreach (Transform child in children) {
			if (child.tag.Equals("patternWayPoint")) {
				waypoints[i] = child;
					i++;
			}

		}
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update () {

        if (numberOfEnnemies == 0)
        {
            this.enabled = false;
            return;
        }

        for (int cpt = 0; cpt <= currentNumberOfEnnemies - 1; cpt++)
        {
            if (curWaypoints[cpt] < waypoints.Length && curWaypoints[cpt] >= 0)
            {
                ennemyTransform = transformTab[cpt];
                ennemyRb = rbTab[cpt];

                target = waypoints[curWaypoints[cpt]].position;
                moveDirection = target - ennemyTransform.position;
                velocity = ennemyRb.velocity;

                if (moveDirection.magnitude <= 0.1f)
                {
                    if (!goBack)
                    {
                        curWaypoints[cpt]++;
                    }
                    else
                    {
                        curWaypoints[cpt]--;
                    }

                }
                else
                {
                    velocity = moveDirection.normalized * speed;
                }
            }
            else
            {
                if (doLoop)
                {
                    curWaypoints[cpt] = 0;

                }
                else if (curWaypoints[cpt] < 0)
                {
                    curWaypoints[cpt]++;
                    goBack = false;
                }
                else
                {
                    curWaypoints[cpt]--;
                    goBack = true;

                }
            }

            ennemyRb.velocity = velocity;
            ennemyTransform.LookAt(target);
        }

	}
    
    IEnumerator Spawn()
    {
        if (isSpawned)
        {
            yield return null;
        }
        for (currentNumberOfEnnemies = 0; currentNumberOfEnnemies <= numberOfEnnemies - 1; currentNumberOfEnnemies++)
        {
            ennemyToSpawn = Instantiate(ennemy, waypoints[0].position + new Vector3(0, 10f, 0), waypoints[0].rotation) as GameObject;

            rbTab[currentNumberOfEnnemies] = ennemyToSpawn.GetComponent<Rigidbody>();
            transformTab[currentNumberOfEnnemies] = ennemyToSpawn.GetComponent<Transform>();
            curWaypoints[currentNumberOfEnnemies] = 0;

            yield return new WaitForSeconds(2);
        }
        isSpawned = true;
    }
}
