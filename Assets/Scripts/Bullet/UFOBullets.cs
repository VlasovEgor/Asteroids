
public class UFOBullets : Bullets
{   
    private void OnEnable() // баг: текущая пуля пользуется устарейвшей информацией
    {
        _motionVector = _player.position;
        StartCoroutine("LifeRoutine");
    }
}
