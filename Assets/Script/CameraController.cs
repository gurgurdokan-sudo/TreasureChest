using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 diff;

    public GameObject target;
    //public Trnsform target;
    public float followSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diff = target.transform.position - transform.position;//target.position-transform.position;
    }

    void LateUpdate()//updateの後に始まる
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - diff,//target.position-diff;
            Time.deltaTime * followSpeed
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
