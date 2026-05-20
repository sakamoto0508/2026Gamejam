using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class KyakuGenerator : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    [SerializeField] private List<Transform> _generatePoint;
    bool once = false;
    [SerializeField] private GameObject _rikishi;
    [SerializeField] private Timer _timer;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            NewGenerate(_generatePoint[i].position);
        }
    }

    public void NewGenerate(Vector3 position)
    {
        int rand = Random.Range(0, Customers.Count);
        GameObject customerObject = Instantiate(Customers[rand], transform.position, transform.rotation);
        if (customerObject.TryGetComponent<Customer>(out var customer))
        {
            customer.Targetvecter(position);
        }
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
