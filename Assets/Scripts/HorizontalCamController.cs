using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCamController : MonoBehaviour
{
    [SerializeField] private float _horizontalSensivity;
    private float _horAxis;

    private void AxisUpdate() {
        _horAxis = Input.GetAxis("Mouse X"); }

    private void CamMovementUpdate() {
        transform.localEulerAngles += new Vector3(0f, _horAxis * _horizontalSensivity * Time.deltaTime, 0f); }

    private void Update() {
        AxisUpdate();
        CamMovementUpdate(); }
}

