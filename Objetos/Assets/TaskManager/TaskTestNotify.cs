using UnityEngine;
using System.Collections;

public class TaskTestNotify : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			TaskList.instance.notify ("PutCap");
		}
	}
}