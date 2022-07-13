using System;
using UnityEngine;

public class EventSystem
{
    public static event Action ControlChanged;
    public static event Action ShotButtonPressed;
    public static event Action MotionButtonPressed;
    public static event Action<Vector3> RotationButtonPressed;

    public static event Action PlayerDied;
    public static event Action PlayerLost;
    public static event Action UFODestroyed;
    public static event Action AsteroidDestroyed;
    public static event Action<int> EnemyDestroyed;
    
    

    public static void OnControlChanged()
    {
        ControlChanged?.Invoke();
    }

    public static void OnShotButtonPressed()
    {
        ShotButtonPressed?.Invoke();
    }

    public static void OnMotionButtonPressed()
    {
        MotionButtonPressed?.Invoke();
    }

    public static void OnRotationButtonPressed(Vector3 directionRotation)
    {
        RotationButtonPressed?.Invoke(directionRotation);
    }

    public static void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }

    public static void OnPlayerLost()
    {
        PlayerLost?.Invoke();
    }

    public static void OnUFODestroyed()
    {
        UFODestroyed?.Invoke();
    }
    public static void OnAsteroidDestroyed()
    {
        AsteroidDestroyed?.Invoke();
    }

    public static void OnEnemyDestroyed(int score)
    {
        EnemyDestroyed?.Invoke(score);
    }

}