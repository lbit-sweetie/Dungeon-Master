using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public TMP_Text text;
    public Image panel;
    public float stepForAlpha;
    public float timeForUpdateAlpha;

    private Coroutine panelCor;
    private Coroutine textCor;
    void Start()
    {
        panelCor = StartCoroutine(Animation());
        text.gameObject.SetActive(true);
    }

    public IEnumerator Animation()
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1f);
        float alpha = 1f;
        while (panel.color.a >= 0)
        {
            alpha -= stepForAlpha;
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);

            if (panel.color.a <= 0)
            {
                StopCoroutine(panelCor);
                textCor = StartCoroutine(TextAnimation("How ITIS was born..."));
                break;
            }

            yield return new WaitForSeconds(timeForUpdateAlpha);
        }
        yield return null;
    }

    public IEnumerator TextAnimation(string textText)
    {
        text.text = textText;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        float alpha = 1f;
        while (text.color.a >= 0)
        {
            alpha -= stepForAlpha;
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            if (text.color.a <= 0)
            {
                StopCoroutine(textCor);
            }

            yield return new WaitForSeconds(timeForUpdateAlpha);
        }
        yield return null;
    }

    public void TextAnim(string text)
    {
        textCor = StartCoroutine(TextAnimation(text));
    }
}
