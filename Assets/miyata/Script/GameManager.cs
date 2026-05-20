using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float spawninterval = 2f;
    public bool isSpawning = true;
 
    public List <GameObject> OriginObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop()); 

        int rnd = Random.Range(0,OriginObjects.Count);
        Instantiate(OriginObjects[rnd]);
    }

    IEnumerator SpawnLoop()
    {
        while(isSpawning)
        {
            int rnd = Random.Range(0,OriginObjects.Count);
            Instantiate(OriginObjects[rnd],transform.position,transform.rotation);
            //一時停止して待機→再始動
            yield return new WaitForSeconds(spawninterval);
        }
    }

}
