using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 5.0f;
    [SerializeField] private Transform _playerTransform;
    private float _spawnTimer;
    private GameObject _currentEnemy;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval)
        {
            CheckAndSpawnEnemy();
            ResetTimer();
        }
    }

    private void CheckAndSpawnEnemy()
    {
        if (_currentEnemy == null)
        {
            _currentEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        }
    }
    public void ResetTimer()
    {
        _spawnTimer = 0.0f;
    }
}
