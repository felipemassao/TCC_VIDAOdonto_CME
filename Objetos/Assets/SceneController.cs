using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	public GameObject TaskList;

	void Awake () {

		if (TaskList == null)
			Instantiate (TaskList);
		
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("MainScene", LoadSceneMode.Single);
		}
	}
}
