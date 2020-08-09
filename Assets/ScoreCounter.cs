using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    private GameObject scoreText;
    void Start()
    {
        score = 0;
        this.scoreText = GameObject.Find("Score");
    }
    void Update()
    {
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
        this.scoreText.GetComponent<Text>().text = score.ToString();
    }
}