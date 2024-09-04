using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float xvalue = 0.001f;
    [SerializeField] float zvalue = 0.001f;
    float factor = 0.10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xvalue = Input.GetAxis("Horizontal");
        float zvalue = Input.GetAxis("Vertical")*factor;
        transform.Translate(zvalue ,0 ,0);
        transform.Rotate(0, xvalue ,0);
    }
}
