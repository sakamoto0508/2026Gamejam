using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{

    [SerializeField] private string _loadScene;
    [SerializeField] private float _loadTime = 0.2f;
    [SerializeField] private Button _button;

    public void SceneChange()
    {
        _loadScene = "Game";
        _button.interactable = false;
        StartCoroutine(LoadSceneCoroutine(_loadScene));
    }
    public void TitleChange()
    {
        _loadScene = "Title";
        _button.interactable = false;
        StartCoroutine(LoadSceneCoroutine(_loadScene));
    }
    public void ResultChange()
    {
        _loadScene = "Result";
        _button.interactable = false;
        StartCoroutine(LoadSceneCoroutine(_loadScene));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return new WaitForSeconds(_loadTime);
        SceneManager.LoadScene(sceneName);
    }
}
