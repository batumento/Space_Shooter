using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hazard;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnWait;
    [SerializeField] private float spawnStart;
    void Start()
    {
        StartCoroutine(SpawnAstroid());
    }
    
    //Burada InvokeRepeating metodu kullanarak da yapabilirdik ama ben Coroutine bilgimi pekiþtirmek için Coroutine tercih ettim.
    IEnumerator SpawnAstroid()
    {
        yield return new WaitForSeconds(spawnStart);
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-3.5f, 3.5f), 1, Random.Range(7, 10));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
