using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class Health : MonoBehaviour
{
    [Header("Параметры здоровья")]
    public int MaxHealth = 10;
    public int CurrentHp;

    [Header("События")]
    public UnityEvent OnDeath;


    public void Awake()
    {
        //В начале игры максимальное хп
        CurrentHp = MaxHealth;
    }

    public void Init(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHp = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            CurrentHp = 0;
            Die();
        }
    }

    public void Restore()
    {
        CurrentHp = MaxHealth;
    }
    
    public void Die()
    {
        Debug.Log($"{gameObject.name} погиб!");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
