using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public CharacterController controller;

    private float speed;
    public float mouseSensitivity = 100; 

    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }
    // Update is called once per frame
    void Update()
    {
         // in case the frame rate of other computers are higher or lower in other computers, the  * mouseSensitivity * Time.deltaTime will adjust to their particular frame rate so that we don't get a painfully high sensitivity in other devices. 
        float x = Input.GetAxis("Horizontal") * mouseSensitivity * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * mouseSensitivity * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
