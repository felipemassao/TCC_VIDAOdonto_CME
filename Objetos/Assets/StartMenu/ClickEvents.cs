using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickEvents : MonoBehaviour {

	public GameObject actualScreen;

	public void LoadScene(int level){
		
		SceneController.instance.actualScene = "MainScene";
		SceneManager.LoadScene (level);

	}

	public void GoToScreen(GameObject nextScreen){

		actualScreen.SetActive (false);
		nextScreen.SetActive (true);

		actualScreen = nextScreen;
	}

	public void SetGender(string gender){

		Debug.Log (gender);
		SceneController.instance.gender = gender;

	}

}
