using UnityEngine;
using System.Collections;

public class CrosshairDraw : MonoBehaviour {

	public Texture2D crosshairImage;
	public float size;
	// Use this for initialization

	void OnGUI(){
		float xMin = (Screen.width / 2) - (crosshairImage.width / (2 * size));
		float yMin = (Screen.height / 2) - (crosshairImage.height / (2 * size));

		GUI.DrawTexture (new Rect (xMin, yMin, crosshairImage.width/size, crosshairImage.height/size), crosshairImage);
	}
}