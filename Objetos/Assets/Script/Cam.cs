using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public bool noOculus;
    public float rotateSpeed;
    public float moveSpeed;
    public float scrollSpeed;
    private float hor;
    private float ver;


    // Use this for initialization
    void Start()
    {
        hor = transform.eulerAngles.x;
        ver = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (noOculus)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                hor -= rotateSpeed * Input.GetAxis("Mouse Y");
                ver += rotateSpeed * Input.GetAxis("Mouse X");
                transform.eulerAngles = new Vector3(hor, ver, 0);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Input.GetKey(KeyCode.Mouse2))
            {
                transform.Translate(Input.GetAxis("Mouse X") * -moveSpeed * Time.deltaTime, Input.GetAxis("Mouse Y") * -moveSpeed * Time.deltaTime, 0);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime);
        }
    }
}

