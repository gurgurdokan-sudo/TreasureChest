using UnityEngine;
using DG.Tweening;

public class ChestTest : MonoBehaviour
{
    public Transform target;
    Transform lid;
    public Transform[] Chests;
    
    public Transform self;
    public Transform self2;
    public Transform self3;
    public Transform _target;
    public Transform centerLeft;
    public Transform centerRight;
    void Start()
    {
        lid = GetComponent<Transform>().GetChild(0).GetChild(2);
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Open();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            llotation();
            Invoke("Turn", 6f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rlotation();
            Invoke("Turn",6f);
        }
    }
    public void Open()
    {
        lid.transform.Rotate(-40f, 0, 0);
    }
    public void llotation()
    {
        centerLeft.transform.DOLocalRotate(new Vector3(0, 180f, 0), 5f, RotateMode.FastBeyond360);
        //transform.DOLookAt(target.localPosition, 1f);
       
    }
    public void rlotation()
    {
        centerRight.transform.DOLocalRotate(new Vector3(0, 180f, 0), 5f, RotateMode.FastBeyond360);

    }
    public void Turn()
    {
        self.LookAt(_target);
        self2.LookAt(_target);
        self3.LookAt(_target);

    }
}
