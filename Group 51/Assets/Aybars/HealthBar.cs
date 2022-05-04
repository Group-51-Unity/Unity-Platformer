using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthSlider;


    private void Start()
    {

        healthSlider = this.transform.GetComponent<Slider>();

    }
    public void UpdateHealth (float health)
    {
        healthSlider.value = health;

    }

}
