using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsController : MonoBehaviour {

	private ActiveBarEvent activeBarEvent;
	private SwapEvent swapEvent;

	void Awake(){
		activeBarEvent = new ActiveBarEvent ();
		swapEvent = new SwapEvent ();
	}
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public ActiveBarEvent ActiveBarEvent {
		get {
			return activeBarEvent;
		}
	}

	public SwapEvent SwapEvent {
		get {
			return swapEvent;
		}
	}
}
