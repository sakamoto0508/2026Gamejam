using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;  //速さ
    public bool IsMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMove) return;

        Transform myTransform = this.transform;  //ワールド座標を基準に、座標を取得
        Vector2 pos = myTransform.position;
        pos.x += speed;  //速さ

        myTransform.position = pos;
    }
}
