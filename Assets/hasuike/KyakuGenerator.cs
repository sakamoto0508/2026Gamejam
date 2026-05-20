using System.Collections.Generic;
using UnityEngine;

public class KyakuGenerator : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();

    public void CustomerGenerator(int number)
    {
        Instantiate(Customers[number]);
    }
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, Customers.Count);
            CustomerGenerator(rand);
        }
    }
}
