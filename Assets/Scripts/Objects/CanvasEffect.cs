using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEffect : MonoBehaviour
{
    public CanvasGroup uiElement;
     void Start()
    {
        FadeIn();
    }
    public void FadeIn()
    {
        Debug.Log("aa1");
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 5)
    {
        Debug.Log("aa2");
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
