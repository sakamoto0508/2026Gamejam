using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField]
    List<Text> texts;
    void Start()
    {
        var data = EditorRankingManager.instance.RankingData;
        for (int i = 0; i < texts.Count; i++)
        {
            if (i < data.Count)
            {
                texts[i].text =
                    $"{i + 1}位  {data[i].score}点";
            }
            else
            {
                texts[i].text = "---";
            }
        }
    }


}
