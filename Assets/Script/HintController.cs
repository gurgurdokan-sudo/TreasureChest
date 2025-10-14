using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public Manager manager;
    bool isClick;
    Image image;
    void Start()
    {
        isClick = false;
        image = GetComponentInChildren<Image>();
    }
    public void OnClickHint()
    {
        if (isClick) return;
        if (manager.currentPlayer != Manager.player.selectNone) return;
        manager.OnClickHint();
        image.DOFade(0.1f, 0.5f).SetEase(Ease.OutBounce);
        isClick = true;
    }
}

