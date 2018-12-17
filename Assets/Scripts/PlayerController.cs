using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _nextFire;
    private float _damageTime;
    private Animator _anim;
    private readonly int _damageHash = Animator.StringToHash("DamageTaken");

    [SerializeField] private float _fireDelay;
    [SerializeField] private int _maxSpeed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _damageDelay;

    public float HP { get; private set; }

    public float MaxHp
    {
        get { return _maxHp; }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        HP = _maxHp;
    }

    private void Update()
    {
        if (_damageTime > 0) _damageTime -= Time.deltaTime;

        if (_nextFire > 0)
        {
            _nextFire -= Time.deltaTime;
        }
        else if (Input.GetAxis("Fire1") > 0)
        {
            var newBullet = Instantiate(_bullet, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            _nextFire = _fireDelay;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _maxSpeed * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var position = Camera.main.WorldToScreenPoint(transform.position);
        var mouse = Input.mousePosition;
        var angle = Mathf.Atan2(mouse.y - position.y, mouse.x - position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            TakeDamage(1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy Bullet")) return;
        if (TakeDamage(1)) Destroy(other.gameObject);
    }

    private bool TakeDamage(float amount)
    {
        if (_damageTime > 0) return false;
        HP -= amount;
        if (HP <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        _damageTime = _damageDelay;
        _anim.SetTrigger(_damageHash);

        return true;

    }
}