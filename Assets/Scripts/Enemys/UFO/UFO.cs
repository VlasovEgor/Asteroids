using System.Collections;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private int _pointsForMurder;

    private float _lifeTime = 10f;

    private void OnEnable()
    {
        StartCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        
        yield return new WaitForSecondsRealtime(_lifeTime);
        gameObject.SetActive(false);
        EventSystem.OnUFODestroyed();

    }

    public int GetPoints()
    {
        return _pointsForMurder;
    }
}
