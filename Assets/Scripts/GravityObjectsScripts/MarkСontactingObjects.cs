using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark—ontactingObjects : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint pointContact in collision.contacts)
        {
            pointContact.thisCollider.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

}
