using UnityEngine;

public abstract class Asteroid : MonoBehaviour
{
    public Vector3 MotionVector { get; set; }

    public float MinAsteroidVelocity { get; } = 0.5f;

    public float MaxAsteroidVelocity { get; } = 2f;

    [SerializeField] private protected int _pointsForMurder;
    protected float _asteroidSpeed;

    private protected float halfScreenSize;
    private MovingObject _movingObject;
    
    public float AsteroidSpeed { 
        get
        {
            return _asteroidSpeed;
        }
        set
        {
            if (MinAsteroidVelocity < value && value < MaxAsteroidVelocity)
            {
                _asteroidSpeed = value;
            }
            else
            {
                _asteroidSpeed= Random.Range(MinAsteroidVelocity, MaxAsteroidVelocity);
            }
        }
    }


    public virtual  void  Awake()
    {
        FindObjectOfType<IncreasingNumberAsteroids>().GetComponent<IncreasingNumberAsteroids>().ListAllAsteroid.Add(gameObject.GetComponent<Asteroid>());

        transform.SetParent(null);
        _movingObject = FindObjectOfType<MovingObject>();
        halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;
    }

    public virtual void OnEnable()
    {
        _asteroidSpeed = Random.Range(MinAsteroidVelocity, MaxAsteroidVelocity);
        MotionVector = new Vector3(Random.Range(-halfScreenSize, halfScreenSize), Random.Range(-halfScreenSize, halfScreenSize), 0).normalized;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + MotionVector, _asteroidSpeed * Time.deltaTime);
    }

    public int GetPoints()
    {
        return _pointsForMurder;
    }
    
    private void OnBecameInvisible()
    {
        _movingObject.MovingObjectsAnotherPartScreen(gameObject);
    }
}
