using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEditor.ShaderGraph;
using System.Collections;

public class TextMov : MonoBehaviour
{
    public TextMeshProUGUI readyTxt;
    public GameObject Panel;
    public CanvasGroup canPanel;
    string msg;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
   


    void Start()
    {
        readyTxt = GetComponentInChildren<TextMeshProUGUI>();
        msg = readyTxt.text;
        FadeIn();
        FadeOut();
    }
    public void FadeIn()
    {

        canPanel.alpha = 0f;
        canPanel.DOFade(1, 1);
    }



    public void FadeOut()
    {

        canPanel.alpha = 0.5f;
        canPanel.DOFade(0, 1.0f);

    }
    

    
}
