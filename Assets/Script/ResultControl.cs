using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ResultControl : MonoBehaviour
{
    public TextMeshProUGUI scorePrefab;
    public TextMeshProUGUI hightScore; // 命名悪くて申し訳ないですがアタッチするときはHighScoreSet
    public Transform socoreP;
    
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
            //変えるな
            //これは自身のTransfomeではなく登録されたゲームオブジェクトのTransfomを参照して
            // 自身のフォントサイズを自動的に変えるコンポーネントを使用するためのコードなので
            // 書き換えると文字サイズおかしくなるから変えないでください
            TextMeshProUGUI scoreObj = Instantiate( scorePrefab,socoreP);
            scoreObj.text = i + 1+ "位:" + scores[i] + "Score";
        }
    }

}
