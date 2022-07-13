using UnityEngine;

public class UFOShooting : Shooting
{
    private float _frequencyShotUFO;

    private void Awake()
    {
        _frequencyShotUFO = Random.Range(2f, 5f);
    }

    protected override void Start()
    {
        base.Start();
        _firingFrequency = _frequencyShotUFO;
    }

    protected override void Update()
    {
        base.Update();
        CheckingForPossibilityShot();

    }

    protected override void CheckingForPossibilityShot()
    {
        if (_timer >= _firingFrequency)
        {
            CreateBullet();
            _timer = 0;
        }
    }
}
