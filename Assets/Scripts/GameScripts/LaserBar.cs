using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserBar : MonoBehaviour
{
    public Slider laserBar;
    // Start is called before the first frame update
    PlayerController playerController;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    public void StartLaserBar(int _laser)
    {
        laserBar.maxValue = _laser;
        laserBar.value = _laser;
    }
    public void LasersBar(int _laser2)
    {
        laserBar.value = _laser2;
    }
}
