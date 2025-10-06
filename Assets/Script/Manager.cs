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
    public UnityChanContorller unityChanContorller;
    public TextMeshProUGUI scoreText;
    public BoxOpen[] boxColltroller;
    public ChestTest chestTest;//シャッフル


    /*flog　ゲームの進行を制御するための処理　両方False待機、testOKがtrueの時に進行する*/
    public bool testOk = false;//開けた処理後の
    public bool testNg = false;

    void Start()
    {

        scoreText = GetComponent<TextMeshProUGUI>();
        chestTest = chestTest.GetComponent<ChestTest>();
        BoxMove();
    }

    public bool maneg()
    {
        for (int i = 0; i < boxColltroller.Length; i++)
        {
            if (boxColltroller[i].IsOpen())
            {
                return true;
            }
        }
        return false;
    }
    void FullOpen()
    {
        for (int i = 0; i < boxColltroller.Length; i++)
        {
            boxColltroller[i].Open();
        }
    }
    void FullClose()
    {
        for (int i = 0; i < boxColltroller.Length; i++)
        {
            boxColltroller[i].Close();
        }
    }


    void Game()
    {
        // BoxMove();
        chestTest.ShuffleRandomSelect();

    }

    void BoxMove()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(1.0f);
        sqe.AppendCallback(() => FullClose());


    }

    void Update()
    {
        if (testOk && testNg) return ;    //両方選択されずに待機状態
        else if (testOk && !testNg) Debug.Log("NG");  //testOKがtureでtestNGがfalseの時(unityちゃんが正解を選んだ時)
        else if (!testOk && testNg) BoxMove(); //unityちゃんが不正解を選んだ時



    }




}

