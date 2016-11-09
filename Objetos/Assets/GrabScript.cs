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
	bool grab;

	void Start () {
		controller = new Controller ();
	}

	void Update () {
		frame = controller.Frame ();

		if (grab) {
			this.GetComponent<Rigidbody> ().isKinematic = true;
			transform.parent = logicHand.transform;
		} else {
			this.GetComponent<Rigidbody> ().isKinematic = false;
			transform.parent = null;
			}

		if (hand.GrabStrength <= 0.1f)
			grab = false;

		if (Input.GetKeyDown (KeyCode.G)) {
			this.GetComponent<Rigidbody> ().isKinematic = true;
			transform.position = logicHand.transform.position;
			transform.parent = logicHand.transform;
		}

		//Debug.Log (hand.GrabStrength);
	}

	void OnCollisionStay(){

		List<Hand> hands = frame.Hands;
		hand = hands [0];

		if (hand.GrabStrength >= 0.9f) 
			grab = true;
			//transform.parent = hand.Basis;
			
	}
}
