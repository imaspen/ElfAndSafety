using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        var x = 0f;
        var y = 0f;
        do
        {
            x = Random.Range(-8f, 8f);
            y = Random.Range(-4f, 4f);
        } while (Mathf.Abs(x - _player.transform.position.x) < 1 || Mathf.Abs(y - _player.transform.position.y) < 1);
        transform.position = new Vector3(x, y);
        _walkSpeed += Time.time / 30;
    }

    // Update is called once per frame
    void Update()
    {
        var walk = new Vector3(0, _walkSpeed);
        _myRigidbody.rotation =
            Mathf.Atan2(transform.position.x - _player.transform.position.x,
                _player.transform.position.y - transform.position.y) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().velocity = transform.rotation * walk;
        Debug.Log(_walkSpeed);
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