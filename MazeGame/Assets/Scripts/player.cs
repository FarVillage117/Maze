using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody rb;

    [SerializeField] private int heath = 5;
    [SerializeField] float factor = 10f;
    private int score = 0;

    void Start()
    {
        PrintInstruction();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Apply an upward force for jumping
        isGrounded = false;  // The character is no longer grounded after jumping
    }

    void MovePlayer()
    {
        float xvalue = Input.GetAxis("Horizontal") * Time.deltaTime * factor;
        float zvalue = Input.GetAxis("Vertical") * Time.deltaTime * factor;
        transform.Translate(xvalue, 0, zvalue);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log("Score: " + score);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            heath--;
            Debug.Log("Health: " + heath);
            if (heath <= 0)
            {
                Debug.Log("Game Over");
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
        }
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome.");
        Debug.Log("Move with WASD.");
        Debug.Log("Dont hit the walls.");
    }
}
