using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _enemy;
    private Rect _enemyRect;
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance = 11.0f;
    [SerializeField] private int _enemyLife = 3;
    private bool _fire = true;
    private void Awake()
    {
        _enemy = GetComponent<Transform>();
    }
    private void Update()
    {
        CanItAttack();
    }
    private void CanItAttack()
    {
        if (_player == null) return;
        float targetDistance = Vector2.Distance(_enemy.position, _player.position);
            
        if(targetDistance <= _distance && _fire)
        {
            StartCoroutine(AttackThePlayer());
        }
    }
    private IEnumerator AttackThePlayer()
    {
        _fire = false;
        if(_enemyBullet == null) yield break;
        GameObject bullet = Instantiate(_enemyBullet, _enemy.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetBulletSpeed(-_bulletSpeed);
        yield return new WaitForSeconds(1);

        _fire = true;
    }
    public Rect GetEnemyRect()
    {
        _enemyRect = new Rect(_enemy.position.x, _enemy.position.y, 0.5f, 0.5f);
        return _enemyRect;
    }
    public void AddDamage()
    {
        Debug.Log("É_ÉÅÅ[ÉWÇó^Ç¶Ç‹ÇµÇΩ");
        _enemyLife--;
        if (_enemyLife == 0) { Destroy(gameObject); }
    }
}
