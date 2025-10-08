using UnityEngine;
using DG.Tweening;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class LifePanel : MonoBehaviour
{
    public GameObject[] icons;
    public static LifePanel instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    public void UpdateLife(int life)
    {
        life--;
        for (int i = 0; i < icons.Length; i++)
            if (i < life) icons[i].SetActive(true);
            else
            {
                SpriteRenderer sr = icons[i].GetComponent<SpriteRenderer>();
                icons[i].SetActive(false);
                sr.DOFade(0f, 1.0f).SetEase(Ease.OutBounce);
            }

    }
}
