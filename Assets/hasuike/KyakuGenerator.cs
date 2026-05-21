using System.Collections.Generic;
using UnityEngine;

public class KyakuGenerator : MonoBehaviour
{
    public List<GameObject> Customers = new List<GameObject>();
    public List<Transform> GeneratePoint => _generatePoint;
    [SerializeField] private List<Transform> _generatePoint;
    bool once = false;
    [SerializeField] private GameObject _rikishi;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _gameObject;

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
        if (customerObject.TryGetComponent<Customer>(out var customer) && customerObject.TryGetComponent<SizeMatch>(out var sizeMatch))
        {
            customer.Targetvecter(position);
            sizeMatch.targetPos = position;
            sizeMatch.EffectPrefab =_gameObject;    
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
