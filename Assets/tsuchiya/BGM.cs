using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager.PlayBGM("In Game BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
