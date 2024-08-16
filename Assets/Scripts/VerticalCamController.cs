using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamController : MonoBehaviour
{
    [SerializeField] private float _verticalSensivity;
    private float _vertAxis;

    private void AxisUpdate() {
        _vertAxis = Input.GetAxis("Mouse Y"); }

    private void CamMovementUpdate() {
        transform.localEulerAngles += new Vector3(-_vertAxis * _verticalSensivity, 0f, 0f); }

    private void Update() {
        AxisUpdate();
        CamMovementUpdate(); }
}
