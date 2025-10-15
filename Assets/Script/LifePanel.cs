using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    public static LifePanel instance { get; private set; }
    public int life;
    const int maxLife = 3;
    public Image[] icons;
    void Awake()
    {
        life = maxLife;
        instance = this;
    }
    public void UpdateLife()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i == this.life) //lifeは1～3
            {
                life -= 1;
                icons[i].DOFade(0f, 1.0f).SetEase(Ease.OutBounce);
            }
        }
    }
}
