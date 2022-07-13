using UnityEngine;

public abstract class LargeAndMiddleAsteroids : Asteroid
{
    [SerializeField] private Asteroid _smallerAsteroidPrefabs;
    [SerializeField] private int _numberAsteroids=2;
    [SerializeField] private float _absAngleOffsetNewAsteroid = 22.5f;

    [SerializeField] private bool _autoExpand = false;

    private PoolMono<Asteroid> _pool;

    private Vector3 _vectorMotionCurrentAsteroid;
    private Vector3 _vectorMotionNewAsteroid;
    
    private float _angleOffsetNewAsteroid;


    public override void Awake()
    {
        base.Awake();

        _pool = new PoolMono<Asteroid>(_smallerAsteroidPrefabs, _numberAsteroids, transform);
        _pool.AutoExpand = _autoExpand;
    }

    public void SplitAsteroids()
    {
        SettingSpeedMovement();

        for (int i = 0; i < _numberAsteroids; i++)
        {   
            if (i % 2 == 0)
            {
                _angleOffsetNewAsteroid = _absAngleOffsetNewAsteroid * -1;
            }
            else 
            {
                _angleOffsetNewAsteroid = _absAngleOffsetNewAsteroid;
            }
            CreateAsteroids();   
        }
        
    }

    private void CreateAsteroids()
    {
        var asteroid = _pool.GetFreeElement();
        Vector3 spawnPosition = transform.position;
        asteroid.gameObject.transform.position = spawnPosition;

        asteroid.AsteroidSpeed = _asteroidSpeed;
        asteroid.MotionVector = SettingMotionVector();
        

    }

    private void SettingSpeedMovement()
    {
        _asteroidSpeed = Random.Range(gameObject.GetComponent<Asteroid>().MinAsteroidVelocity, gameObject.GetComponent<Asteroid>().MaxAsteroidVelocity);
    }

    private Vector3 SettingMotionVector()
    {
        _vectorMotionCurrentAsteroid = gameObject.GetComponent<Asteroid>().MotionVector*-1;

        _vectorMotionNewAsteroid.x = _vectorMotionCurrentAsteroid.x * Mathf.Cos(_angleOffsetNewAsteroid) - _vectorMotionCurrentAsteroid.y * Mathf.Sin(_angleOffsetNewAsteroid);
        _vectorMotionNewAsteroid.y = _vectorMotionCurrentAsteroid.x * Mathf.Sin(_angleOffsetNewAsteroid) + _vectorMotionCurrentAsteroid.y * Mathf.Cos(_angleOffsetNewAsteroid);

        return _vectorMotionNewAsteroid;
    }
}
