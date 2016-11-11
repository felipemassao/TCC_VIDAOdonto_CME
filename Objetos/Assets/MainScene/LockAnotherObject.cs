using UnityEngine;
using System.Collections;

public class LockAnotherObject : MonoBehaviour {

	bool locked;
	GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (locked)
			obj.transform.parent = transform;
		else
			obj.transform.parent = null;

		if (Input.GetKeyUp (KeyCode.C)) {
			locked = false;
		}
	}

	void OnTriggerStay( Collider other ){
		if (Input.GetKeyDown (KeyCode.C)) {
			locked = true;
			obj = other.gameObject;
		}
	}
}
