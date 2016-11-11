using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	public static SceneController instance = null;
	public string actualScene;
	public string gender = "female";

	void Awake () {

		if (instance == null) //Check if instance already exists
			instance = this; //If not, set instance to this
		else if (instance != this) //If already exist and it is not this
			Destroy (gameObject); //Then destroy this, enforcing the Singleton Pattern

		DontDestroyOnLoad (gameObject);
		
	}

	void Update () {

		//Reset the main scene
		if (Input.GetKeyDown (KeyCode.R) && actualScene == "MainScene") {
			SceneManager.LoadScene ("MainScene", LoadSceneMode.Single);
		}

	}


}
