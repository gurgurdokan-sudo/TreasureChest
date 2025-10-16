using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    float limitTimer = 10;
    float maxtime = 10;
    public TextMeshProUGUI TimerText;
    public Image hpGauge;
    public Manager manager;
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        if (manager.flag)
        {
            limitTimer -= Time.deltaTime;
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
        }
        TimerText.text = limitTimer.ToString("F0");
        hpGauge.fillAmount = limitTimer / maxtime;
    }
    public void Initialize()
    {
        limitTimer = maxtime;
        TimerText.text = limitTimer.ToString("F0");
        hpGauge.fillAmount = 1f;
    }

}
