using Unity.VisualScripting;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeleteArea"))
        Destroy(this.gameObject);
    }
    
}
