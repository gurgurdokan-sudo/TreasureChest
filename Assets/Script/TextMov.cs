using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextMov : MonoBehaviour
{
    public TextMeshProUGUI readyTxt;
    public GameObject Panel;
    public CanvasGroup canPanel;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeIn();
        FadeOut();
    }
    public void FadeIn()
    {
        canPanel.alpha = 0f;
        canPanel.DOFade(1, 3);
    }



    public void FadeOut()
    {
        canPanel.alpha = 1f;
        canPanel.DOFade(0, 3);

    }
}
