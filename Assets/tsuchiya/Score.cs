using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text text;
    public int GameScore = 0;
    [SerializeField]
    private int _amount = 10;
    [SerializeField]
    private int fever = 100;

    [SerializeField] private float _duration;
    [SerializeField] private float _scaleMultiplier = 1.2f;
    private Vector3 _defaultScale;

    private void Start()
    {
        text.text = GameScore.ToString();
        _defaultScale = text.transform.localScale;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreUpdate(int amount)
    {
        GameScore += amount;
        text.text = GameScore.ToString();
        StopAllCoroutines();
        StartCoroutine(ScoreAnimation());
    }
    public void FeverUPdate()
    {
        GameScore += fever;
        text.text = GameScore.ToString();
        StopAllCoroutines();
        StartCoroutine(ScoreAnimation());
    }

    private IEnumerator ScoreAnimation()
    {
        float time = 0f;
        float duration = _duration;

        Vector3 startScale = _defaultScale * _scaleMultiplier;

        // 最初に大きくする
        text.transform.localScale = startScale;

        while (time < duration)
        {
            time += Time.deltaTime;

            text.transform.localScale =
                Vector3.Lerp(startScale, _defaultScale, time / duration);

            yield return null;
        }

        text.transform.localScale = _defaultScale;
    }
}
