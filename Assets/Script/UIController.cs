using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    float limitTimer;
    const float maxtime = 10;
    public Image hpGauge;
    TextMeshProUGUI timerText;
    public Manager manager;
    public TextMeshProUGUI scoreText;
    bool flge=false;
    void Start()
    {
        limitTimer = maxtime;
        timerText = hpGauge.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Initialize()
    {
        limitTimer = maxtime;
        timerText.text = limitTimer.ToString("F0");
        hpGauge.fillAmount = 1f;
        flge = false;
    }

    void Update()
    {
        if (manager.flag)
        {
            limitTimer -= Time.deltaTime;
            if (limitTimer < 0)
            {
                limitTimer = 0;
                timerText.text = "0";
                if (manager != null)
                {
                    
                    manager.currentPlayer = Manager.player.incorrect;
                }
                return;
            }
            timerText.text = limitTimer.ToString("F0");

            hpGauge.fillAmount = limitTimer / maxtime;
        }
        if (manager.currentGameStep == Manager.gameStep.gameRelode)
        {
            Initialize();
            ScoreTextUp(ScoreManager.Instance.totalScore);
        }
    }
    void ScoreTextUp(int score)
    {
        
        scoreText.text = "Score: "+score;
    }
}
