using UnityEngine;

public class Mark—ontactingObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint pointContact in collision.contacts)
        {
            pointContact.thisCollider.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

}
