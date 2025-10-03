using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public UnityController un;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    
    

}





/*
Ray ray = new Ray(
                transform.position+Vector3.up*0.2f,
                lookDirection
            );
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                Debug.Log("当たった相手：" + hit.collider.name);
            }
            Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red, 1f);



*/
