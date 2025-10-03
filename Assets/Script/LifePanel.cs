using UnityEngine;
using DG.Tweening;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class LifePanel : MonoBehaviour
{
    public GameObject[] icons;
    public bool test = true;

    
  
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.A))
        {
            int a = Random.Range(0, 4);
            Debug.Log(a);
            UpdateLife(a);
            Debug.Log("input");
        }
    }

    public void UpdateLife(int life)
    {
        for(int i=0;i<icons.Length;i++)
         if (i < life)
        {
            icons[i].SetActive(true);

        }
        else
        {
   
        SpriteRenderer sr = icons[i].GetComponent<SpriteRenderer>();

        icons[i].SetActive(false);
        sr.DOFade(0f, 1.0f).SetEase(Ease.OutBounce);
        
        }

    }
}
