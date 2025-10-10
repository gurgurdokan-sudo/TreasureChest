using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour
{
    public Image[] icons;
    public static LifePanel instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    public void UpdateLife(int life)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i== life) //lifeは1～3
             icons[i].DOFade(0f, 1.0f).SetEase(Ease.OutBounce);
        }
    }
}
