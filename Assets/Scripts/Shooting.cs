using UnityEngine;

public abstract class Shooting : MonoBehaviour
{
    [SerializeField] private protected int _bulletCount = 10;
    [SerializeField] private protected bool _autoExpand = false;
    [SerializeField] private protected Bullets _bulletPrefab;
    
    private protected PoolMono<Bullets> _pool;

    private protected float _firingFrequency;
    private protected float _timer;

    protected virtual void Start()
    {
        _pool = new PoolMono<Bullets>(_bulletPrefab, _bulletCount, transform);
        _pool.AutoExpand = _autoExpand;
    }

    protected virtual void Update()
    {
        _timer += Time.deltaTime;
    }

    protected abstract void CheckingForPossibilityShot();

    protected void CreateBullet()
    {
        var bullet = _pool.GetFreeElement();
        Vector3 spawnPosition = transform.position+ transform.up.normalized/3;
        bullet.transform.position = spawnPosition;
    }
}
