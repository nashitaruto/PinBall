using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
    }
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            FindObjectOfType<ScoreCounter>().AddPoint(1);
        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            FindObjectOfType<ScoreCounter>().AddPoint(5);
        }
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            FindObjectOfType<ScoreCounter>().AddPoint(3);
        }
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            FindObjectOfType<ScoreCounter>().AddPoint(10);
        }
    }
}