using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    float limitTimer;
    float maxtime = 10;
    public TextMeshProUGUI TimerText;
    public Image hpGauge;
    public UnityChanController unityChanContorller;
    public Manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //unityChanContorller = GetComponent<UnityChanContorller>();
    
    }

    void Update()
    {       
     HpGauge();
    }


    // Update is called once per frame
    public void HpGauge()
    {
        if (unityChanContorller.isMove == true)
        {
            limitTimer -= Time.deltaTime;
            if (limitTimer < 0)
            {
                limitTimer = 0;
                TimerText.text = "0";
                if (manager != null)
                {
                    // manager.Resule(); // ← Manager に通知
                }
                unityChanContorller.isMove = false;
                return;
            }
            TimerText.text = limitTimer.ToString("F0");

            hpGauge.fillAmount =limitTimer/maxtime;
        }
        Debug.Log("Timer呼び出し");
    }
    public void ResetTimer()
    {
        limitTimer = 10f;
        TimerText.text = limitTimer.ToString("F0");
        hpGauge.fillAmount = 1f;
        
    }
    
}
