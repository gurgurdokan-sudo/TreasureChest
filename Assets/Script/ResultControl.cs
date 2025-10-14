using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResultControl : MonoBehaviour
{
    public TextMeshProUGUI scorePrefab;
    public Transform scoreParent;

    // Text[] scoreText;
    public TextMeshProUGUI hightScore;
    

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
   
    void Start()
    {
        var scores = ScoreManager.Instance.ScoreList;

        hightScore.text = PlayerPrefs.GetInt("HightScore") + "score";
        
        for (int i = 0; i < scores.Count; i++)
        {

          var scoreObj = Instantiate(scorePrefab, scoreParent);
            scoreObj.text = i + 1+ ":" + scores[i] + "Score";



        }

        //scoreText.text = PlayerPrefs.GetInt("score") + "score";



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
