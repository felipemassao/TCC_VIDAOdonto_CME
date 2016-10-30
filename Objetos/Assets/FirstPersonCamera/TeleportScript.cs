using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

	public GameObject teleportObject;
	GameObject character;

	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray cameraCenterRay = new Ray(transform.position, transform.forward);
		Vector3 constant = new Vector3(100,20,20);

		/*if(!(hit.Equals(null)))
			if (hit.collider.tag == "Teleport")
				Debug.Log ("Colidiu");*/

		if (Input.GetButtonDown ("Fire1")) {
			if(Physics.Raycast(cameraCenterRay, out hit, 100)){
				Debug.Log ("Hit something");
				if (hit.collider.tag == "Teleport") {
					character.transform.position = hit.transform.position;
					Debug.Log ("Hit something with Teleport");
				}
			}
		}
	}
}