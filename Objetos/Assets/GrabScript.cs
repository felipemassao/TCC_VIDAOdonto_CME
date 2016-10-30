using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using LeapInternal;

public class GrabScript : MonoBehaviour {

	Controller controller;
	Frame frame;
	Hand hand;
	public GameObject logicHand;

	void Start () {
		controller = new Controller ();
	}

	void Update () {
		frame = controller.Frame ();
	}

	void OnTriggerStay(){

		List<Hand> hands = frame.Hands;
		hand = hands [0];

		if (hand.GrabStrength >= 0.9) {
				//transform.parent = hand.Basis;
		}
			
	}
}
