using System;
using UnityEngine;
using System.Collections;

public class BulletPatternGenerator : MonoBehaviour
{
    // Use this for initialization
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _shotsPerRotation;
    [SerializeField] private float _secondsPerRotation;

    private float _rotationTime = 0.0f;
    private float _nextTime = 0.0f;

    void Update()
    {
        _rotationTime = (_rotationTime + Time.deltaTime) % _secondsPerRotation;
        _nextTime += Time.deltaTime;
        if (_nextTime > _secondsPerRotation / _shotsPerRotation)
        {
            float angle = _rotationTime / _secondsPerRotation * (float)Math.PI * 2;
            var x = transform.position.x + 2 * Mathf.Cos(_rotationTime * Mathf.PI);
            var y = transform.position.y + 2 * Mathf.Sin(_rotationTime * Mathf.PI);
            Instantiate(_bullet, new Vector3(x, y), Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg));
            _nextTime = _nextTime % (_secondsPerRotation / _shotsPerRotation);
        }
    }
}