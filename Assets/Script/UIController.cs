using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    float limitTimer = 10;
    float maxtime = 10;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;
    public Image hpGauge;
    public Manager manager;
    public RectTransform itemPanel;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (manager.flag)
        {
            limitTimer -= Time.deltaTime;
            itemPanel.DOMoveY(60f, 0.3f);
            hpGauge.GetComponent<RectTransform>().DOMoveY(60f,0.3f);
            if (limitTimer < 0)
            {
                limitTimer = 0;
                TimerText.text = "0";
                manager.currentPlayer = Manager.player.incorrect;
                return;
            }
        }
        if (!manager.flag)
        {
            Initialize();
            manager.time = limitTimer;
            Debug.Log(manager.time);
            itemPanel.DOMoveY(-60f, 0.3f);
            hpGauge.GetComponent<RectTransform>().DOMoveY(-60f,0.3f);
        }
        TimerText.text = limitTimer.ToString("F0");
        hpGauge.fillAmount = limitTimer / maxtime;
        ScoreText.text = "Score:" + ScoreManager.Instance.totalScore + "    level :" + manager.gameLevle;
    }
    public void Initialize()
    {
        limitTimer = maxtime;
        TimerText.text = limitTimer.ToString("F0");
        hpGauge.fillAmount = 1f;
    }

}
