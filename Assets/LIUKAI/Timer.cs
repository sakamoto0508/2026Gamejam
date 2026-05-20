using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]float timer = 30f;
    bool gameOver;
    void Start()
    {
        text.text = "30";
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        text.text = Mathf.Max(0, timer).ToString("F0");
        if (timer <=0f&&gameOver==false)
        {
            GameOver();
            gameOver = true;
        }
        
    }
    void GameOver()
    {
        Debug.Log("TimeOver");
    }
}
