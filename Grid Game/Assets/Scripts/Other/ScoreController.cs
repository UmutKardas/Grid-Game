using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private int score;



    public void SetScoreValue()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
