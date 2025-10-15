using System.Collections.Generic;
using UnityEngine;
//---------シングルトンクラス------------

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public List<int> ScoreList = new List<int>();
    public int totalScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも残す
        }
    }

    public void ScoreSort()
    {
        ScoreList.Add(totalScore);
        ScoreList.Sort((a, b) => b.CompareTo(a));
        if (ScoreList.Count > 5)
        {//listが５以下なら消去
            ScoreList.RemoveRange(5, ScoreList.Count - 5);
        }
        if (PlayerPrefs.GetInt("HightScore") < totalScore)
        {//ハイスコアを上回るなら上書き　
            PlayerPrefs.SetInt("HightScore", totalScore);
        }
    }
}
