using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 50f;
    float engle = 0f;
    Camera camera;

    void Start()
    {
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    { 
        engle -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        engle = Mathf.Clamp(engle, -60f, 60f);
        transform.localRotation = Quaternion.Euler(engle, 0, 0);

    }
}
