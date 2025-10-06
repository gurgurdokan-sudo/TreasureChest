using UnityEngine;
using DG.Tweening;

public class BoxOpen : MonoBehaviour
{
    public Transform _target;//カメラを設定
    public Transform lidTransform;// フタのTransform
    public float openAngle = -40f; // 開くときの角度（x軸）
    public float duration = 1.5f;
    private bool isOpen = false;
    public bool IsOpen() {return isOpen;}
    void Update()
    {
        transform.LookAt(_target);
    }
    public void Open()
    {
        lidTransform.DOLocalRotate(new Vector3(openAngle, 0, 0), duration)
            .SetEase(Ease.OutCubic);
        isOpen = true;
    }

    public void Close()
    {
        lidTransform.DOLocalRotate(Vector3.zero, duration)
              .SetEase(Ease.InCubic);
        isOpen = false;
    }
}
