using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;  //�q�̑���
    [SerializeField] private float _leaveSpeed = 2f;  //�q�����鑬��
    public int HaveScore { get { return _haveScore; } }
    [SerializeField] private int _haveScore = 10;
    public bool iscorected = false;
    public Vector2 Targetposition { get { return targetposition; } }
    private Vector2 targetposition;

    [SerializeField] private float _leaveDelay = 5f; //�q����

    // Update is called once per frame
    void FixedUpdate()//qƕǂu[l߂@Ă畞ƓɍsB
    {
        if (!iscorected)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
        }
        else
        {
            Transform myTransform = this.transform;  //���[���h���W����ɁA���W���擾
            Vector2 pos = myTransform.position;
            pos.x += _leaveSpeed;  //����
            myTransform.position = pos;
        }
    }
    public void Targetvecter(Vector2 pos)
    {
        targetposition = pos;
    }

   
}
