using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : FallingObject
{
    [SerializeField] private float _jumpBufferingTime;
    [SerializeField] private float _jumpCD;
    [SerializeField] private float _jumpForce;
    private bool _jumpReady = true;
    private bool _jumpBufferTimerStarted;

    protected override void FallVelocityUpdate() {
        _fallVelocity = _groundedController.IsGrounded && _jumpReady ? 0f : _fallVelocity - _gravity; }

    private void JumpUpdate() {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpReady) { if (_groundedController.IsGrounded) Jump();
                                                             else if (!_jumpBufferTimerStarted) StartCoroutine(nameof(JumpBuffering)); } }

    private void JumpCD() { 
        _jumpReady = true; }

    private void Jump() {
        _fallVelocity = _jumpForce;
        _jumpReady = false;
        Invoke(nameof(JumpCD), _jumpCD);
        _jumpBufferTimerStarted = false; }

    private IEnumerator JumpBuffering() {
        _jumpBufferTimerStarted = true;
        Invoke(nameof(JumpBufferTimeExpired), _jumpBufferingTime);
        yield return new WaitUntil(() => _groundedController.IsGrounded);
        Jump(); }

    private void JumpBufferTimeExpired() {
        StopCoroutine(nameof(JumpBuffering));
        _jumpBufferTimerStarted = false; }

    private void Update() {
        JumpUpdate();
        FallVelocityUpdate(); }
}
