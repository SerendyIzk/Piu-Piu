using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEffects : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxWiggleSpeed;
    [SerializeField] private float _zRotationOffset;
    [SerializeField] private float _yPositionOffset; //???
    private int _offsetDirection;
    private bool _stepEffectActivated = false;
    private float _wiggleSpeed;

    private void WiggleSpeedUpdate() { 
        _wiggleSpeed = Mathf.Lerp(0, _maxWiggleSpeed, _playerMovement.Speed / (_playerMovement.MaxSpeed / _maxWiggleSpeed)); }

    private IEnumerator StepEffect() { 
        while (true) {
            yield return null;
            Vector3 camRotation = _camera.transform.localEulerAngles;
            if (camRotation.z >= _zRotationOffset && camRotation.z < 360 - _zRotationOffset && _offsetDirection > 0 ||
                camRotation.z <= 360 - _zRotationOffset && camRotation.z > _zRotationOffset && _offsetDirection < 0) _offsetDirection *= -1; // step sound here
            if (_offsetDirection > 0) _camera.transform.localEulerAngles = new Vector3(camRotation.x, camRotation.y, camRotation.z + _wiggleSpeed);
            else _camera.transform.localEulerAngles = new Vector3(camRotation.x, camRotation.y, camRotation.z - _wiggleSpeed); } }

    private void StepEffectManager() {
        Vector3 camRotation = _camera.transform.localEulerAngles;
        if (!_stepEffectActivated && _playerMovement.Speed > 0) { DeterminationOffsetDirection();
                                                                  StartCoroutine(nameof(StepEffect));
                                                                  _stepEffectActivated = true; }
        if (_stepEffectActivated && _playerMovement.Speed <= 0) { StopCoroutine(nameof(StepEffect));
                                                                  _camera.transform.localEulerAngles = new Vector3(camRotation.x, camRotation.y, 0f);
                                                                  _stepEffectActivated = false; } }

    private void DeterminationOffsetDirection() {
        if (_playerMovement.PressedLeftButton) _offsetDirection = 1;
        else if (_playerMovement.PressedRightButton) _offsetDirection = -1;
        else _offsetDirection = Random.Range(0, 2) == 0 ? 1 : -1; }

    private void Start() {
        DeterminationOffsetDirection(); }

    private void Update() {
        StepEffectManager();
        WiggleSpeedUpdate(); }
}
