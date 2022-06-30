using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Twinkle : MonoBehaviour
{
    public float twinkleSpeed; // ��˸�ٶ�

    [Header("���͸����")]
    public float twinkAlphaHigh;
    [Header("���͸����")]
    public float twinkleAlphaLow; // ���͸����
    private float curAlpha; // ��ǰ͸����
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        curAlpha = twinkleAlphaLow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(canvasGroup.alpha - curAlpha) > 0.05)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, curAlpha, twinkleSpeed * Time.deltaTime);

        }
        else
        {
            if (Mathf.Abs(curAlpha - twinkAlphaHigh) < 0.05)
                curAlpha = twinkleAlphaLow;
            else if (Mathf.Abs(curAlpha - twinkleAlphaLow) < 0.05)
                curAlpha = twinkAlphaHigh;
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, curAlpha, twinkleSpeed * Time.deltaTime);
        }
    }
}
