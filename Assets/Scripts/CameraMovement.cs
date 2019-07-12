using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseX, mouseY;
    public float maxUp, maxDown;
    public float RotateSpeed;
    public Transform target, Player;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, maxUp, maxDown);

        transform.LookAt(target);
       
    }
    private void LateUpdate()
    {
        Vector3 desiredRotation = new Vector3(mouseY, mouseX, 0);

        Vector3 smoothedRotation = Vector3.Lerp(target.rotation.eulerAngles, desiredRotation, RotateSpeed);
        target.rotation = Quaternion.Euler(smoothedRotation);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

}
