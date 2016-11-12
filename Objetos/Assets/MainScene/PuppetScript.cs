using UnityEngine;
using System.Collections;

public class PuppetScript : MonoBehaviour {

	//Leap Parts
	public GameObject leapHand;
	public GameObject leapArm;

	//Avatar Parts
	public GameObject avatarHand;
	public GameObject avatarArm;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {

		//Position
		//avatarHand.transform.localPosition = leapHand.transform.localPosition;
		avatarArm.transform.localPosition = leapArm.transform.localPosition + new Vector3(0.0f,0.0f, 0.8f);

		//Rotation
		//avatarHand.transform.localRotation = leapHand.transform.localRotation;
		avatarArm.transform.localRotation = leapArm.transform.localRotation;

	}
}
