using System;
using UnityEngine;
using System.Collections;

public class BulletPatternGenerator : MonoBehaviour
{
    // Use this for initialization
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _shotsPerRotation;
    [SerializeField] private float _secondsPerRotation;

    private float _rotationTime;

    void Update()
    {
        _rotationTime += Time.deltaTime;
        if (_rotationTime > _secondsPerRotation)
        {
            for (var i = 0; i < _shotsPerRotation; i++)
            {
                var angle = i * (2 * Mathf.PI / _shotsPerRotation);
                var x = transform.position.x + 2 * Mathf.Cos(angle);
                var y = transform.position.y + 2 * Mathf.Sin(angle);
                Instantiate(_bullet, new Vector3(x, y), Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg));
            }
            _rotationTime -= _secondsPerRotation;
        }
    }
}