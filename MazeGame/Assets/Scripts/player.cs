using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody rb;

    [SerializeField] private int health = 5; 
    [SerializeField] float factor = 10f;
    private int score = 0;

    
    [SerializeField] private float boostFactor = 1.5f; 
    private float currentFactor;

    void Start()
    {
        PrintInstruction();
        rb = GetComponent<Rigidbody>();
        currentFactor = factor;
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.B))
        {
            currentFactor = factor * boostFactor;
        }
        else
        {
            currentFactor = factor;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void MovePlayer()
    {
        float xvalue = Input.GetAxis("Horizontal") * Time.deltaTime * currentFactor;
        float zvalue = Input.GetAxis("Vertical") * Time.deltaTime * currentFactor;
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
            health--;
            Debug.Log("Health: " + health);
            if (health <= 0)
            {
                Debug.Log("Game Over");
            }
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Hit"))
        {
            isGrounded = true;
        }
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome.");
        Debug.Log("Move with WASD. And hold 'B' to boost.");
    }
}
