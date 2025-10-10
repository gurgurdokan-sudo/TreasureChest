using UnityEngine;
using DG.Tweening;

public class BoxOpen : MonoBehaviour
{
    public Transform _target;//カメラを設定
    public Transform lidTransform;// フタのTransform
    public float openAngle = -40f; // 開くときの角度（x軸）
    public float duration = 1f;
    private bool isOpen = false;
    bool isDamege = false;


    public bool IsOpen() { return isOpen; }
    void Update()
    {
        transform.LookAt(_target);
    }
    public void Open()
    {
        lidTransform.DOLocalRotate(new Vector3(openAngle, 0, 0), duration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => isOpen = true);
    }

    public void Close()
    {
        if (isDamege)
        {
            BoxAnimetion();
        }
        else
        {
            lidTransform.DOLocalRotate(Vector3.zero, duration).SetEase(Ease.InCubic).OnComplete(() => isOpen = false);
        }

    }

    public void BoxAnimetion()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = pos + Vector3.back * 2f;

        Sequence seq = DOTween.Sequence();
        seq.Append(lidTransform.DOLocalRotate(new Vector3(-40f, 0, 0), 1f).SetEase(Ease.OutCubic));
        seq.AppendInterval(1f);
        seq.Append(transform.DOMove(targetPos, 1f).SetEase(Ease.OutQuad));
        seq.Append(transform.DOMove(pos, 1f).SetEase(Ease.InQuad));
        seq.AppendInterval(1f);

        seq.Append(lidTransform.DOLocalRotate(Vector3.zero, 1.0f).SetEase(Ease.InCubic));

    }
}
