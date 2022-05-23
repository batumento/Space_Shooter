using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hazard;
    [SerializeField] private Text scoreText;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnWait;
    [SerializeField] private int spawnStart;
    [SerializeField] private int waveWait;
    [SerializeField] private int score;
    void Start()
    {
        StartCoroutine(SpawnAstroid());
    }
    
    //Burada InvokeRepeating metodu kullanarak da yapabilirdik ama ben Coroutine bilgimi pekiþtirmek için Coroutine tercih ettim.
    IEnumerator SpawnAstroid()
    {
        yield return new WaitForSeconds(spawnStart);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3.5f, 3.5f), 1, Random.Range(7, 10));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }
    public void Score()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
}
