using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;


public class BoxController : MonoBehaviour
{
    public Transform lidTransform;// フタのTransform
    public float openAngle = -100f; // 開くときの角度（x軸）
    public float duration = 1.5f;

    private bool isOpen = false;

    private float time;  // 次の動きまでの時間を管理する変数
    private float vecX;  // X軸方向の移動先座標
    private float vecZ;  // Z軸方向の移動先座標


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Open();
        //Turn();
        
    }
    public void Turn()
    {
        
    // 毎フレーム時間を減少させる
        time -= Time.deltaTime;

        // 時間が0以下になったら新しい座標を設定
        if (time <= 0)
        {
            // X軸とZ軸の移動先をランダムに設定
            vecX = Random.Range(-2.71f, 2.71f);
            vecZ = Random.Range(0f, 0f);

            // オブジェクトを新しい位置に移動
            this.transform.position = new Vector3(vecX, 0.5f, vecZ);

            // 次の動きまでの時間をリセット
            time = 1.0f;
        }

    }

   /* public void ToggleLid()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
    */

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
