using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;  //����
    public bool IsMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMove) return;

        Transform myTransform = this.transform;  //[hWɁAW擾
        Vector2 pos = myTransform.position;
        pos.x += speed * Time.deltaTime;  //

        myTransform.position = pos;
    }
}
