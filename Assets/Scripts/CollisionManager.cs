using UnityEngine;

///<summary>
///Collisionを管理するクラス
/// </summary>
public class CollisionManager : MonoBehaviour
{
    static CollisionManager _instance = new CollisionManager();
    public static CollisionManager Instance => _instance;
    private CollisionManager() { }

    [SerializeField] private PlayerController _player;
    [SerializeField] private Enemy[] _enemies;
    private void Update()
    {
        PlayerCollision();
        EnemyCollision();
    }
    private void PlayerCollision()
    {
        if (_player == null) return;

        Bullet[] _bullets = FindObjectsOfType<Bullet>();
        Vector2 _playerPosition = _player.transform.position;
        foreach (var bullet in _bullets)
        {
            if (bullet.CompareTag("EnemyBullet"))
            {
                Rect _bulletRect = bullet.GetBulletRect();
                if (_bulletRect.Contains(_playerPosition))//短形と点
                {
                    Destroy(bullet.gameObject);
                    _player.AddDamage();
                    break;
                }
            }
        }
    }
    private void EnemyCollision()
    {
        Enemy[] _enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in _enemies)
        {
            Bullet[] _bullets = FindObjectsOfType<Bullet>();
            Rect _enemyRect = enemy.GetEnemyRect();

            foreach (var bullet in _bullets)
            {
                if (bullet.CompareTag("PlayerBullet"))
                {
                    Rect _bulletRect = bullet.GetBulletRect();
                    if (_enemyRect.Overlaps(_bulletRect))//短形と短形
                    {
                        Destroy(bullet.gameObject);
                        enemy.AddDamage();
                        break;
                    }
                }
            }
        }
    }
}
