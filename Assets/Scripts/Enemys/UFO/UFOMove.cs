using UnityEngine;

public class UFOMove : MonoBehaviour
{
    private float _speed;
    private float _timeMovement=10f;
    private Vector3 destinationPoint;

    private float halfScreenSize;

    private bool _crutch=false;

    private void Start()
    {
         halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;
        _speed = (halfScreenSize * 2) / _timeMovement;
    }

    private void OnEnable()
    {
        _crutch = false;
    }
    
    private void SetActive()
    {
        destinationPoint = new Vector3(-transform.position.x, transform.position.y, 0);
        _crutch = true;
    }

    private void FixedUpdate()
    {   
        if(gameObject.activeInHierarchy==true && _crutch==false)
        {
            SetActive();
        }

        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, _speed*Time.deltaTime);
    }
}