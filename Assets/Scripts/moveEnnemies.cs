using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnnemies : MonoBehaviour {

	public float speed = 5f;
	private Transform[] waypoints;
	private Transform[] children;
	private int curWaypoint = 0;
	public bool doLoop = false;
	private Vector3 target;
	private Vector3 moveDirection;
	private Vector3 velocity;
	private Rigidbody ennemyRb;
	private Transform ennemyTransform;
	public GameObject ennemy;
	private bool goBack = false;

	void Start(){
		
		children = this.GetComponentsInChildren<Transform>();
		waypoints = new Transform[children.Length-1];
		int i = 0;
		foreach (Transform child in children) {
			if (child.tag.Equals("patternWayPoint")) {
				waypoints[i] = child;
				Debug.Log (child.GetType());
					i++;
			}

		}
		Debug.Log (waypoints [0].position.x);
		ennemyRb = ennemy.GetComponent<Rigidbody> ();
		ennemyTransform = ennemy.GetComponent<Transform> ();





	}

	// Update is called once per frame
	void Update () {
		if (ennemy == null) {
			this.enabled = false;
			return;
		}
		if (curWaypoint < waypoints.Length && curWaypoint >= 0) {
			target = waypoints[curWaypoint].position;
			moveDirection = target - ennemyTransform.position;
			velocity = ennemyRb.velocity;
	
			if (moveDirection.magnitude <= 0.1f) {
				if (!goBack) {
					curWaypoint++;
				} else {
					curWaypoint--;
				}

			} else {
				velocity = moveDirection.normalized * speed;
			}
		} else {
			if (doLoop) {
				curWaypoint = 0;

			} else if (curWaypoint <0) {
				curWaypoint++;
				goBack = false;
			}else{
				curWaypoint--;
				goBack = true;

			}
		}

		ennemyRb.velocity = velocity;
		ennemyTransform.LookAt (target);
	}

}
