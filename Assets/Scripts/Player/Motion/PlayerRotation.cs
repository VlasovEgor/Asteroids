using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _turningSpeed;

    private Vector3 _directionRotation;
    private Vector3 currentRotation;

    private void Start()
    {
        EventSystem.RotationButtonPressed += Rotate;
    }

    private void Rotate(Vector3 vectorDirectionRotation)
    {
        _directionRotation = vectorDirectionRotation - transform.position;
        _directionRotation.Normalize();
        currentRotation = Vector2.Lerp(currentRotation, _directionRotation, Time.deltaTime * _turningSpeed);
        transform.up = currentRotation;
    }

    private void OnDestroy()
    {
        EventSystem.RotationButtonPressed -= Rotate;
    }
}
