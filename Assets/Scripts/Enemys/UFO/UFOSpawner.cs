using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    
    [SerializeField] private UFO _ufoPrefabs;
    [SerializeField] private float _minTimeUfo=20f;
    [SerializeField] private float _maxTimeUfo=40f;
    [SerializeField] private float _distanceAppearanceToEdgeY=0.8f;
    
    private float _timeUntilNextAppearanceUFO;

    private float halfScreenSize;
    private float _timer;
    private bool _ufosExist=false;

    [SerializeField] private protected int _ufoCount = 10;
    [SerializeField] private protected bool _autoExpand = false;

    private protected PoolMono<UFO> _pool;

    private void Start()
    {
        _timeUntilNextAppearanceUFO = Random.Range(_minTimeUfo, _maxTimeUfo);
        halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;
        EventSystem.UFODestroyed += UfoDestroyed;

        _pool = new PoolMono<UFO>(_ufoPrefabs, _ufoCount, transform);
        _pool.AutoExpand = _autoExpand;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        VerificationForCreation();
    }

    private void VerificationForCreation()
    {
        if (_timer >= _timeUntilNextAppearanceUFO && _ufosExist==false)
        {
            CreateUFO();
            _timeUntilNextAppearanceUFO = Random.Range(_minTimeUfo, _maxTimeUfo);
            _ufosExist = true;
        }
    }

    private void CreateUFO()
    {
        float[] _boundariesX= { -halfScreenSize, halfScreenSize } ;
        float _boundariesY = halfScreenSize* _distanceAppearanceToEdgeY;

        float positionX = _boundariesX[Random.Range(0, _boundariesX.Length)]; 
        float positionY= Random.Range(-_boundariesY, _boundariesY);

        var ufo = _pool.GetFreeElement();
        
        Vector3 spawnPosition = new Vector3(positionX, positionY,0);
        ufo.gameObject.transform.position = spawnPosition;
    }

    private void UfoDestroyed()
    {
        _ufosExist = false;
        _timer = 0;
    }

    private void OnDestroy()
    {
        EventSystem.UFODestroyed -= UfoDestroyed;
    }
}