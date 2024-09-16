using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if()
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
