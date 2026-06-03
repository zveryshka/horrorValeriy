using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] Slider slider;
    CharacterController controller;
    Animator animator;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 100f;
    public float stamina = 1f;

    private Vector3 velocity;

    private void Update()
    {
        MovePlayer();
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
        Stamina();
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void MovePlayer()
    {
        float coef = 1.5f;
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
        {
            coef = 2.5f;
            stamina -= Time.deltaTime * 1f;
        }
        else
        {
            coef = 1f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime * coef);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Stamina()
    {
        if(stamina < 1f && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime * 0.5f;
        }
        slider.value = stamina;
    }
}
