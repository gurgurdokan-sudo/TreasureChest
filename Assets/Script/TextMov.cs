using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextMov : MonoBehaviour
{
    public TextMeshProUGUI readyTxt;
    public GameObject Panel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Panel.transform.DOFade(0, 0).
        readyTxt = GetComponent<TextMeshProUGUI>();

        readyTxt.DOFade(0, 0);
        DOTweenT
    }

    public void SettingPanel() {
        Panel.SetActive(true);
    }
}
