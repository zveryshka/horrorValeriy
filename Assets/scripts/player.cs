using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    CharacterController controller;
    Animator animator;

    [SerializeField] Slider slider;
    [SerializeField] AudioSource footsteps;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip runSound;
    bool wasRunning;

     float stepTimer;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 400f;
    public float jumpForce = 0.5f;
    public GameObject screamer;
    public AudioSource screamerSound;
    public float stamina = 1f;



    private Vector3 velocity;

    private void Update()
    {
        MovePlayer();
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);
        Stamina();
        //Footsteps(Input.GetKey(KeyCode.LeftShift) && stamina > 0f);
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void MovePlayer()
    {
        float coef = 1f;
        bool running = false;

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0f)
        {
            coef = 2.5f;
            stamina -= Time.deltaTime * 0.1f;
            running = true;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime * coef);


        bool isMoving = Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveZ) > 0.1f;

        if (isMoving)
        {
            stepTimer += Time.deltaTime;

            float interval = running ? 0.3f : 0.5f;

            if (stepTimer >= interval)
            {
                footsteps.PlayOneShot(
                    running ? runSound : walkSound
                );

                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }

        if (controller.isGrounded)
        {
            velocity.y = -0.01f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
       
    }
    private void Stamina()
    {
        if (stamina < 1f && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime * 0.5f;
        }
        slider.value = stamina;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Death());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        screamer.SetActive(true);
        screamerSound.Play();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

}
