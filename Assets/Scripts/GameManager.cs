using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float score;
     public int wave;
    GameObject scoreBored;
    GameObject waveCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreBored = GameObject.Find("Scores");
        waveCount = GameObject.Find("Waves");
    }

    // Update is called once per frame
    void Update()
    {
        Count();
        SaveScore();
    }
    void Count()
    {
        score += 1 * Time.deltaTime;

        scoreBored.GetComponent<Text>().text = "Score: " + score.ToString("F0000000000");
        waveCount.GetComponent<Text>().text = "Wave: " + wave;
    }

    public void SaveScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore");
        if(highScore.Equals(null)||(highScore < score))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

    }

    public void GainPoints(float points)
    {
        score = score + points;
    }
}
