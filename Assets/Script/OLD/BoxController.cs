using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;


public class BoxController : MonoBehaviour
{
    
    public Transform centerleft;
    public Transform centerright;
    public Transform[] chest;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;

        
    }

    // Update is called once per frame
    void Update()
    {

        //Turn();
        if (Input.GetKeyDown(KeyCode.F))
        {
            ParentSetLeft(chest[0], chest[1]);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ParentSetRight(chest[2], chest[1]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ExitParent(chest[0], chest[1]);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ExitParent(chest[2], chest[1]);
        }

    }
    

    void ParentSetLeft(Transform c1, Transform c2)
    {
        c1.SetParent(centerleft, true);
        c2.SetParent(centerleft, true);
    }
    void ParentSetRight(Transform c1, Transform c2)
    {
        c1.SetParent(centerright, true);
        c2.SetParent(centerright, true);
    }

    void ExitParent(Transform c1, Transform c2)
    {
        c1.SetParent(transform, true);
        c2.SetParent(transform, true);
    }
}
