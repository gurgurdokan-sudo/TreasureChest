using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleController : MonoBehaviour
{
    public GameObject target;
    public GameObject obj;
    

    public void ButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        target.transform.Rotate(new Vector3(0, 3, 0));
        obj.transform.Rotate(new Vector3(0, -3, 0));

        

    }

    void Move()
    {

        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DOScaleY(0.8f, 0.2f))
           .Append(obj.transform.DOScaleY(1.0f, 0.2f))
           .SetLoops(-1, LoopType.Restart);


    }
    void MoveJump()
    {
        Sequence seq = DOTween.Sequence();
        obj.transform.DOJump(
        endValue: obj.transform.position, // 着地位置（同じ場所ならその場ジャンプ）
        jumpPower: 1f,                // 跳ねる高さ
        numJumps: 1,                  // ジャンプ回数
        duration: 0.5f                // アニメーション時間
    ).SetLoops(-1, LoopType.Yoyo)     // 無限ループで上下に繰り返す
     .SetEase(Ease.OutQuad);          // 跳ね感を自然に
        seq.Append(obj.transform.DOScaleY(0.8f, 0.1f))
                   .Append(obj.transform.DOScaleY(1f, 0.2f))
                   .SetLoops(-1, LoopType.Restart);
    }
}
