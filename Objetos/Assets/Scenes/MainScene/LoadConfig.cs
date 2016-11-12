using UnityEngine;
using System.Collections;

public class LoadConfig : MonoBehaviour {

	public GameObject femaleDentist;
	public GameObject maleDentist;

	// Use this for initialization
	void Awake () {

		if (SceneController.instance.gender.Equals("female"))
			femaleDentist.SetActive (true);
		else if( SceneController.instance.gender.Equals("male"))
			maleDentist.SetActive (true);
		
	}

}
