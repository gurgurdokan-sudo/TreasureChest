using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Transform unityChanTransform;
    UnityChanContorller unityChanContorller;
    Vector3 syoki = new Vector3(0, 0.52f, -6.0f);
    public CanvasGroup canPanel;
    TextMeshProUGUI readyTxt;
    public BoxOpen[] boxOpens;//各Chest
    public ChestTest chestTest;//シャッフル
    int gameLevle = 1;
    int life = 3;

    enum gameStep
    {
        gameStart, waitForPlayerSelct, gameRelode, levelCompeete
    }
    gameStep currentGameStep;
    public enum player
    {
        selectNone, correct, incorrect
    }
    public player currentPlayer;
    void Start()
    {
        readyTxt = canPanel.GetComponentInChildren<TextMeshProUGUI>();
        unityChanContorller = unityChanTransform.GetComponent<UnityChanContorller>();
        unityChanContorller.isMove = false;
        readyTxt.text = "Start";
        currentGameStep = gameStep.gameStart;
        currentPlayer = player.selectNone;
    }
    void FullOpen()
    {
        for (int i = 0; i < boxOpens.Length; i++)
        {
            boxOpens[i].Open();
        }
    }
    void FullClose()
    {
        for (int i = 0; i < boxOpens.Length; i++)
        {
            boxOpens[i].Close();
        }
    }
    void SingleLidMove(bool isNg = false)
    {
        Sequence sqe = DOTween.Sequence();
        if (!isNg) sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(1.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.Play();
    }
    Sequence FadeIn()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(canPanel.DOFade(1, 1.0f));
        seq.Append(canPanel.DOFade(0, 1.0f));
        return seq;
    }
    void Update()
    {
        switch (currentGameStep)
        {
            case gameStep.gameStart:
                unityChanContorller.isMove = false;
                GameStart();
                currentGameStep = gameStep.waitForPlayerSelct;
                break;
            case gameStep.waitForPlayerSelct:
                WaitForPlayerSelct();
                break;
            case gameStep.gameRelode:
                ReloadGame();
                break;
            case gameStep.levelCompeete:
                Resule();
                break;
        }
    }
    void GameStart()
    {
        Sequence sqe = DOTween.Sequence();
        sqe.Append(FadeIn());
        sqe.AppendCallback(() => FullOpen());
        sqe.AppendInterval(3.0f);
        sqe.AppendCallback(() => FullClose());
        sqe.AppendInterval(3.0f);
        sqe.AppendCallback(() => chestTest.ShuffleRandomSelect());
        sqe.AppendInterval(5.0f);
        sqe.OnComplete(() => { unityChanContorller.isMove = true; });
        sqe.Play();
    }
    void WaitForPlayerSelct()
    {
        if (currentPlayer == player.selectNone) return;//両方選択されずに待機状態
        if (currentPlayer == player.correct)
        {
            if (gameLevle < 3) gameLevle++;
            readyTxt.text = "Great!";
            readyTxt.color = Color.yellow;
            SingleLidMove();
            currentGameStep = gameStep.gameRelode;
        }
        if (currentPlayer == player.incorrect)
        {
            life--;
            LifePanel.instance.UpdateLife(life);
            SingleLidMove(true);
            readyTxt.text = "NG Chast";
            readyTxt.color = Color.red;
            currentGameStep = gameStep.gameRelode;
        }
    }
    void ReloadGame()
    {
        if (currentPlayer == player.incorrect || currentPlayer == player.correct)
        {
            unityChanContorller.isMove = false;
            currentPlayer = player.selectNone;
            unityChanTransform.position = syoki;
        }
        //Levelのカウントアップ/スコア
        if (life > 0) currentGameStep = gameStep.gameStart;//もう一度ゲームステップ
        else currentGameStep = gameStep.levelCompeete;
    }
    void Resule()
    {
        SceneManager.LoadScene("Result");
    }
    public void OnClickHint()
    {
        int random = Random.Range(0, 3);
        boxOpens[random].HintLid();
    }
}

