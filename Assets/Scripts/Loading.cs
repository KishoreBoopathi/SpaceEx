using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider;
    
    public Text num;
    // Start is called before the first frame update
    void Start()
    {
        

        LoadLevel("Level1");
    }

   public void LoadLevel(string level)
    {
        StartCoroutine(LoadAsync(level));
    }
    IEnumerator LoadAsync(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            num.text = (progress * 100).ToString("F0") + "%";
            yield return null;
        }
    }
}

