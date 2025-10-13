using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ResultControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hightScore;
    //List<Manager> managers = new List<Manager>();

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var scores = Manager.Instance.ScoreList;

        hightScore.text = PlayerPrefs.GetInt("HightScore") + "score";
        //まだscoreの仕組みができていないから仮置き。
        //やる場合は PlayerPrefs.SetInt("score");
        for (int i = 0; i < scores.Count; i++)
        {
            if (i < scores.Count)
            {
                scoreText.text = (i + 1) + "位: " + scores[i].ToString();
            }
            else
            {
                scoreText.text = (i + 1) + "位: ---";
            }

          //  scoreText.text = i + 1 + "位" + scores[i] + "Score";

        }

        //scoreText.text = PlayerPrefs.GetInt("score") + "score";



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
