using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;

    public void SetBulletSpeed(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
