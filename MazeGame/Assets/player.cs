using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float xvalue = 0f;
    [SerializeField] float yvalue = 0.02f;
    [SerializeField] float zvalue = 0;
    [SerializeField] private int heath = 5;
    float factor = 0.10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xvalue = Input.GetAxis("Horizontal")*factor;
        float zvalue = Input.GetAxis("Vertical")*factor;
        transform.Translate(xvalue ,0 ,zvalue);
        
    }

    private int score = 0;
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
        if (collision.gameObject.ComapareTag("Obstacle"))
        {
            heath--;
            Debug.Log("Health: " + heath);
            if (heath <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
