using DG.Tweening;
using TMPro;

public static class DoCunter
{
    public static Tweener DOText(this TextMeshProUGUI target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
    {
        return DOTween.To(() => target.text, x => target.text = x, endValue, duration)
            .SetOptions(richTextEnabled, scrambleMode, scrambleChars)
            .SetTarget(target);
    }

    public static Tweener DOFade(this TextMeshProUGUI target, float endValue, float duration)
    {
        return DOTween.ToAlpha(() => target.color, x => target.color = x, endValue, duration)
            .SetTarget(target);
    }
    public static Tweener DOCounter(this TextMeshProUGUI target, int fromValue, int endValue, float duration, bool addThousandsSeparator = true)
    {
        int v = fromValue;
        return DOTween.To(() => v, x =>
        {
            v = x;
            target.text = addThousandsSeparator ? v.ToString("N0") : v.ToString();
        }, endValue, duration).SetTarget(target);
    }
}
