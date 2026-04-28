using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    public GameObject Menu;
    public GameObject options;
    public Text highScore;

    // Start is called before the first frame update
    public void Start()
    {
        highScore = GameObject.Find("HighScore").GetComponent<Text>();
        SetHighScore();
    }

    public void SetHighScore()
    {
        if (highScore == null)
        {
            return;
        }
        else
        {
        float highSc = PlayerPrefs.GetFloat("HighScore");
        if (highSc.Equals(null))
        {
            highScore.text = "0";
        }
        else
        {
            highScore.text = highSc.ToString("F0");
        }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGmae ()
    {
        Application.Quit();
    }
    public void LoadMainMenuScene()
    {

        SceneManager.LoadScene("Menu");
    }
    public void Options()
    {
        //Turn off gameobject Mainmenu, turn on options (panel)
        Menu.SetActive(false);
        options.SetActive(true);
    }
}
