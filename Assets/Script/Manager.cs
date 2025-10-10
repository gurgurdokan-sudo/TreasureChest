using UnityEngine;
using TMPro;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
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
    int score = 0;

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
                PlayerPrefs.GetInt("score");
                GameOver();
                //すべてのゲームを完了sendScene?
                break;
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

}

