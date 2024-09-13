using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;
    protected float _timeOnStart;

    private void LifeTimer() { 
        if (Time.time - _timeOnStart >= _lifeTime) Destroy(gameObject); }

    private void Start() {
        _timeOnStart = Time.time; }

    private void Update() { 
        LifeTimer(); }
}
