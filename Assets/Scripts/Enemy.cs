using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO data;
    public int currentHp;
    void Awake()
    {
        currentHp = data.maxHp;
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
        Player player = FindObjectOfType<Player>();
        if (player != null)
            player.OnEnemyKilled(data.reward);
        Destroy(gameObject);
    }

    public void OnAttackPlayer(Player player)
    {
        player.TakeDamage(data.damage);
    }

}
