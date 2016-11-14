using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public float fadeSpeed;
	public float duration = 0.0f;

	private bool start = true;
	private int drawDepth = -1000;
	private float alpha = 0.0f;
	private int fadeDir = 1;
	private bool fadein = false;

	void Update(){
	}

	/*public void FadeFunction(float duration,int direction){
		StartCoroutine ();
	}*/

	public IEnumerator Fade(int direction){

		Renderer rend = GetComponent<Renderer> ();
		Color color = rend.material.color;

		fadeDir = direction;

		if(fadeDir == 1)
		while (alpha <= 0.99f) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);

			color.a = alpha;
			rend.material.color = color;
			//Debug.Log (alpha);

			yield return null;
		}

		//yield return new WaitForSeconds (duration);

		if(fadeDir == -1)
		while (alpha >= 0.01f) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);

			color.a = alpha;
			rend.material.color = color;
			//Debug.Log (alpha);

			yield return null;
		}

		//start = false;
	}
}