using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ChestTest : MonoBehaviour
{
    public Transform[] chests;//宝箱の配列
    public Transform[] centerSides;//統合
    bool isCaseOver=false;
    public bool IsCaseOver() { return isCaseOver; }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {//test用
            ShuffleRandomSelect();
        }
    }
    public void ShuffleRandomSelect()
    {
        int random = Random.Range(1, 2);
        Sequence seq = DOTween.Sequence();
        Debug.Log(random);
        switch (random)
        {
            case 0:
                seq.Append(ParentSet(chests[0], chests[1], centerSides[0]));
                seq.Append(ParentSet(chests[0], chests[2], centerSides[2]));
                seq.Append(ParentSet(chests[0], chests[1], centerSides[1]));
                break;
            case 1:
                seq.Append(ParentSet(chests[0], chests[2], centerSides[1]));
                seq.Append(ParentSet(chests[0], chests[1], centerSides[2]));
                break;
            case 2:
                seq.Append(ParentSet(chests[1], chests[2], centerSides[3]));
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));
                seq.Append(ParentSet(chests[2], chests[1], centerSides[0]));
                break;
        }
        seq.OnComplete(() => { chests = chests.OrderBy(c => c.position.x).ToArray(); isCaseOver = true; Debug.Log("シャッフル完了"); });
        seq.Play();
    }
    Sequence ParentSet(Transform c1, Transform c2, Transform parent)
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            c1.SetParent(parent,true);
            c2.SetParent(parent,true);
        });
        seq.Append(Lotation(parent));
        seq.AppendInterval(0.3f); //Parentが置き換わるまで待機
        seq.AppendCallback(() =>
        {
            c1.SetParent(transform,true);
            c2.SetParent(transform,true);
        });

    Sequence Lotation(Transform obj)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(obj.DOLocalRotate(new Vector3(0, 180f, 0), 1f, RotateMode.LocalAxisAdd));
        return seq;
    }
        return seq;
    }
}
