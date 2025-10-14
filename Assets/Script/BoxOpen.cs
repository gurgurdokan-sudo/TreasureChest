using UnityEngine;
using DG.Tweening;
using System.Collections;


public class BoxOpen : MonoBehaviour
{
    public Transform _target;//カメラを設定
    public Transform lidTransform;// フタのTransform
    public float openAngle = -40f; // 開くときの角度（x軸）
    public float duration = 1f;
    private bool isOpen = false;
    private bool isEffect = false;
    public bool IsOpen() { return isOpen; }
    [SerializeField] bool isDamege = false;
    [SerializeField] GameObject effectPrefab;
    void Update()
    {
        transform.LookAt(_target);
        if (isOpen && !isDamege && !isEffect)
        {
            StartCoroutine(EffectCorrctChecst());
        }
    }
    public void Open(bool isResule = false)
    {
        if (isDamege && isResule)
        {
            BoxAnimetion();
        }
        else lidTransform.DOLocalRotate(new Vector3(openAngle, 0, 0), duration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => isOpen = true);
    }

    public void Close()
    {
        lidTransform.DOLocalRotate(Vector3.zero, duration)
            .SetEase(Ease.InCubic)
            .OnComplete(() => isOpen = false);
    }
    void BoxAnimetion()
    {
        Vector3 targetPos = transform.position - Vector3.back * 1.5f;
        Vector3 carentPos = transform.position;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(targetPos, 0.5f).SetEase(Ease.OutQuad));
        seq.Join(lidTransform.DOLocalRotate(new Vector3(openAngle, 0, 0), 1f));
        seq.Append(transform.DOMove(carentPos, 0.5f).SetEase(Ease.OutQuad));
        seq.Join(lidTransform.DOLocalRotate(Vector3.zero, 1.0f));
        seq.Play();
    }
    IEnumerator EffectCorrctChecst()
    {
        Instantiate(effectPrefab, transform.position + Vector3.up * 1.0f, Quaternion.identity);
        isEffect = true;
        yield return new WaitForSeconds(0.2f);
        isEffect = false;
    }
    public void HintLid()
    {
        MeshRenderer mesh = lidTransform.GetComponent<MeshRenderer>();
        if (mesh.material == null) Debug.Log("lidがありません");
        else
        {
            mesh.material.SetFloat("_Surface", 1);
            mesh.material.DOFade(0.3f, 3.0f).SetLoops(2,LoopType.Yoyo);
        }
    }
}
