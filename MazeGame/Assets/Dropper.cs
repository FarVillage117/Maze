using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidBody;
    [SerializeField] float timeToWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();
        renderer.enabled = false;  // Start with the object hidden
        rigidBody.useGravity = false;  // Gravity disabled at start
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the time passed exceeds timeToWait
        if (Time.time > timeToWait)
        {
            renderer.enabled = true;  // Show the object
            rigidBody.useGravity = true;  // Enable gravity to make the object fall
        }
    }
}