using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bug : MonoBehaviour
{
   // [SerializeField] private Slider HealthUI;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }
    public void Damge(float damge)
    {
        health -= damge;
        //HealthUI.value = health;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health < 0) Destroy(gameObject);
    }

}
