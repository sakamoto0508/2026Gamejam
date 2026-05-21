using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    [SerializeField] private string _loadScene;
    [SerializeField] private float _loadTime = 0.2f;

    public void SceneChange()
    {
        _loadScene = "Game";
        StartCoroutine(LoadSceneCoroutine(_loadScene));
    }
    public void TitleChange()
    {
        _loadScene = "Title";
        StartCoroutine(LoadSceneCoroutine(_loadScene));
    }
    public void ResultChange()
    {
        _loadScene = "Result";
        StartCoroutine(LoadSceneCoroutine(_loadScene));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(_loadTime);
        SceneManager.LoadScene(sceneName);
    }
}
