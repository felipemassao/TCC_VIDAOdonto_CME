using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using LeapInternal;

public class ChangeColorTrigger : MonoBehaviour {

	Controller controller;
	Frame frame;
	Hand hand;

	Material material;
	Renderer rend;
	Color color = new Color (1.0f, 1.0f, 1.0f, 1.0f);

	// Use this for initialization
	void Start () {
		//material = this.GetComponent<Material> ();
		//hand = (handObject.GetComponentsInChildren<Hand> ())[0];

		rend = GetComponent<Renderer> ();
		rend.material.color = Color.white;

		controller = new Controller ();


	}
	
	// Update is called once per frame
	void Update () {

		frame = controller.Frame ();

		//Debug.Log (controller.ToString());
		//Debug.Log (frame.Hands.Count);

		if (frame.Hands.Count > 0) {

			List<Hand> hands = frame.Hands;
			hand = hands [0];

			if (Input.GetKey (KeyCode.M))
				rend.material.color = Color.blue;

			//if (hand.GrabAngle >= 2.9)
			//	rend.material.color = Color.blue;
		}

	}

	void OnTriggerStay(){
		
		List<Hand> hands = frame.Hands;
		hand = hands [0];

		if(hand.GrabStrength >= 0.9)
			rend.material.color = Color.blue;
		else
			rend.material.color = Color.red;
	}
}