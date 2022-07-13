
public class PlayerBullets : Bullets
{
    private void OnEnable()
    {
        _motionVector = _player.up.normalized;
        StartCoroutine("LifeRoutine");
    }
}
