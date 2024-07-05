using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _enemyTransform;
    private Rect _enemyRect;
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance = 11.0f;
    [SerializeField] private int _enemyLife = 3;
    private SpawnPoint _spawnPoint;
    private bool _fire = true;
    private void Awake()
    {
        _enemyTransform = GetComponent<Transform>();
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _spawnPoint = GetComponent<SpawnPoint>();
    }
    private void Update()
    {
        CanItAttack();
    }
    private void CanItAttack()
    {
        if (_player == null) return;
        float targetDistance = Vector2.Distance(_enemyTransform.position, _player.position);
            
        if(targetDistance <= _distance && _fire)
        {
            StartCoroutine(AttackThePlayer());
        }
    }
    private IEnumerator AttackThePlayer()
    {
        _fire = false;
        if(_enemyBullet == null) yield break;
        GameObject bullet = Instantiate(_enemyBullet, _enemyTransform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetBulletSpeed(-_bulletSpeed);
        yield return new WaitForSeconds(1);

        _fire = true;
    }
    public Rect GetEnemyRect()
    {
        _enemyRect = new Rect(_enemyTransform.position.x, _enemyTransform.position.y, 0.5f, 0.5f);
        return _enemyRect;
    }
    public void AddDamage()
    {
        Debug.Log("É_ÉÅÅ[ÉWÇó^Ç¶Ç‹ÇµÇΩ");
        _enemyLife--;
        if (_enemyLife == 0) { Destroy(gameObject); }
    }
    private void OnDestroy()
    {
        if(_spawnPoint == null) return;
        _spawnPoint.ResetTimer();
    }
}
