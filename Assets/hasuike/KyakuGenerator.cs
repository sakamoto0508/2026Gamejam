using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KyakuGenerator : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    bool once = false;
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
    
    private void Update()
    {
        if (once == false)//IsFever == true &&
        {
            Customers.Clear();
            once = true;
        } 
    }
}
