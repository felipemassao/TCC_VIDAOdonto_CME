using UnityEngine;
using System.Collections;

public class MovimentoTeste : MonoBehaviour {

	public string Leia = "FUNÇÃO PARA DEBUG";
		
	void Update () {
		transform.Translate(new Vector3(Random.insideUnitSphere.x, Random.insideUnitSphere.y, Random.insideUnitSphere.z) * 0.001f);
		transform.Rotate (new Vector3 (Random.insideUnitSphere.x, Random.insideUnitSphere.y, Random.insideUnitSphere.z) * 5f);
	}
}
