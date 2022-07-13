using UnityEngine;

public class DealingDamagePlayer : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            gameObject.SetActive(false);
        }
    }
   
}
