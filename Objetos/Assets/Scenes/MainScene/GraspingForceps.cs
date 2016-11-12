using UnityEngine;
using System.Collections;

public class GraspingForceps : MonoBehaviour {

	public GameObject thumbFinger;
	public GameObject indexFinger;

	public GameObject part1;
	public GameObject part2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Input.GetKeyDown(KeyCode.P)){

			part1.transform.position = indexFinger.transform.position;
			part2.transform.position = thumbFinger.transform.position;
			part1.transform.parent = indexFinger.transform;
			part2.transform.parent = thumbFinger.transform;

		}

	}
}
