using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private void OnTriggerStay(Collider col) {
        IsGrounded = true; }

    private void OnTriggerExit(Collider col) { 
        IsGrounded = false; }
}
