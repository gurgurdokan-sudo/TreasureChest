using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour

{
    Tween currentTween;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] path =
    new[]
    {
        new Vector3(0f, 0.5f, 0f),
        new Vector3(0f, 0.5f, -5.0f),
        new Vector3(2.5f, 0.5f, 0f),
    };
    currentTween = transform.DOLocalPath(path, 3f, PathType.CatmullRom)
    .SetOptions(false) // 閉じたパスにしない
    .SetEase(Ease.Linear); 
    
    }
}
