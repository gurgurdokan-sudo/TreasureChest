using UnityEngine;
using TMPro;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine.UIElements;
using DG.Tweening;

public class Manager : MonoBehaviour
{

    public Transform unityChanContorller;
    Vector3 syoki = new Vector3(0, 0.52f, -6.0f);
    public TextMeshProUGUI scoreText;
    public BoxOpen[] boxOpens;
    public ChestTest chestTest;//シャッフル
    /*flog　ゲームの進行を制御するための処理　両方False待機、testOKがtrueの時に進行する*/
    public bool testOk = false;//開けた処理後の
    public bool testNg = false;
    enum gameStep
    {
        gameStart, witeForPlayerSelct, gameResult ,levelCompeete
    }
    gameStep currentGameStep = 0;
    void Start()
    {
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

    void Update()
    {
        switch (currentGameStep)
        {
            case gameStep.gameStart:
                GameStart();
                currentGameStep++;
                break;
            case gameStep.witeForPlayerSelct:
                witeForPlayerSelct();
                break;
            case gameStep.gameResult:
                Resule();
                break;
            case gameStep.levelCompeete:
                //すべてのゲームを完了
                break;
        }
    }
    void GameStart()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendInterval(2.0f);
        sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(2.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.AppendCallback(() => chestTest.ShuffleRandomSelect());
        sqe.Play();
    }
    void witeForPlayerSelct()
    {
        if (!testOk && !testNg) return;    //両方選択されずに待機状態
        else if (testOk || testNg)//testOKがtureでtestNGがfalseの時(unityちゃんが正解を選んだ時)
        {
            SingleLidMove(testNg);
            currentGameStep++;
        }
        // if (testOk) Debug.Log("OK");
        // else if (testNg); //unityちゃんが不正解を選んだ時
        }
    void Resule()
    {
        //Levelのカウントアップ/スコア
    }
}

