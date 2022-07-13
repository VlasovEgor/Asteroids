using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    [SerializeField] private Text _loseText;
    void Start()
    {
        EventSystem.PlayerLost += PrintTextAboutLoss;
    }

    private void PrintTextAboutLoss()
    {
        _loseText.enabled = true;
    }

    private void OnDestroy()
    {
        EventSystem.PlayerLost -= PrintTextAboutLoss;
    }
}
