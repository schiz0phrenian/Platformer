using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Параметры здоровья")]
    public int MaxHealth = 10;
    public int CurrentHealth;

    [Header("События")]
    public UnityEvent OnDeath;


    public void Awake()
    {
        //В начале игры максимальное хп
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    //Восстановление
    public void Restore()
    {
        CurrentHealth = MaxHealth;
    }
    public void Die()
    {
        Debug.Log($"{gameObject.name} погиб!");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
