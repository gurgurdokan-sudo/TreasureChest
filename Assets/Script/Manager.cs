using UnityEngine;
using TMPro;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Data.Common;

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
    public int life = 3;
    int gameLevle = 1;
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


        /*
            if (boxOpens[i].IsOpen())
            {
                if (testNg)
                {
                    Debug.Log(boxOpens[i] + "2");//Ok
                                                 // Debug.Break();//発生していない

                    //動かす対象が見つかっていない
                    boxOpens[i].transform.DOShakePosition(0.5f, 1f, 90, 1, false, true).OnComplete(() => Debug.Log("Shake Done"));

                }
            }
*/
            boxOpens[i].Close();//Ok
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
                readyTxt.text = "Strat";
                GameStart();
                currentGameStep++;
                break;
            case gameStep.witeForPlayerSelct:
                // unityChanContorller.isMove = true;
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
        sqe.AppendInterval(2.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.AppendInterval(2.0f);
        sqe.AppendCallback(() => { chestTest.ShuffleRandomSelect(); unityChanContorller.isMove = true; });
        sqe.Play();
    }
    void witeForPlayerSelct()
    {
        Sequence seq = DOTween.Sequence();
        if (!testOk && !testNg) return;    //両方選択されずに待機状態
        else if (testOk || testNg)
        {
            bool flag = true;
            if (testNg && flag)//unityちゃんが不正解を選んだ時
            {
                readyTxt.text = "NG Chast";
                seq.AppendCallback(() => LifePanel.instance.UpdateLife(life--));
                flag = false;
            }
            else if (testOk)
            {
                if (gameLevle < 3) seq.AppendCallback(() => gameLevle++);
                readyTxt.text = "Great!";
                Debug.Log("life :" + life);
            }
            seq.Append(FadeIn());
        }
        seq.AppendCallback(() => { SingleLidMove(testNg); });
        seq.OnComplete(() => { currentGameStep++; testOk = false; testOk = false; });//初期化
        seq.Play();
    }
    void Resule()
    {
        if (unityChanContorller.isMove) unityChanTransform.position = syoki;
        unityChanContorller.isMove = false;
        //Levelのカウントアップ/スコア
        if (life > 0) currentGameStep = gameStep.gameStart;//もう一度ゲームステップ
        else currentGameStep = gameStep.levelCompeete;
    }
    void GameOver()
    {
        Debug.Log("gameover");
    }
}

