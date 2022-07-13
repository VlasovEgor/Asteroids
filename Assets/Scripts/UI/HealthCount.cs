using System.Collections.Generic;
using UnityEngine;

public class HealthCount : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconPrefabs;

    private List<GameObject> _healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
          GameObject newIcon=  Instantiate(_healthIconPrefabs, transform);
          _healthIcons.Add(newIcon);
        }
    }

    public void DisplayHealth(int currentHealth)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            if(i<currentHealth)
            {
                _healthIcons[i].SetActive(true);
            }
            else
            {
                _healthIcons[i].SetActive(false);
            }
        }
    }
}
