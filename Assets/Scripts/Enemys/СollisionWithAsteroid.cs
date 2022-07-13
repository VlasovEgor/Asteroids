using UnityEngine;

public class СollisionWithAsteroid : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            EventSystem.OnEnemyDestroyed(gameObject.GetComponent<Asteroid>().GetPoints());
            EventSystem.OnAsteroidDestroyed();
            gameObject.SetActive(false);
        }

        if (collision.gameObject.GetComponent<UFO>())
        {
            collision.gameObject.SetActive(false);
            EventSystem.OnAsteroidDestroyed();
            gameObject.SetActive(false);
        }
    }
}
