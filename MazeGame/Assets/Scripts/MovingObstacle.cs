using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 10f;
    public float Rotationspeed = 50f;
    private Vector3 startPos;
    [SerializeField] private int heath = 5;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3(startPos.x + movement, startPos.y, startPos.z);
        transform.Rotate(Vector3.up * Rotationspeed * Time.deltaTime);
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
            Debug.Log("You hit a wall.");
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    
}
