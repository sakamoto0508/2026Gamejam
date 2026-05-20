using System.Collections;
using UnityEngine;

public class AdvancedSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    private bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (isSpawning)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            // spawnInterval の秒数だけ処理を一時停止して待機
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
