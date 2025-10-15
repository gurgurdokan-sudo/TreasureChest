using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ResultControl : MonoBehaviour
{
    public TextMeshProUGUI scorePrefab;
    public TextMeshProUGUI hightScore;
    
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
   
    void Start()
    {
        List<int>  scores = ScoreManager.Instance.ScoreList;

        hightScore.text = PlayerPrefs.GetInt("HightScore") + "score";
        
        for (int i = 0; i < scores.Count; i++)
        {
            TextMeshProUGUI scoreObj = Instantiate( scorePrefab,this.transform);
            scoreObj.text = i + 1+ ":" + scores[i] + "Score";
        }
    }

}
