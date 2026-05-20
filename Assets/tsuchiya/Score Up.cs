using UnityEngine;
using UnityEngine.UI;

public class ScoreUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Text text;
    public int GameScore = 0;//足されるほう
    [SerializeField]
    private int amount = 10;  //足す値
    void Start()
    {
        text.text = "Score"+GameScore.ToString();//表示される値
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ScoreUpdate(int amount)
    {
        GameScore += amount ;
        text.text = "Score" + GameScore.ToString();//表示される値
    }
}
