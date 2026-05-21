using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text text;

    [SerializeField] private float timer = 30f;

    // 点滅を始める秒数
    [SerializeField] private float warningTime = 5f;

    // 点滅速度
    [SerializeField] private float blinkSpeed = 5f;

    [SerializeField] private Scene _sceneLoader;

    private Score _score;

    private bool gameOver;

    public bool IsFever = false;

    private Color defaultColor;

    void Start()
    {
        text.text = "30";

        // 最初の色を保存
        defaultColor = text.color;

        // Scoreコンポーネントを取得
        _score = FindObjectOfType<Score>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        text.text = Mathf.Max(0, timer).ToString("F0");

        if (timer <= 10)
        {
            IsFever = true;
        }

        // 残り warningTime 秒以下なら点滅
        if (timer <= warningTime)
        {
            float t = Mathf.PingPong(Time.time * blinkSpeed, 1f);

            // 白 赤 を往復
            text.color = Color.Lerp(defaultColor, Color.red, t);
        }
        else
        {
            text.color = defaultColor;
        }

        if (timer <= 0f && gameOver == false)
        {
            GameOver();
            gameOver = true;
        }
    }

    void GameOver()
    {
        if (_score != null)
        {
            RankingManager.AddScore(_score.GameScore);
        }

        _sceneLoader.ResultChange();
    }
}