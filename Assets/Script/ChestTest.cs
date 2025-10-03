using UnityEngine;
using DG.Tweening;

public class ChestTest : MonoBehaviour
{
    public Transform target;
    Transform lid;
    public Transform[] Chests;
    GameObject maincamera;
    void Start()
    {
        lid = GetComponent<Transform>().GetChild(0).GetChild(2);
        maincamera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Open();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lotation();
            Invoke("Turn",6f);
        }
    }
    public void Open()
    {
        lid.transform.Rotate(-40f, 0, 0);
    }
    public void lotation()
    {
        transform.DOLocalRotate(new Vector3(0, 180f, 0), 5f, RotateMode.FastBeyond360);
        //transform.DOLookAt(target.localPosition, 1f);
       
    }
    public void Turn()
    {
       transform.LookAt(maincamera.transform);
    }
}
