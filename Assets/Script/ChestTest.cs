using UnityEngine;
using DG.Tweening;

public class ChestTest : MonoBehaviour
{
    Transform lid;
    public Transform[] Chests;
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
            lotation();
        }
    }
    public void Open()
    {
        lid.transform.Rotate(-40f, 0, 0);
    }
    public void lotation()
    {
        transform.DOLocalRotate(new Vector3(0,180f, 0), 5f, RotateMode.FastBeyond360);
    }
}
