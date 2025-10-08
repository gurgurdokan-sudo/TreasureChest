using UnityEngine;
using TMPro;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using DG.Tweening;

public class Manager : MonoBehaviour
{
    public Transform unityChanTransform;
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
    enum gameStep
    {
        gameStart, witeForPlayerSelct, gameResult, levelCompeete
    }
    gameStep currentGameStep = 0;
    void Start()
    {
        readyTxt = canPanel.GetComponentInChildren<TextMeshProUGUI>();
        // SetTweensCapacity()
        // scoreText = GetComponent<TextMeshProUGUI>();
        // chestTest = chestTest.GetComponent<ChestTest>();
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
        sqe.OnComplete(()=> { testNg = false; testOk = false; });
        sqe.Play();
    }
    void FadeIn()
    {
        canPanel.alpha = 0f;
        canPanel.DOFade(1, 1).SetLoops(1, LoopType.Incremental);
        canPanel.DOFade(0, 1.0f);
    }


    void Update()
    {
        switch (currentGameStep)
        {
            case gameStep.gameStart:
                readyTxt.text = "Strat";
                GameStart();
                currentGameStep++;
                break;
            case gameStep.witeForPlayerSelct:
                readyTxt.text = "select";
                FadeIn();
                witeForPlayerSelct();
                break;
            case gameStep.gameResult:
                Resule();
                break;
            case gameStep.levelCompeete:
                //すべてのゲームを完了sendScene?
                break;
        }
    }
    void GameStart()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendCallback(() => { FadeIn();});
        sqe.AppendInterval(3.0f);
        sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(2.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.AppendInterval(2.0f);
        sqe.AppendCallback(() => chestTest.ShuffleRandomSelect());
        sqe.OnComplete(() => { currentGameStep++; });
        sqe.Play();
    }
    void witeForPlayerSelct()
    {
        if (!testOk && !testNg) return;    //両方選択されずに待機状態
        else if (testOk || testNg)
        {
            if (testNg)
            {
                LifePanel.instance.UpdateLife();
                currentGameStep++;
            }//unityちゃんが不正解を選んだ時
            else if (testOk)
            {
                if (gameLevle > 3)
                {
                    gameLevle++;
                    currentGameStep++;
                }    
                Debug.Log(gameLevle);
            }
            SingleLidMove(testNg);
        }
    }
    void Resule()
    {
        Debug.Log("test");
        // unityChanTransform.position = syoki;
        //Levelのカウントアップ/スコア
    }
}

