using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    public float moveYSpeed = 20f;
    public float animationDuration = 3f;
    public float fadeSpeed = 1f;
    public float scalePeak = -0.2f;
    public float scaleValue = 2f;

    float passedTime;

    CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        passedTime += Time.deltaTime;
        
        // Move Up
        transform.position += new Vector3(0, moveYSpeed ) * Time.deltaTime;

        // Fade after half Time
        if (passedTime > animationDuration/2)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;

            if (canvasGroup.alpha <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
        // Scale Up to peak
        if (passedTime < scalePeak)
        {
            transform.localScale += Vector3.one * (scaleValue * Time.deltaTime);
        }
    }
}
