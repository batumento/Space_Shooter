using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider health;
    [SerializeField] private GameObject gameOverPanel;
    GameManager gameManager;
    WaveGenerator waveGenerator;

    private void Awake()
    {
        waveGenerator = Object.FindObjectOfType<WaveGenerator>();
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    public void StartHealth(int _health)
    {
        health.maxValue = _health;
        health.value = _health;
    }
    public void HealthRights(int _health)
    {
        health.value = _health;
        if (_health <= 0)
        {
            waveGenerator.gameOver = true;
            gameOverPanel.SetActive(true);
            gameManager.ScorePanel();
            
        }
    }
}
