using UnityEngine;

public  class PlayerShooting : Shooting
{
    [SerializeField] private float _frequencyShotPlayer;

    protected override void Start()
    {
        base.Start();
        _firingFrequency = _frequencyShotPlayer;
        EventSystem.ShotButtonPressed += CheckingForPossibilityShot;
    }

    protected override void CheckingForPossibilityShot()
    {
        if (_timer >= _firingFrequency)
        {
            CreateBullet();
            _timer = 0;
        }
    }

    private void OnDestroy()
    {
        EventSystem.ShotButtonPressed -= CheckingForPossibilityShot;
    }
}
