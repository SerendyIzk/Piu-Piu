using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOffsetOnLean : MonoBehaviour
{
    [SerializeField] private PlayerLeaning _playerLeaning;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _xPositionOnRightLean;
    [SerializeField] private float _xPositionOnLeftLean;

    private void LeaningUpdate() { Vector3 rotation = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(rotation.x, rotation.y, _playerTransform.localEulerAngles.z); }

    private void PositioningUpdate() { 
        Vector3 playerRotation = _playerTransform.localEulerAngles;
        Vector3 pos = transform.localPosition;
        if (playerRotation.z < 180 && playerRotation.z > 0.5) {
            transform.localPosition = new Vector3(Mathf.Lerp(_xPositionOnRightLean, _xPositionOnLeftLean, playerRotation.z / _playerLeaning.LeanAngle), pos.y, pos.z); }
        else transform.localPosition = new Vector3(_xPositionOnRightLean, pos.y, pos.z); } 

    private void Update() { 
        LeaningUpdate();
        PositioningUpdate(); }
}
