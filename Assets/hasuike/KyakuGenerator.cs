using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KyakuGenerator : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    bool once = false;
    public void CustomerGenerator()
    {
        int rand = Random.Range(0, Customers.Count);
        Instantiate(Customers[rand]);
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
