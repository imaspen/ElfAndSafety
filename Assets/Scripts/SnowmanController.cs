using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanController : MonoBehaviour
{
    private GameObject _player;
    private float _hp = 0;
    private Rigidbody2D _myRigidbody;
    
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _maxHP;
    
    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player");
        _hp = _maxHP;
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var walk = new Vector3(0, _walkSpeed);
        _myRigidbody.rotation =
            Mathf.Atan2(transform.position.x - _player.transform.position.x,
                _player.transform.position.y - transform.position.y) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().velocity = transform.rotation * walk;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player Bullet"))
        {
            if (--_hp <= 0)
                Destroy(gameObject);
        }
    }
}