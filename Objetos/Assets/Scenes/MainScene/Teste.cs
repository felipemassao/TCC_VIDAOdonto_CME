using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {

	public GameObject other;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q))
			transform.parent = other.transform;
	}
}
