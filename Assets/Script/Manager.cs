using UnityEngine;
using TMPro;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Collections;

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
    /*flog　ゲームの進行を制御するための処理　両方False待機、testOKがtrueの時に進行する*/
    public bool testOk = false;
    public bool testNg = false;
    int gameLevle = 1;
    int life = 3;
    bool flag = false;
    enum gameStep
    {
        gameStart, witeForPlayerSelct, gameResult, levelCompeete
    }
    gameStep currentGameStep = 0;
    void Start()
    {
        readyTxt = canPanel.GetComponentInChildren<TextMeshProUGUI>();
        unityChanContorller = unityChanTransform.GetComponent<UnityChanContorller>();
        unityChanContorller.isMove = false;
        readyTxt.text = "Strat";
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
    void SingleLidMove(bool ng)
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendInterval(1.0f);
        if (ng)
        {
            sqe.AppendCallback(() => FullOpen());
            sqe.AppendInterval(1.0f);
        }
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
                currentGameStep=gameStep.witeForPlayerSelct;
                break;
            case gameStep.witeForPlayerSelct:
                witeForPlayerSelct();
                break;
            case gameStep.gameResult:
                Resule();
                break;
            case gameStep.levelCompeete:
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
        sqe.AppendCallback(() => chestTest.ShuffleRandomSelect());
        sqe.AppendInterval(5.0f);
        sqe.AppendCallback(() => {  unityChanContorller.isMove = true; });
        sqe.Play();
    }
    void witeForPlayerSelct()
    {
        Sequence seq = DOTween.Sequence();
        if (!testOk && !testNg) return;    //両方選択されずに待機状態
        else if (testOk || testNg)
        {
            bool f = testNg;
            if (testNg)
            {
                life--;
                readyTxt.text = "NG Chast";
                seq.AppendCallback(() => LifePanel.instance.UpdateLife(life));
                testNg = false;
            }//unityちゃんが不正解を選んだ時
            else if (testOk)
            {
                if (gameLevle < 3) gameLevle++;
                readyTxt.text = "Great!";
                Debug.Log("life ");
                testOk = false;
            }
            currentGameStep=gameStep.gameResult;
            SingleLidMove(f);
            seq.OnComplete(() => flag = true);
        }
        seq.Play();
    }

    void Resule()
    {
        testOk = false; testOk = false;
        if (!flag) return;
        if (unityChanContorller.isMove) unityChanTransform.position = syoki;
        unityChanContorller.isMove = false;
        //Levelのカウントアップ/スコア
        if (life > 0) currentGameStep = gameStep.gameStart;//もう一度ゲームステップ
        else currentGameStep=gameStep.levelCompeete;
        flag = false;
    }
    void GameOver()
    {
        Debug.Log("gameover");
    }
}

