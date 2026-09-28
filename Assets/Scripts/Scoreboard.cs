using UnityEngine;
using TMPro;


public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreUI;

    private int score;

    public void AddScore(int amount)
    {
        score = score + amount;
        ScoreUI.text = score.ToString();
        Debug.Log(score);
    }
}
