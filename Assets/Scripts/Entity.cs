using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Health Health;
    public Attack Attack;
    public int Coins = 5;
    [Header("Награда за убийство")]
    public int MinCoins = 5;
    public int MaxCoins = 10;

    //Восстановления состояния
    public void Restore()
    {
        if (Health != null)
        {
            Health.Restore();
        }
        gameObject.SetActive(false);
    }
    
    
    public void OnTargetDead()
    {
        Debug.Log($"{gameObject.name}: моя цель мертва!");
    }
}
