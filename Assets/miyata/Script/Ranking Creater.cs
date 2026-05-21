using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// [重要] FilePath属性をつけないことで、ファイル（ディスク）には保存せずメモリ上だけで保持します
public class EditorRankingManager : ScriptableSingleton<EditorRankingManager>
{
    // ランキングのデータ構造
    [Serializable]
    public class RankingEntry
    {
        public int score;
    }

    // メモリ上に保持されるリスト
    [SerializeField]
    private List<RankingEntry> rankingData = new List<RankingEntry>();

    public List<RankingEntry> RankingData => rankingData;

    /// <summary>
    /// スコアを登録する（自動でソートして上位5件を保持）
    /// </summary>
    public void AddScore(int score)
    {
        rankingData.Add(new RankingEntry
        {
            score = score,
        });

        // スコアの降順でソートして上位5件だけ残す
        rankingData = rankingData
            .OrderByDescending(x => x.score)
            .Take(5)
            .ToList();
    }

}