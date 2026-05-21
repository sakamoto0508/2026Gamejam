using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fadeout2 : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private Button Button;

    private bool isFading = false;
    Color color;

    private void Start()
    {
        color = gameObject.GetComponent<Image>().color;
        color.r = 0.0f;
        color.g = 0.0f;
        color.b = 0.0f;
        color.a = 0.1f;
        gameObject.GetComponent<Image>().color = color;

        if (Button != null)
        {
            Button.onClick.AddListener(StartFadeOut);
        }
    }
    public void StartFadeOut()
    {
        if (isFading) return;

        StartCoroutine(FadeOutCoroutine());
    }
    private IEnumerator FadeOutCoroutine()
    {
        if (isFading == true)
        {
            color.a += 0.5f;
            gameObject.GetComponent<Image>().color = color;
            yield return null;
            if (color.a >= 1)
            {
                isFading = false;
            }
        }
     }
}
