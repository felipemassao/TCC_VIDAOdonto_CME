using UnityEngine;
using System.Collections;

public class InputKeys : MonoBehaviour {

	//Fade Effect
	public float DurationOfFade = 1f; 

	//Switch Camera
	public GameObject camera_aluno;
	public GameObject camera_professor;
	public GameObject fade_cube_aluno;
	public GameObject fade_cube_professor;

	//pauseHands
	public GameObject leap_hands;

	void Start () {

		//Switch Camera
		camera_aluno.SetActive(true);
		camera_professor.SetActive(false);

		leap_hands.SetActive (true);
	}
		
	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) {
			StartCoroutine(switchCamera ());
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			pauseHands ();
		}
	}

	IEnumerator switchCamera(){

		StartCoroutine (fade_cube_aluno.GetComponent<Fading>().Fade(1));
		StartCoroutine (fade_cube_professor.GetComponent<Fading>().Fade(1));

		yield return new WaitForSeconds (DurationOfFade);

		camera_aluno.SetActive (!camera_aluno.activeSelf);
		camera_professor.SetActive (!camera_professor.activeSelf);

		StartCoroutine (fade_cube_aluno.GetComponent<Fading>().Fade(-1));
		StartCoroutine (fade_cube_professor.GetComponent<Fading>().Fade(-1));

		yield return null;
	}

	private void pauseHands(){
		leap_hands.SetActive (!leap_hands.activeSelf);
	}
}
