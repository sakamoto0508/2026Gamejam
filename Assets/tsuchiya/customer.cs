using System.Runtime.CompilerServices;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;  //客の速さ
    public bool iscorected = false;
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
            pos.x += speed;  //速さ
            myTransform.position = pos;
        }
    }
    public void Targetvecter(Vector2 pos)
    {
        targetposition = pos;
    }
}
