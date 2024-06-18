using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private Transform _bulletTransform;
    private Rect _bulletRect;
    private void Awake()
    {
        _bulletTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        UpdateBulletRect();
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void SetBulletSpeed(float speed)
    {
        _speed = speed;
    }
    private void UpdateBulletRect()
    {
        _bulletRect = new Rect(_bulletTransform.position.x, _bulletTransform.position.y, 0.25f, 0.125f);
    }

    public Rect GetBulletRect()
    {
        return _bulletRect;
    }
}
