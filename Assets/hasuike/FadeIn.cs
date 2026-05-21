using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private float fadeDuration = 1.0f;

    private bool isFading = false;
    Color color;
    private void Start()
    {
        color = Image.color;
        color.a = 0f;
        Image.color = color;
    }

    public void StartFadeOut()
    {
        if (isFading) return;
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        isFading = true;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / fadeDuration;

            color.a = Mathf.Lerp(0f, 1f, t);

            Image.color = color;

            yield return null;
        }

        color.a = 1f;
        Image.color = color;

        isFading = false;
    }
}
