using UnityEngine;
using System.Collections;

public class SwitchCameras : MonoBehaviour {

	public GameObject cam1;
	public GameObject cam2;
	// Use this for initialization
	void Start () {
		cam1.SetActive(true);
		cam2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) {
			cam1.SetActive(!cam1.activeSelf);
			cam2.SetActive(!cam2.activeSelf);
		}

		if (Input.GetKeyDown (KeyCode.S)) {

		}
	}
}