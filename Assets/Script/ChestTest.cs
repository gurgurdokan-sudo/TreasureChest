using UnityEngine;
using DG.Tweening;

public class ChestTest : MonoBehaviour
{
    
    Transform lid;
    public Transform[] Chests;
    
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
            Lotation(gameObject);
            LotationSide(centerLeft);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            LotationSide(centerRight);

        }
        
        Turn();
    }
    public void Open()
    {
        lid.transform.Rotate(-40f, 0, 0);
    }
    public void Lotation(GameObject obj)
    {
        gameObject.transform.DOLocalRotate(new Vector3(0, 180f, 0), 5f, RotateMode.FastBeyond360);
    }
    public void LotationSide(Transform obj)
    {
        obj.transform.DOLocalRotate(new Vector3(0, 180f, 0), 5f, RotateMode.FastBeyond360);
    }
    
    public void Turn()
    {
        Chests[0].LookAt(_target);
        Chests[1].LookAt(_target);
        Chests[2].LookAt(_target);

    }
}
