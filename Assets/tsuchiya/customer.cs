using System.Runtime.CompilerServices;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;  //客の速さ
    [SerializeField] private float _leaveSpeed = 2f;  //客が去る速さ
    public int HaveScore { get { return _haveScore; } }
    [SerializeField] private int _haveScore = 10;
    public bool iscorected = false;
    public Vector2 Targetposition { get { return targetposition; } }
    private Vector2 targetposition;

    // Update is called once per frame
    void Update()//客と服があったかどうかブール値を決める　あっていたら服と同じただ左に行く。
    {
        if (!iscorected)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
        }
        else
        {
            Transform myTransform = this.transform;  //ワールド座標を基準に、座標を取得
            Vector2 pos = myTransform.position;
            pos.x += _leaveSpeed;  //速さ
            myTransform.position = pos;
        }
    }
    public void Targetvecter(Vector2 pos)
    {
        targetposition = pos;
    }
}
