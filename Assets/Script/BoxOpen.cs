using UnityEngine;
using DG.Tweening;

public class BoxOpen : MonoBehaviour
{
    public Transform lidTransform;// フタのTransform
    public float openAngle = -100f; // 開くときの角度（x軸）
    public float duration = 1.5f;
    private float time;  // 次の動きまでの時間を管理する変数
    private float vecX;  // X軸方向の移動先座標
    private float vecZ;

    private bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Open();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Close();
        }
    }
    public void Open()
    {
        lidTransform.DOLocalRotate(new Vector3(openAngle, 0, 0), duration)
            .SetEase(Ease.OutCubic);
        isOpen = true;
        //transform.Rotate(-100, 0, 0);
    }

    public void Close()
    {
        lidTransform.DOLocalRotate(Vector3.zero, duration)
              .SetEase(Ease.InCubic);
        isOpen = false;
    }
}
