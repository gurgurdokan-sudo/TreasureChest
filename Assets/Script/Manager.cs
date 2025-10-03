using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;

public class manager : MonoBehaviour
{
    public UnityController un;
    public TextMeshProUGUI scoreText;

    public BoxController[] boxColl;
    public ChestTest chestTest;


    //un open
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        boxColl = boxColl[0].GetComponent<BoxController[]>();

        chestTest = chestTest.GetComponent<ChestTest>();



        // isFlag = boxColl.GetIsOpen();



    }

    public bool maneg()
    {
        for (int i = 0; i < boxColl.Length; i++)
        {
            if (boxColl[i].GetIsOpen())
            {
                return true;
            }
        }
        return false;
    }
    void openFull()
    {
        for (int i = 0; i < boxColl.Length; i++)
        {
            boxColl[i].Open();
        }

    }
     void closeFull()
    {
        for (int i = 0; i < boxColl.Length; i++)
        {
            boxColl[i].Close();
        }

    }
    // Update is called once per frame
    void Update()
    {

        Game();

    }

    void Game()
    {
        openFull();
        closeFull();
        chestTest.lotation();
        if (!maneg())
        {
            openFull();
        }
        else
        {
            Debug.Log("true");
        }
        

    

    }
    
}
