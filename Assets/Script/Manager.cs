using UnityEngine;
using TMPro;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public static Manager Instance;//シーンをまたいでscoreを渡せないのでシングルトンにしています

    public Transform unityChanTransform;
    UnityChanContorller unityChanContorller;
    Vector3 syoki = new Vector3(0, 0.52f, -6.0f);
    public CanvasGroup canPanel;
    TextMeshProUGUI readyTxt;
    // public TextMeshProUGUI scoreText;
    public BoxOpen[] boxOpens;//各Chest
    public ChestTest chestTest;//シャッフル
    int gameLevle = 1;
    int life = 3;
    public int score = 0;
    public List<int> ScoreList = new List<int>();

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




    enum gameStep
    {
        gameStart, waitForPlayerSelct, gameResult, levelCompeete
    }
    gameStep currentGameStep;
    public enum player
    {
        selectNone, correct, incorrect
    }
    public player currentPlayer;
    void Start()
    {
        readyTxt = canPanel.GetComponentInChildren<TextMeshProUGUI>();
        unityChanContorller = unityChanTransform.GetComponent<UnityChanContorller>();
        unityChanContorller.isMove = false;
        readyTxt.text = "Strat";
        currentGameStep = gameStep.gameStart;
        currentPlayer = player.selectNone;
    }
    void FullOpen()
    {
        for (int i = 0; i < boxOpens.Length; i++)
        {
            boxOpens[i].Open();
        }
    }
    void FullClose()
    {
        for (int i = 0; i < boxOpens.Length; i++)
        {
            boxOpens[i].Close();
        }
    }
    void SingleLidMove()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendInterval(1.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.Play();
    }
    Sequence FadeIn()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(canPanel.DOFade(1, 1.0f));
        seq.Append(canPanel.DOFade(0, 1.0f));
        return seq;
    }


    void Update()
    {
        switch (currentGameStep)
        {
            case gameStep.gameStart:
                unityChanContorller.isMove = false;
                GameStart();
                currentGameStep = gameStep.waitForPlayerSelct;
                break;
            case gameStep.waitForPlayerSelct:
                WaitForPlayerSelct();
                break;
            case gameStep.gameResult:
                Resule();
                break;
            case gameStep.levelCompeete:
                ScoreSort(score);

                GameOver();
                //すべてのゲームを完了sendScene?
                break;
        }
//--------注意デバック用--------
 if (Input.GetKeyDown(KeyCode.O))
        {
           
         currentGameStep = gameStep.levelCompeete;
        }

    }
    void GameStart()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.Append(FadeIn());
        sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(3.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.AppendInterval(3.0f);
        sqe.AppendCallback(() => chestTest.ShuffleRandomSelect());
        sqe.AppendInterval(5.0f);
        sqe.AppendCallback(() => { unityChanContorller.isMove = true; });
        sqe.Play();
    }
    void WaitForPlayerSelct()
    {
        if (currentPlayer == player.selectNone) return;//両方選択されずに待機状態
        if (currentPlayer == player.correct)
        {
            if (gameLevle < 3) gameLevle++;
            readyTxt.text = "Great!";
            // SingleLidMove(false);
            score++;
            Debug.Log(score + "メソッド内++位置");
            currentGameStep = gameStep.gameResult;
        }
        if (currentPlayer == player.incorrect)
        {
            SingleLidMove();
            life--;
            LifePanel.instance.UpdateLife(life);
            readyTxt.text = "NG Chast";
            currentGameStep = gameStep.gameResult;

        }
    }
    void Resule()
    {
        if (currentPlayer == player.incorrect || currentPlayer == player.correct)
        {
            unityChanTransform.position = syoki;
            unityChanContorller.isMove = false;
            currentPlayer = player.selectNone;
        }
        //Levelのカウントアップ/スコア
        if (life > 0) currentGameStep = gameStep.gameStart;//もう一度ゲームステップ
        else currentGameStep = gameStep.levelCompeete;
    }
    void GameOver()
    {
        Debug.Log("gameover");
        SceneManager.LoadScene("Result");
    }

    void ScoreSort(int score)
    {
        if (PlayerPrefs.GetInt("HightScore") < score)
        {
            PlayerPrefs.SetInt("HightScore", score);
            ScoreList.Insert(0, score);
            Debug.Log(score + "ハイスコア判定内");
            Debug.Log(ScoreList[0]);
        }
        else
        {
            ScoreList.Add(score);
            ScoreList.Sort((a, b) => b.CompareTo(a));
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



