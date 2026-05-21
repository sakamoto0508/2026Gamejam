using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    [SerializeField] private string _loadScene; 

    public void SceneChange()
    {
        _loadScene = "Game";
        SceneManager.LoadScene(_loadScene);
    }
    public void TitleChange()
    {
        _loadScene = "Title";
        SceneManager.LoadScene(_loadScene);
    }
    public void ResultChange()
    {
        _loadScene = "Result";
        SceneManager.LoadScene(_loadScene);
    }
}
