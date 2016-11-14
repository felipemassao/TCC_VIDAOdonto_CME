using UnityEngine;
using System.Collections;

public class Seringa : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float thrustSpeed;
	public bool noLeap;
	private bool esc;
	private bool move;
	private bool spin;
	private bool thrust;
	private bool cam;
	private float magnitude;

	// Use this for initialization
	void Start()
	{
		Cursor.visible = false;
		cam = false;
		move = false;
		spin = false;
		thrust = false;
		esc = false;
		magnitude = transform.lossyScale.magnitude / Mathf.Sqrt(3);

	}

	// Update is called once per frame
	void Update()
	{
		if (noLeap)
		{
			if (Input.GetKey(KeyCode.Q))
			{
				cam = false;
				move = true;
				spin = false;
				thrust = false;
				esc = false;
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			else if (Input.GetKey(KeyCode.W))
			{
				cam = false;
				move = false;
				spin = true;
				thrust = false;
				esc = false;
			}
			else if (Input.GetKey(KeyCode.E))
			{
				cam = false;
				move = false;
				spin = false;
				thrust = true;
				esc = false;
			}
			else if (Input.GetKey(KeyCode.Escape))
			{
				cam = false;
				move = false;
				spin = false;
				thrust = false;
				esc = true;
			}
			else if (Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Mouse2))
			{
				cam = true;
				move = false;
				spin = false;
				thrust = false;
				esc = false;
			}
			if (move)
			{
				transform.Translate(Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime / magnitude, Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime / magnitude, 0, Space.World);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (spin)
			{
				transform.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime / magnitude, 0, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime / magnitude);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (thrust)
			{
				transform.Translate(0, -Input.GetAxis("Mouse Y") * thrustSpeed * Time.deltaTime / magnitude, 0);
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (cam)
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			if (esc)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
		}
	}
}
