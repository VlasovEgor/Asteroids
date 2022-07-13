using UnityEngine;

public class AudioPlayback : MonoBehaviour
{
    [SerializeField] private AudioSource _fireSoundEffect;
    [SerializeField] private AudioSource _thrustSoundEffect;
    [SerializeField] private AudioSource _explosionSoundEffect;

    private void Awake()
    {
        EventSystem.MotionButtonPressed += PlayThrustSoundEffect;
        EventSystem.ShotButtonPressed += PlayFireSoundEffect;
        EventSystem.UFODestroyed += PlayExposionSoundEffect;
        EventSystem.AsteroidDestroyed += PlayExposionSoundEffect;
    }

    private void PlayThrustSoundEffect()
    {
        _thrustSoundEffect.Play();
    }

    private void PlayFireSoundEffect()
    {
        _fireSoundEffect.Play();
    }

    private void PlayExposionSoundEffect()
    {
        _explosionSoundEffect.Play();
    }

    private void OnDestroy()
    {
        EventSystem.MotionButtonPressed -= PlayThrustSoundEffect;
        EventSystem.ShotButtonPressed -= PlayFireSoundEffect;
        EventSystem.UFODestroyed -= PlayExposionSoundEffect;
        EventSystem.AsteroidDestroyed -= PlayExposionSoundEffect;
    }
}
