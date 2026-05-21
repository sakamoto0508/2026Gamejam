using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]float timer = 30f;
    [SerializeField]Scene _sceneLoader;
    bool gameOver;
    public bool IsFever = false;
    void Start()
    {
        text.text = "30";
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = Mathf.Max(0, timer).ToString("F0");
        if (timer <= 10)
        {
            IsFever = true;
        }
        if (timer <=0f&&gameOver==false)
        {
            GameOver();
            gameOver = true;
        }
        
    }
    void GameOver()
    {
        _sceneLoader.ReslutChange();
    }
}
