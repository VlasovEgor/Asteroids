using UnityEngine;

public class DealingDamageEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {  

        if (collision.gameObject.GetComponent<UFO>())
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            EventSystem.OnEnemyDestroyed(collision.gameObject.GetComponent<UFO>().GetPoints());
            EventSystem.OnUFODestroyed();
        }

        if(collision.gameObject.GetComponent<Asteroid>())
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

            if(collision.gameObject.GetComponent<LargeAndMiddleAsteroids>())
            {
                collision.gameObject.GetComponent<LargeAndMiddleAsteroids>().SplitAsteroids();
            }
            EventSystem.OnAsteroidDestroyed();
            EventSystem.OnEnemyDestroyed(collision.gameObject.GetComponent<Asteroid>().GetPoints());
        }
    }
}
