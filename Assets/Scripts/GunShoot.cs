using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject _shootSmoke;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;
    [SerializeField] private float _muzzleFlashExistenceTime;
    [SerializeField] private float _shootCD;
    private bool _readyToShoot = true;

    private void SmokeCasting() {
        Instantiate(_shootSmoke, _shootPoint.position, Quaternion.identity); }

    private void MuzzleFlashUpdate() {
        if (_muzzleFlash != null) {
            _muzzleFlash.SetActive(true);
            Invoke(nameof(MuzzleFlashDisable), _muzzleFlashExistenceTime); } }

    private void MuzzleFlashDisable() { _muzzleFlash.SetActive(false); }

    private void ShootCD() { 
        _readyToShoot = true; }

    private void ShootUpdate() {
        if (Input.GetMouseButton(0) && _readyToShoot) {
            _readyToShoot = false;
            Invoke(nameof(ShootCD), _shootCD);
            SmokeCasting();
            MuzzleFlashUpdate(); } }

    private void Update() { 
        ShootUpdate(); }
}
