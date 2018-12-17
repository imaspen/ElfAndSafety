using UnityEngine;

public class SnowmanController : MonoBehaviour
{
    private GameObject _player;
    private float _hp;
    private Rigidbody2D _myRigidbody;
    private float _knockBackTimer;
    private float _damageTime;
    private GameController _gameController;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _maxHP;
    [SerializeField] private float _knockBackAmount;

    public float HP
    {
        get { return _hp; }
    }

    // Use this for initialization
    private void Start()
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

        _gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    // Update is called once per frame
    private void Update()
    {
        var walk = new Vector3(0, _walkSpeed);
        _myRigidbody.rotation =
            Mathf.Atan2(transform.position.x - _player.transform.position.x,
                _player.transform.position.y - transform.position.y) * Mathf.Rad2Deg;
        _myRigidbody.velocity = transform.rotation * walk;
        if (_knockBackTimer > 0)
        {
            _myRigidbody.velocity *= (_knockBackTimer - _knockBackAmount / 2) * -2;
            _knockBackTimer -= Time.deltaTime;
        }

        if (_damageTime > 0) _damageTime -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player Bullet") || _damageTime > 0) return;
        if (--_hp <= 0)
        {
            _gameController.Score += 20;
            Destroy(gameObject);
        }
        else
        {
            _knockBackTimer = _knockBackAmount;
            _damageTime = 1.5f * _knockBackAmount;
        }
    }
}