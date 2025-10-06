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
    public BoxOpen[] boxOpens;
    public BoxOpen box;
    public ChestTest chestTest;//シャッフル


    //仮置き真偽値
   public bool isCheck=false;
    /*flog　ゲームの進行を制御するための処理　両方False待機、testOKがtrueの時に進行する*/
    public bool testOk = false;//開けた処理後の
    public bool testNg = false;

    void Start()
    {
        // SetTweensCapacity()
        scoreText = GetComponent<TextMeshProUGUI>();
        chestTest = chestTest.GetComponent<ChestTest>();
       
        BoxLidMove();
    }

    public bool maneg()
    {
        for (int i = 0; i < boxOpens.Length; i++)
        {
            if (boxOpens[i].IsOpen())
            {
                return true;
            }
        }
        return false;
    }
    void FullOpen()
    {
        for (int i = 0; i <boxOpens.Length; i++)
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


    void BoxLidMove()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(1.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.Play();

        testNg = false;
    }

    void SingleLidMove()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.AppendCallback(() => box.Open());
        sqe.AppendInterval(1.0f);
        sqe.AppendCallback(() => box.Close());
        sqe.Play();

        testOk = false;
        
    }

    void Update()
    {
        if (!testOk && !testNg) return;    //両方選択されずに待機状態
        else if (testOk && !testNg)//testOKがtureでtestNGがfalseの時(unityちゃんが正解を選んだ時)
        {
            //isCheck = box.IsOpen();
            if (isCheck)
            {
                    SingleLidMove();
            }
        }  
        else if (!testOk && testNg) BoxLidMove(); //unityちゃんが不正解を選んだ時



    }




}

