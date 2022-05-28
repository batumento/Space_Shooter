using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public class WaveAction
{
    public string name;
    public float delay;
    public Transform prefab;
    public int spawnCount;
    public GameObject message;
}

[System.Serializable]
public class Wave
{
    public string name;
    public List<WaveAction> actions;
}



public class WaveGenerator : MonoBehaviour
{
    Mover mover;
    public float difficultyFactor = 0.9f;
    public List<Wave> waves;
    private Wave m_CurrentWave;
    public Wave CurrentWave { get { return m_CurrentWave; } }
    private float m_DelayFactor = 1.0f;
    public float spawnWait;
    private int wavePoint;
    public bool gameOver;

    IEnumerator SpawnLoop()
    {
        m_DelayFactor = 1.0f;
        while (true)
        {
            if (gameOver)
            {
                StopAllCoroutines();
                break;
            }
            foreach (Wave W in waves)
            {
                m_CurrentWave = W;
                foreach (WaveAction A in W.actions)
                {
                    if (A.delay > 0)
                        yield return new WaitForSeconds(A.delay * m_DelayFactor);
                    if (A.message != null)
                    {
                        wavePoint++;
                        A.message.SetActive(true);
                        yield return new WaitForSeconds(1f);
                        A.message.transform.DOScale(new Vector3(0, 0, 0), 1f).OnComplete(()=>
                        A.message.transform.localScale = Vector3.one);
                        yield return new WaitForSeconds(1f);
                        A.message.SetActive(false);
                        A.message.GetComponent<Text>().text = "Wave " + wavePoint;
                        
                    }
                    if (A.prefab != null && A.spawnCount > 0)
                    {
                        
                        for (int i = 0; i < A.spawnCount; i++)
                        {
                            Vector3 spawnPosition = new Vector3(Random.Range(-3.5f, 3.5f), 1, Random.Range(7, 10));
                            Quaternion spawnRotation = Quaternion.identity;
                            Instantiate(A.prefab,spawnPosition,spawnRotation);
                            yield return new WaitForSeconds(spawnWait);
                        }
                        A.spawnCount++;
                    }
                }
                yield return null;  // prevents crash if all delays are 0
            }
            m_DelayFactor *= difficultyFactor;
            yield return null;  // prevents crash if all delays are 0
        }
    }
    
    void Start()
    {
        gameOver = false;
        StartCoroutine(SpawnLoop());
    }

}
