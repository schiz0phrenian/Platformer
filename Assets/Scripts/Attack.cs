using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    [Header("Параметры атаки")]
    public int Damage = 2;

    [Header("Цели")]
    public List<Health> Targets;
    public Health target;


    // Событие при смерти текущей цели
    public Action OnTargetDead;


    // Совершить ход (наносим урон текущей цели)
    public void MakeATurn()
    {
        if (target == null) return;
        target.TakeDamage(Damage);
        if (target.CurrentHealth <= 0)
        {
            // цель погибла
            OnTargetDead?.Invoke();
            Targets.Remove(target);
        }
        // выбираем следующую цель
        if (Targets.Count > 0)
        {
            target = Targets[0];
        }
        else
        {
            target = null;
        }
    }



     // Задать одну цель
    public void SetTarget(Health target)
    {
        this.target = target;
    }

    public void SetTargets(List<Entity> entities)
    {
        Targets.Clear();
        foreach (var e in entities)
        {
            if (e != null && e.Health != null)
                Targets.Add(e.Health);
        }

        if (Targets.Count > 0)
            target = Targets[0];
    }
}

