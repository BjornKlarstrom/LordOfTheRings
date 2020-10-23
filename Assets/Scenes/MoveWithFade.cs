using System.Collections;
using UnityEngine;

public class MoveWithFade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public Transform target;
    public float fadeDuration = 2f;
    public float moveDuration = 2f;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    

    public IEnumerator FadeOutAndMove(float fadeDuration, float moveDuration)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeDuration;
            this.transform.position = Vector3.MoveTowards(transform.position, target.position, moveDuration);
            yield return null;
        }

        this.transform.position = transform.position;
    }
}
