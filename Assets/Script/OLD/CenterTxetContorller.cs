using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class TextMov : MonoBehaviour
{
    TextMeshProUGUI readyTxt;
    public CanvasGroup canPanel;

    public void MsgStart(String msg)
    {
        readyTxt = GetComponentInChildren<TextMeshProUGUI>();
        readyTxt.text=msg;
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
