using UnityEngine;
using System.Collections;

public class MovimentoSimples : MonoBehaviour {
	public float velocidade = 0.5f;
	public float zoom = 5f;
	public GameObject camobj;

	void Update()
	{
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) transform.Translate(new Vector3(velocidade * Time.deltaTime * 0.5f, 0, 0));
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) transform.Translate(new Vector3(-velocidade * Time.deltaTime * 0.5f, 0, 0));
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))	transform.Translate(new Vector3(0, 0, -velocidade * Time.deltaTime));
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) transform.Translate(new Vector3(0, 0, velocidade * Time.deltaTime));
		if (Input.GetAxis ("Mouse ScrollWheel") != 0) transform.Translate(new Vector3(0, velocidade * Input.GetAxis("Mouse ScrollWheel"), 0));
	}
}
