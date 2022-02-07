using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectInCenter : MonoBehaviour
{
    [SerializeField]
    GameObject CenterObject;
    [SerializeField]
    float speed;

    Rigidbody rigidbodyObject;
    Vector3 transformPosition;
    Vector3 vectorPos;




    void Start()
    {
        rigidbodyObject = GetComponent<Rigidbody>();
        transformPosition = CenterObject.transform.position;
        
    }

    private void Update()
    {
        if (Vector3.Distance(transformPosition, transform.position) < 0.1f)
        {
            rigidbodyObject.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        vectorPos = Vector3.Reflect(vectorPos, contact.normal);
        Rebound();
    }

    private void Rebound()
    {
        rigidbodyObject.AddForce(vectorPos * 3, ForceMode.Impulse);
    }

    public void Move()
    {
        vectorPos = (CenterObject.transform.position - transform.position).normalized;
        rigidbodyObject.AddForce(vectorPos * 20, ForceMode.Force);
    }
}
