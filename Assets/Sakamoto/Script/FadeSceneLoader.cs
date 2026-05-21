using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// フェード演出付きのシーンローダー。
/// </summary>
public class FadeSceneLoader : MonoBehaviour
{
    public static FadeSceneLoader Instance { get; private set; }

    [SerializeField]
    private Image _fadeImage;

    [SerializeField]
    private float _fadeDuration = 0.5f;

    private bool _isLoading;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        // 初期状態を透明にする
        Color color = _fadeImage.color;
        color.a = 0f;
        _fadeImage.color = color;
    }

    /// <summary>
    /// フェード付きでシーンを読み込む。
    /// </summary>
    public void LoadScene(string sceneName)
    {
        if (_isLoading)
        {
            return;
        }

        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    /// <summary>
    /// フェード処理本体
    /// </summary>
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        _isLoading = true;

        // フェードイン
        yield return StartCoroutine(Fade(0f, 1f));

        // シーン読み込み
        SceneManager.LoadScene(sceneName);

        // 1フレーム待つ
        yield return null;

        // フェードアウト
        yield return StartCoroutine(Fade(1f, 0f));

        _isLoading = false;
    }

    /// <summary>
    /// アルファ値を補間してフェードする
    /// </summary>
    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;

        Color color = _fadeImage.color;

        while (time < _fadeDuration)
        {
            time += Time.unscaledDeltaTime;

            float t = time / _fadeDuration;

            color.a = Mathf.Lerp(startAlpha, endAlpha, t);

            _fadeImage.color = color;

            yield return null;
        }

        // 最終値を保証
        color.a = endAlpha;
        _fadeImage.color = color;
    }
}