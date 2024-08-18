using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] protected float _gravity;
    [SerializeField] protected GroundedController _groundedController;
    protected float _fallVelocity;

    protected virtual void FallVelocityUpdate() {
        _fallVelocity = _groundedController.IsGrounded ? 0f : _fallVelocity - _gravity; }

    private void FallingFixedUpdate() { 
        transform.position -= Vector3.down * _fallVelocity * Time.fixedDeltaTime; }

    private void Update() { 
        FallVelocityUpdate(); }

    private void FixedUpdate() { 
        FallingFixedUpdate(); }
}
