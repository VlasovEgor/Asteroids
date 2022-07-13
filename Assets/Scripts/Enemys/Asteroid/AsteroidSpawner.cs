using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public int NumberAsteroids { get; set; } = 2;

    [SerializeField] private Asteroid _largeAsteroidPrefabs;
    [SerializeField] private float _distanceAppearanceToEdgeX = 0.9f;
    [SerializeField] private float _distanceAppearanceToEdgeY = 0.9f;

    [SerializeField] private bool _autoExpand = false;

    private float halfScreenSize;
    private  PoolMono<Asteroid> _pool;

    void Start()
    {
        halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;

        _pool = new PoolMono<Asteroid>(_largeAsteroidPrefabs, NumberAsteroids, transform);
        _pool.AutoExpand = _autoExpand;

        for (int i = 0; i < NumberAsteroids; i++)
        {
            CreateAsteroids();
        }
    }

    public void CreateAsteroids()
    {
        var asteroid = _pool.GetFreeElement();

        Vector3 spawnPosition = AsteroidSpawnPosition();
        asteroid.gameObject.transform.position = spawnPosition;
    }

   private Vector3 AsteroidSpawnPosition()
   {
        Vector3 spawnPosition;

        float[] _boundariesX = { -halfScreenSize* _distanceAppearanceToEdgeX, halfScreenSize* _distanceAppearanceToEdgeX };
        float _boundariesY = halfScreenSize* _distanceAppearanceToEdgeY;

        float positionX = _boundariesX[Random.Range(0, _boundariesX.Length)];
        float positionY = Random.Range(-_boundariesY, _boundariesY);

        spawnPosition = new Vector3(positionX, positionY, 0);

        return spawnPosition;
   }


    
}
