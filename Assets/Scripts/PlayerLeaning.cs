using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeaning : MonoBehaviour
{
    [SerializeField] private float _nullifyingLeanAngle;
    [SerializeField] private float _leanAngle;
    [SerializeField] private float _leanSpeed;
    private bool _leanedOnLeft;
    private bool _angleNormalizing;

    private void LeanManagerUpdate() {
        if (transform.localEulerAngles.z <= _nullifyingLeanAngle || transform.localEulerAngles.z >= 360 - _nullifyingLeanAngle ) { 
            if (Input.GetKeyDown(KeyCode.Q)) {
                _leanedOnLeft = true;
                StartCoroutine(nameof(Lean)); }
            if (Input.GetKeyDown(KeyCode.E)) {
                _leanedOnLeft = false;
                StartCoroutine(nameof(Lean)); } }
        else if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) && !_angleNormalizing) {
            StopCoroutine(nameof(Lean));
            StartCoroutine(nameof(NormalizeAngle));
            _angleNormalizing = true; } }

    private IEnumerator Lean() {
        while (true) {
            yield return null;
            if (_leanedOnLeft) { 
                transform.localEulerAngles += new Vector3(0f, 0f, _leanSpeed * Time.deltaTime);
                if (transform.localEulerAngles.z >= _leanAngle) StopCoroutine(nameof(Lean)); }
            else {
                transform.localEulerAngles -= new Vector3(0f, 0f, _leanSpeed * Time.deltaTime);
                if (transform.localEulerAngles.z <= 360 - _leanAngle) StopCoroutine(nameof(Lean)); } } }

    private IEnumerator NormalizeAngle() { 
        while (true) {
            yield return null;
            if (transform.localEulerAngles.z > 180) { 
                transform.localEulerAngles += new Vector3(0f, 0f, _leanSpeed * Time.deltaTime);
                if (transform.localEulerAngles.z >= 360 - _nullifyingLeanAngle) EndNormalizingAngle(); }
            else if (transform.localEulerAngles.z < 180) { 
                transform.localEulerAngles -= new Vector3(0f, 0f, _leanSpeed * Time.deltaTime);
                if (transform.localEulerAngles.z <= _nullifyingLeanAngle) EndNormalizingAngle(); } } }

    private void EndNormalizingAngle() {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        _angleNormalizing = false;
        StopCoroutine(nameof(NormalizeAngle)); }

    private void Update() { 
        LeanManagerUpdate(); }
}
