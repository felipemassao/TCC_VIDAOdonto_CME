using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.position + Vector3.forward*100, Color.red, 20, false);
	}
}
