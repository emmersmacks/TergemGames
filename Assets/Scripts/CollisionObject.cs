using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    void OnCollisionEnter(Collision colission)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
