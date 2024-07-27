using UnityEngine;

public class LaserBullet : Bullet 
{
    [SerializeField] private float _appear = 0.2f;
    [SerializeField] private int _laserDamage = 3;

    private void Update()
    {
        LaserDestroy();
        UpdateBulletRect();
    }

    private void LaserDestroy()
    {
        _appear -= Time.deltaTime;
        if (_appear <= 0)
        {
            Destroy(gameObject);
        }
    }
    public int AddDamage()
    {
        return _laserDamage;
    }
}

