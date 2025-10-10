using UnityEngine;
using DG.Tweening;

public class DOUSAKAKUNINN : MonoBehaviour
{
    
    public Transform lidTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
