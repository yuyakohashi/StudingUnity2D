using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private Transform _enemyTransform;
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance = 5.0f;
    [SerializeField] private int _enemyLife = 3;
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void CanItAttack()
    {
        if (_player == null) return;
        float targetDistance = Vector2.Distance(_enemyTransform.position, _player.position);

        if (targetDistance <= _distance)
        {
            agent.destination = _player.transform.position;
        }
    }
}
