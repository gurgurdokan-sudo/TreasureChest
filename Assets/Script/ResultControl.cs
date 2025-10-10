using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //まだscoreの仕組みができていないから仮置き。
        //やる場合は PlayerPrefs.SetInt("score");
        scoreText.text = PlayerPrefs.GetInt("score") + "score";


    }

    // Update is called once per frame
    void Update()
    {

    }
}
/*
 if (PlayerPrefs.GetInt("HightScore") < score)
        {
            PlayerPrefs.SetInt("HightScore", score);
        }
        else
        {
            PlayerPrefs.SetInt("score", score);
        }
    }
*/
