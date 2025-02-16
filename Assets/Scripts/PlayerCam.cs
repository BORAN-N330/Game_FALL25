using UnityEngine;

//using ideas from this source: https://www.youtube.com/watch?v=f473C43s8nE

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //lock the cursor and make it visible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * Time.deltaTime * sensX;
        xRotation -= mouseY * Time.deltaTime * sensY;

        //stop from looking too far up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //apply rotation to transform
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
