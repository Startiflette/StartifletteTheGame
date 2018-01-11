using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
	public Transform[] waypoints;
	public float speed = 5f;
	private int curWaypoint = 0;
	private bool doPatrol = true;
	private Vector3 target;
	private Vector3 moveDirection;
	private Vector3 velocity;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (curWaypoint < waypoints.Length) {
			target = waypoints [curWaypoint].position;
			moveDirection = target - transform.position;
			velocity = rb.velocity;

			if (moveDirection.magnitude < 1) {
				curWaypoint++;
			} else {
				velocity = moveDirection.normalized * speed;
			}
		} else {
			if (doPatrol) {
				curWaypoint = 0;
			} else {
				velocity = new Vector3 ();
			}
		}

		rb.velocity = velocity;
		transform.LookAt (target);
	}
}
