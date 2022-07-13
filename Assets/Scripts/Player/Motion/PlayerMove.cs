using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedIncreaseStep;
    [SerializeField] private float _currentSpeed;

    private Vector3 _currentVectorMovement;
    private Vector3 _offsetVectorMovement;
    private Vector3 offset;

    private MovingObject _movingObject;

    private void Start()
    {
        _movingObject = FindObjectOfType<MovingObject>();
        EventSystem.MotionButtonPressed += ChangingMotionVector;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, transform.position + offset, _currentSpeed * Time.deltaTime); 
    }

    private void ChangingMotionVector()
    {
        _offsetVectorMovement = transform.up.normalized;
        _currentVectorMovement += _offsetVectorMovement / 700;
        offset = _currentVectorMovement;

        _currentSpeed += _speedIncreaseStep;

        if (_currentSpeed >= _maxSpeed)
        {
            _currentVectorMovement = Vector3.ClampMagnitude(_currentVectorMovement, 0.09f);
            offset = Vector3.ClampMagnitude(_currentVectorMovement, 0.08f);
            _currentSpeed = _maxSpeed;
        }
    }

    private void OnBecameInvisible()
    {
        _movingObject.MovingObjectsAnotherPartScreen(gameObject);
    }
    private void OnDestroy()
    {
        EventSystem.MotionButtonPressed -= ChangingMotionVector;
    }
}
