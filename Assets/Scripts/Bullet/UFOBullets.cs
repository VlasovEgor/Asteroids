
public class UFOBullets : Bullets
{   
    private void OnEnable() // ���: ������� ���� ���������� ����������� �����������
    {
        _motionVector = _player.position;
        StartCoroutine("LifeRoutine");
    }
}
