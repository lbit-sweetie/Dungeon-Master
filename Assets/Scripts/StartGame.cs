using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private WaitForSeconds waitPanel;
    private WaitForSeconds waitText;

    public float timePanel;
    public float timeText;

    public TMP_Text text;
    public Image panel;
    public float stepForAlpha;
    public float timeForUpdateAlpha;

    private Coroutine panelCor;
    private Coroutine textCor;
    void Start()
    {
        //Time.timeScale = 0;
        panelCor = StartCoroutine(Animation());
    }

    void Update()
    {

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
                textCor = StartCoroutine(TextAnimation());
                break;
            }

            yield return new WaitForSeconds(timeForUpdateAlpha);
        }
        yield return null;
    }

    public IEnumerator TextAnimation()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        float alpha = 1f;
        while (text.color.a >= 0)
        {
            alpha -= stepForAlpha * 2f;
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            if (text.color.a <= 0)
            {
                StopCoroutine(panelCor);
            }

            yield return new WaitForSeconds(timeForUpdateAlpha);
        }
        yield return null;
    }
}
