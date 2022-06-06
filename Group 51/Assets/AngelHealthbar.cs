using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AngelHealthbar : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    public Slider AngelSlider;
    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    public void Update()
    {
        AngelSlider.value = _enemyHealth.currentHealth;
    }
}
