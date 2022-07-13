using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int _count=0;

    private void Start()
    {
        EventSystem.EnemyDestroyed += IncreaseScore;
    }

    private void IncreaseScore(int score)
    {
        _count += score;
        _scoreText.text = "Ñ÷¸ò: " + _count;
    }
}
