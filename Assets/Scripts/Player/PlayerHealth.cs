using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthCount _healthCount;

    private void Start()
    {
        _healthCount.Setup(_maxHealth);
    }

    public void TakeDamage(int damagaValue)
    {
        _health -= damagaValue;
        _healthCount.DisplayHealth(_health);
        Die();

        if (_health<=0)
        {
            Loss();
        } 
    }

    private void Die()
    {
        EventSystem.OnPlayerDied();
    }

    private void Loss()
    {
        EventSystem.OnPlayerLost();
        gameObject.SetActive(false);
    }
}
