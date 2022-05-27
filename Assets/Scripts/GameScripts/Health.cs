using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider health;
    public void StartHealth(int _health)
    {
        health.maxValue = _health;
        health.value = _health;
    }
    public void HealthRights(int _health)
    {
        health.value = _health;
    }
}
