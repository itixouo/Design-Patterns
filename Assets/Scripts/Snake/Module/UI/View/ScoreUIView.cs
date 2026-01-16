using TMPro;
using UnityEngine;

public class ScoreUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void SetScore(int score)
    {
        scoreText.text = $"score: {score}";
    }
}
