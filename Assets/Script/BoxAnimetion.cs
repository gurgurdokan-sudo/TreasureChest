using UnityEngine;
using DG.Tweening;

public class BoxAnimetion : MonoBehaviour
{

    public bool isChest=false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DamegeAction();
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void DamegeAction()
    {
        if (!isChest)
        {
            
          transform.DOShakePosition(0.5f, 1f, 45, 1, false, true);
        }
    }
}
