using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private Button Button;

    private bool isFading = false;

    private void Start()
    {
        if (Button != null)
        {
            Button.onClick.AddListener(StartFadeOut);
        }
    }

    public void StartFadeOut() { }
}
