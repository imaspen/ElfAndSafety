using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _nextFire = 0.0f;

    [SerializeField] private float fireDelay = 0.5f;
    [SerializeField] private int maxSpeed;
    [SerializeField] private GameObject bullet;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_nextFire > 0)
        {
            _nextFire -= Time.deltaTime;
        }
        else if (Input.GetAxis("Fire1") > 0)
        {
            var newBullet = Instantiate(bullet, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            _nextFire = fireDelay;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = maxSpeed * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var position = Camera.main.WorldToScreenPoint(transform.position);
        var mouse = Input.mousePosition;
        var angle = Mathf.Atan2(mouse.y - position.y, mouse.x - position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}