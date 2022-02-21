using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ManagingAnObjectAttraction : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _forceOfGravity;

    private Rigidbody _rigidbodyThisDesign;
    private Vector3 _directionToTarget;

    private MovementStates _currentState;

    const float DistanceToInclusionAttraction = 150f;
    const float TargetRadius = 2f;
    const float ReboundForce = 5f;
    const float ReboundDuration = 0.5f;

    private void Start()
    {
        _rigidbodyThisDesign = GetComponent<Rigidbody>();
        _currentState = MovementStates.goToTarget;
    }

    private void Update()
    {
        if (GetDistanceToTarget() < TargetRadius && _currentState == MovementStates.goToTarget)
            _currentState = MovementStates.inTarget;
        else if (GetDistanceToTarget() > DistanceToInclusionAttraction)
            _currentState = MovementStates.goToTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _currentState = MovementStates.bounce;
        var reboundDirection = (transform.position - collision.transform.position);
        _rigidbodyThisDesign.AddForce(reboundDirection * ReboundForce, ForceMode.Impulse);
        StartCoroutine(nameof(ReboundDelay));
    }

    private void FixedUpdate()
    {
        if(_currentState == MovementStates.inTarget)
            _rigidbodyThisDesign.velocity = Vector3.zero;
        else if(_currentState == MovementStates.goToTarget)
            MoveToTarget(_forceOfGravity);
    }

    private void MoveToTarget(float force)
    {
        _directionToTarget = (_targetTransform.position - transform.position);
        _rigidbodyThisDesign.AddForce(_directionToTarget * force, ForceMode.Force);
    }

    private float GetDistanceToTarget()
    {
        return Vector3.Distance(_targetTransform.position, transform.position);
    }

    protected IEnumerator ReboundDelay()
    {
        yield return new WaitForSeconds(ReboundDuration);
        _currentState = MovementStates.goToTarget;
    }

    enum MovementStates
    {
        inTarget,
        bounce,
        goToTarget,
    }
}
