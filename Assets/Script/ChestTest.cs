using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ChestTest : MonoBehaviour
{
    public Transform[] chests;//宝箱の配列
    public Transform[] centerSides;//統合
    float speed=1.0f;

    public void ShuffleRandomSelect(int level)
    {
        if (level == 0)
        {
            speed = 1.0f;
        }
        if (level == 1)
        {
            speed = 0.5f;
        }
        else if (level == 2)
        {
            speed = 0.25f;
        }
        else if (level == 3)
        {
            speed = 0.19f;
        }
        
        this.ShuffleRandomSelect();
    }
    public void ShuffleRandomSelect()
    {
        int random = Random.Range(0, 6);
        Sequence seq = DOTween.Sequence();
        Debug.Log(random);
        switch (random)
        {
            case 0:
                seq.Append(ParentSet(chests[0], chests[1], centerSides[0]));//102
                seq.Append(ParentSet(chests[0], chests[2], centerSides[2]));//120
                seq.Append(ParentSet(chests[0], chests[1], centerSides[1]));//021
                seq.Append(ParentSet(chests[1], chests[0], centerSides[1]));//120
                seq.Append(ParentSet(chests[0], chests[2], centerSides[2]));//102
                
                break;//1,0,2
            case 1:
                seq.Append(ParentSet(chests[0], chests[2], centerSides[1]));//210
                seq.Append(ParentSet(chests[0], chests[1], centerSides[2]));//201
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//021
                seq.Append(ParentSet(chests[0], chests[1], centerSides[1]));//120
                seq.Append(ParentSet(chests[2], chests[1], centerSides[0]));//210
                 
                break;//2,1,0
            case 2:
                seq.Append(ParentSet(chests[1], chests[2], centerSides[2]));//021
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//201
                seq.Append(ParentSet(chests[0], chests[1], centerSides[2]));//210
                seq.Append(ParentSet(chests[2], chests[0], centerSides[1]));//012
                seq.Append(ParentSet(chests[0], chests[1], centerSides[0]));//102
                 
                break;//1,0,2
            case 3:
                seq.Append(ParentSet(chests[0], chests[1], centerSides[0]));//012
                seq.Append(ParentSet(chests[0], chests[2], centerSides[2]));//021
                seq.Append(ParentSet(chests[0], chests[1], centerSides[1]));//201
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//021
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//201
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//210
                 
                
                break;//0,2,1
            case 4:
                seq.Append(ParentSet(chests[0], chests[2], centerSides[1]));//210
                seq.Append(ParentSet(chests[1], chests[0], centerSides[2]));//201
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//021
                seq.Append(ParentSet(chests[1], chests[0], centerSides[1]));//120
                
                break;//1,2,0
            case 5:
                seq.Append(ParentSet(chests[1], chests[2], centerSides[2]));//021
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//201
                seq.Append(ParentSet(chests[2], chests[1], centerSides[1]));//102
                seq.Append(ParentSet(chests[2], chests[1], centerSides[1]));//201
                seq.Append(ParentSet(chests[2], chests[0], centerSides[0]));//021
                 
                break;//0,2,1
        }
        seq.OnComplete(() => { chests = chests.OrderBy(c => c.position.x).ToArray(); Debug.Log("シャッフル完了"); });
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
        seq.Append(obj.DOLocalRotate(new Vector3(0, 180f, 0), speed, RotateMode.LocalAxisAdd));
        return seq;
    }
        return seq;
    }
}
