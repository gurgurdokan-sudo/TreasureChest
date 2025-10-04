using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.TerrainTools;
using NUnit.Framework;
using System.Xml.Serialization;

public class Manager : MonoBehaviour
{
    public CharacterController unityChanContorller;
    public TextMeshProUGUI scoreText;
    public BoxOpen[] boxColltroller;
    public ChestTest chestTest;//シャッフル

    /*flog*/
    public bool testOk=false;
    public bool testNg=false;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        chestTest = chestTest.GetComponent<ChestTest>();
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
    void openFull()
    {
        for (int i = 0; i < boxColltroller.Length; i++)
        {
            boxColltroller[i].Open();
        }
    }
    void closeFull()
    {
        for (int i = 0; i < boxColltroller.Length; i++)
        {
            boxColltroller[i].Close();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Game();
        }

    }

    void Game()
    {
        openFull();
        closeFull();
        chestTest.ShuffleRandomSelect();

        /*Rayが打たれて*/
        if (!maneg()) openFull();
        else Debug.Log("true");

    }

}
