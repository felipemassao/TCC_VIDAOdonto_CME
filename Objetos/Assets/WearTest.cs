using UnityEngine;
using System.Collections;

public class WearTest : MonoBehaviour {

	public GameObject clothes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.V))
				clothes.SetActive (!clothes.activeSelf);
	}
}