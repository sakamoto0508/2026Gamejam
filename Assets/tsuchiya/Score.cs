using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text text;
    public int GameScore = 0;
    [SerializeField]
    private int amount = 10;
    [SerializeField]
    private int fever = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreUpdate() 
    {
        GameScore += amount;
        text.text = GameScore.ToString();
    }
    public void FeverUPdate()
    {
        GameScore += fever;
        text.text = GameScore.ToString();
    }
}
