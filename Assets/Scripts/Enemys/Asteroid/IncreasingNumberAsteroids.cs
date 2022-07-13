using System.Collections.Generic;
using UnityEngine;

public class IncreasingNumberAsteroids : MonoBehaviour
{
    //то что ниже лучше не смотреть, тут можно было сделать эффективней и аккуратней, но время поджимает

    public List<Asteroid> ListAllAsteroid = new List<Asteroid>();

    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private int _timeUntilNewAsteroidsAppear = 2;

    private bool _asteroidsOff;
    

    private void Start()
    {
        EventSystem.AsteroidDestroyed += CheckingAsteroidsOnScene;
    }

    private void CheckingAsteroidsOnScene()
    {
        for (int i = 0; i < ListAllAsteroid.Count; i++)
        {
            if (ListAllAsteroid[i].isActiveAndEnabled == false)
            {
                _asteroidsOff = true;
            }
            else
            {
                _asteroidsOff = false;
                break;
            }
        }

        if (_asteroidsOff == true)
        {
            Invoke("CreateNewAsteroids", _timeUntilNewAsteroidsAppear);
        }
    }

    private void CreateNewAsteroids()
    {
        _asteroidSpawner.NumberAsteroids++;

        for (int i = 0; i < _asteroidSpawner.NumberAsteroids; i++)
        {
            _asteroidSpawner.CreateAsteroids();
        }
    }

    private void OnDestroy()
    {
        EventSystem.AsteroidDestroyed -= CheckingAsteroidsOnScene;
    }
}
