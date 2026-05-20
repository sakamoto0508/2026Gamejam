using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KyakuGenerator : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    bool once = false;
    [SerializeField]private GameObject _rikishi;
    [SerializeField]private Timer _timer; 
    public void CustomerGenerator()
    {
        int rand = Random.Range(0, Customers.Count);
        if(Customers.Count == 0) return;
        Instantiate(Customers[rand]);
    }
    private void Update()
    {
        if (once == false && _timer.IsFever)//IsFever == true &&
        {
            Customers.Clear();
            Customers.Add(_rikishi);
            once = true;
        } 
    }
}
