using System.Runtime.CompilerServices;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GetComponentClothesSize : MonoBehaviour
{
    private ClothesSize ClothesSize;

    private void Start()
    {
        ClothesSize = GetComponent<ClothesSize>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Clothes"))
        {
            if (collision.TryGetComponent<ClothesSize>(out var component))
            {
                if (ClothesSize.CurrentSize == component.CurrentSize)
                {
                    Debug.Log("ê¨å˜");
                }
            }

        }
    }
}
