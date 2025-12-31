using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [Header("Статы")]
    public int maxHealth = 10;
    public int currentHp;
    public int damage = 2;
    public int coins = 0;


    void Awake()
    {
        currentHp = maxHealth;
    }

    public void OnAttackEnemy(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

    public void TakeDamage(int dmg)
    {
        currentHp -= dmg;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Игрок погиб");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnEnemyKilled(int reward)
    {
        coins += reward;
    }
    
}
