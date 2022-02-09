using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagingAnObjectAttraction : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float ForceOfGravity;

    private Rigidbody rigidbodyThisDesign;
    private Vector3 DirectionToTarget;

    private MovementStates CurrentState;

    const float DistanceToInclusionAttraction = 150f;
    const float DistanceToStop = 2f;

    private void Start()
    {
        rigidbodyThisDesign = GetComponent<Rigidbody>();
        CurrentState = MovementStates.goToTarget;
    }

    private void Update()
    {
        if (DistanceToTarget() < DistanceToStop && CurrentState == MovementStates.goToTarget)
            CurrentState = MovementStates.inTarget;
        else if (DistanceToTarget() > DistanceToInclusionAttraction)
            CurrentState = MovementStates.goToTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CurrentState = MovementStates.bounce;
        Vector3 ReboundDirection = (transform.position - collision.transform.position);
        rigidbodyThisDesign.AddForce(ReboundDirection * 5, ForceMode.Impulse);
        StartCoroutine("WaitGravity");
    }

    private void FixedUpdate()
    {
        if(CurrentState == MovementStates.inTarget)
            rigidbodyThisDesign.velocity = Vector3.zero;
        else if(CurrentState == MovementStates.goToTarget)
            MoveToTarget(ForceOfGravity);
    }

    private void MoveToTarget(float force)
    {
        DirectionToTarget = (targetTransform.position - transform.position);
        rigidbodyThisDesign.AddForce(DirectionToTarget * force, ForceMode.Force);
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(targetTransform.position, transform.position);
    }

    protected IEnumerator WaitGravity()
    {
        yield return new WaitForSeconds(0.5f);
        CurrentState = MovementStates.goToTarget;
    }
}

enum MovementStates
{
    inTarget,
    bounce,
    goToTarget,
}
