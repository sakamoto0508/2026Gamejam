using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float spawninterval = 2f;
    [SerializeField]
    private float feverspawninterval = 1f;
    public bool isSpawning = true;
    private bool isFever = false;
    bool flg = false;

    public List<GameObject> OriginObjects;
    [SerializeField]private Timer _timer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (isSpawning && _timer.IsFever== false)
        {
            yield return new WaitForSeconds(spawninterval);
            int rnd = Random.Range(0,3);
            Instantiate(OriginObjects[rnd], transform.position, transform.rotation);
            //一時停止して待機→再始動
        }
    }
    private void Update()
    {
        if (_timer.IsFever && flg == false)
        {
            StartCoroutine(FeverLoop());
        
            flg = true;
        }
    }
    IEnumerator FeverLoop()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(feverspawninterval);
            Instantiate(OriginObjects[3], transform.position, transform.rotation);

        }
    }

}
