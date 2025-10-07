using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class TextMov : MonoBehaviour
{
    public TextMeshProUGUI readyTxt;
    public GameObject Panel;
    public CanvasGroup canPanel;

    public void Start()
    {
        readyTxt = GetComponentInChildren<TextMeshProUGUI>();
        readyTxt.text="msg";
        FadeIn();
        FadeOut();
    }
    void FadeIn()
    {
        canPanel.alpha = 0f;
        canPanel.DOFade(1, 1);
    }
    void FadeOut()
    {
        canPanel.alpha = 0.5f;
        canPanel.DOFade(0, 1.0f);
    } 
}
