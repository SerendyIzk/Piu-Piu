using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool PressedRightButton { get; private set; }
    public bool PressedLeftButton { get; private set; }
    public float Speed { get; private set; }
    public float MaxSpeed { get { return _maxSpeed; } }
    private bool _pressedMoveButton;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    private Vector3 _moveVector;

    private void DeterminationMoveVectorUpdate() { 
        _moveVector = Vector3.zero; _pressedMoveButton = false; PressedRightButton = false; PressedLeftButton = false;
        if (Input.GetKey(KeyCode.W)) { _moveVector += transform.forward; _pressedMoveButton = true; }
        if (Input.GetKey(KeyCode.S)) { _moveVector -= transform.forward; _pressedMoveButton = true; }
        if (Input.GetKey(KeyCode.A)) { _moveVector -= transform.right; _pressedMoveButton = true; PressedLeftButton = true; }
        if (Input.GetKey(KeyCode.D)) { _moveVector += transform.right; _pressedMoveButton = true; PressedRightButton = true; } }

    private void Acceleration() {
        Speed = _pressedMoveButton ? Mathf.Clamp(Speed + _acceleration * Time.deltaTime, 0, _maxSpeed) : 0f; }

    private void HorizontalMovementFixedUpdate() {
        transform.position += _moveVector * Speed * Time.fixedDeltaTime; }

    private void Update() { 
        DeterminationMoveVectorUpdate();
        Acceleration(); }

    private void FixedUpdate() {
        HorizontalMovementFixedUpdate(); }
}
