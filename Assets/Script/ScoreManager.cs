using System.Collections.Generic;
using UnityEngine;
//---------シングルトンクラス------------

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public List<int> ScoreList = new List<int>();
    int TotalScore = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも残す
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetScore(int num)
    {
        TotalScore += num;
    }
    
    public int GetScore()
    {
        return this.TotalScore;
    }

    

      public void ScoreSort(int score)
    {
        if (PlayerPrefs.GetInt("HightScore") < score)
        {
            PlayerPrefs.SetInt("HightScore", score);
            // ScoreList.Insert(0, score);
            ScoreList.Add(score);
            ScoreList.Sort((a, b) => b.CompareTo(a));
            Debug.Log(score + "ハイスコア判定内");
            Debug.Log(ScoreList[0]);
        }
        else
        {
            ScoreList.Add(score);
            ScoreList.Sort((a, b) => b.CompareTo(a));//sort
            if (ScoreList.Count > 5)
            {
                ScoreList.RemoveRange(5, ScoreList.Count - 5);
                Debug.Log(score + "ランキング処理内");
                Debug.Log(ScoreList);
            }

        }


        // PlayerPrefs.SetInt("score", score);
    }
}
