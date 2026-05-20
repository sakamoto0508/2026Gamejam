using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AudioManager
/// ・BGM / SE を名前で再生
/// ・音量指定可能
/// ・シングルトン
/// ・Inspectorから音を登録
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("BGMリスト")]
    [SerializeField] private List<SoundData> _bgmList = new();

    [Header("SEリスト")]
    [SerializeField] private List<SoundData> _seList = new();

    [Header("AudioSource")]
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _seSource;

    // 名前検索用
    private Dictionary<string, AudioClip> _bgmDictionary = new();
    private Dictionary<string, AudioClip> _seDictionary = new();

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Dictionary化
        foreach (var bgm in _bgmList)
        {
            if (!_bgmDictionary.ContainsKey(bgm.Name))
            {
                _bgmDictionary.Add(bgm.Name, bgm.Clip);
            }
        }

        foreach (var se in _seList)
        {
            if (!_seDictionary.ContainsKey(se.Name))
            {
                _seDictionary.Add(se.Name, se.Clip);
            }
        }
    }

    /// <summary>
    /// BGM再生
    /// </summary>
    /// <param name="name">BGM名</param>
    /// <param name="volume">音量(0~1)</param>
    public void PlayBGM(string name, float volume = 1f)
    {
        if (_bgmDictionary.TryGetValue(name, out AudioClip clip))
        {
            // 同じBGMなら再生し直さない
            if (_bgmSource.clip == clip && _bgmSource.isPlaying)
            {
                return;
            }

            _bgmSource.clip = clip;
            _bgmSource.volume = volume;
            _bgmSource.loop = true;
            _bgmSource.Play();
        }
        else
        {
            Debug.LogWarning($"BGMが見つかりません : {name}");
        }
    }

    /// <summary>
    /// BGM停止
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// SE再生
    /// </summary>
    /// <param name="name">SE名</param>
    /// <param name="volume">音量(0~1)</param>
    public void PlaySE(string name, float volume = 1f)
    {
        if (_seDictionary.TryGetValue(name, out AudioClip clip))
        {
            _seSource.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning($"SEが見つかりません : {name}");
        }
    }
}

/// <summary>
/// 音データ
/// </summary>
[Serializable]
public class SoundData
{
    public string Name;
    public AudioClip Clip;
}