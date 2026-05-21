using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float fadeDuration = 1f;

    private bool isFading = false;
    private Color color;

    private void Start()
    {
        color = image.color;
        color.a = 1f;
        image.color = color;
    }

    public void StartFadeOut()
    {
        if (isFading) return;

        isFading = true;
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / fadeDuration;

            // 1 ¨ 0 ‚É•Ï‰»
            color.a = Mathf.Lerp(1f, 0f, t);

            image.color = color;

            yield return null;
        }

        color.a = 0f;
        image.color = color;

        isFading = false;
    }
}