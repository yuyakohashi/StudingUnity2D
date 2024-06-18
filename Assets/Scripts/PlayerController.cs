using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _player;
    private Rect _playerRect;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private int _playerLife = 5;
    [SerializeField] private GameObject _playerBullet = null;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private float _jumpSpeed = 5.0f;//初速度
    [SerializeField] private float _gravity = 9.81f;//重力
    [SerializeField] private float _ground = -2.0f;//地面の高さ
    private float _verticalHeight = 0.0f;//垂直の高さ
    private bool _isGrounded = true;
    private void Awake()
    {
        _player = GetComponent<Transform>();
    }
    void Update()
    {
        Move();
        Jump();
        FireBullet();
        IsGravity();
    }
    private　void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(x * _speed * Time.deltaTime, 0));
    }
    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalHeight = (_jumpSpeed * _jumpSpeed) / (2 * _gravity);
            _isGrounded = false;
        }
    }
    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_playerBullet == null) return;

            GameObject bullet = Instantiate(_playerBullet, _player.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetBulletSpeed(_bulletSpeed);
        }
    }
    private void IsGravity()
    {
        if (!_isGrounded)
        {
            _verticalHeight -= _gravity * Time.deltaTime;
            _player.position += new Vector3(0, _verticalHeight * Time.deltaTime, 0);

            if (_player.position.y <= _ground)
            {
                _player.position = new Vector3(_player.position.x, _ground, _player.position.z);
                _verticalHeight = 0;
                _isGrounded = true;
            }
        }
    }
    public Rect GetPlayerRect()
    {
        _playerRect = new Rect(_player.position.x, _player.position.y, 0.5f, 0.5f);
        return _playerRect;
    }
    public void AddDamage()
    {
        Debug.Log("ダメージを受けました");
        _playerLife--;
        if (_playerLife == 0) { Destroy(gameObject); }
    }
}
