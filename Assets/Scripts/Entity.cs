using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Health Health;
    public Attack Attack;


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
