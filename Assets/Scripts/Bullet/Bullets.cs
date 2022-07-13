using System.Collections;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 2f;

    protected Vector3 _motionVector;
    protected Transform _player;

    private MovingObject _movingObject;

    private float _lifeTime = 3f;
    private float _halfScreenSize;

    private void Awake()
    {
        CalculationBulletLifetime();

        transform.SetParent(null);
        _player = FindObjectOfType<PlayerMove>().gameObject.transform;
        _movingObject = FindObjectOfType<MovingObject>();

    }

    private void CalculationBulletLifetime()
    {
        _halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;
        _lifeTime = (_halfScreenSize * 2) / _bulletSpeed;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _motionVector, _bulletSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        StopCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        Deactivated();
    }

    private void Deactivated()
    {
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        _movingObject.MovingObjectsAnotherPartScreen(gameObject);
    }
}