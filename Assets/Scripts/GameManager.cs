using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Entity Player;
    public List<Entity> CurrentEnemies = new();

    public List<SO> EnemyList;//список врагов
    public AttackMovement PlayerMovement;
    public BattleLog battleLog;


    void Start()
{
    SpawnEnemies();
    StartBattle();
}
    public void SpawnEnemies()
    {
        var enemy = EnemyList[Random.Range(0, EnemyList.Count)]; 

        Vector3 spawnPos = new Vector3(5, 0, 0f); 
        var inst = Instantiate(enemy.prefab, spawnPos, Quaternion.identity); // xz

        // восстанавливаем здоровье врага
        inst.Restore();

        inst.gameObject.SetActive(true);

        inst.Health.Init(enemy.maxHp);
        inst.Health.CurrentHp = enemy.maxHp;
        inst.Attack.Init(enemy.damage);
        inst.name = enemy.name;
        CurrentEnemies.Add(inst);
        
  
        inst.Attack.SetTarget(Player.Health);
        Player.Attack.SetTargets(CurrentEnemies);
    }

    public void StartBattle()
    {
        StartCoroutine(Battle());
    }

    private IEnumerator Battle()
    {
        while (Player.Health.CurrentHp> 0 && CurrentEnemies.Count > 0)
        {
            // Ход игрока
            if (CurrentEnemies.Count > 0)
            {
                var targetEnemy = CurrentEnemies[0];

                if (PlayerMovement != null)
                    PlayerMovement.PlayAttack(targetEnemy.transform.position);

                // Ждём немного, чтобы движение успело начаться
                yield return new WaitForSeconds(0.5f);

                Player.Attack.MakeATurn();
                battleLog.AddMessage($"Игрок нанес {Player.Attack.Damage} урона!");

                yield return new WaitForSeconds(0.5f);
        }
        


    foreach (var e in CurrentEnemies)
            {
                if (e.Health.CurrentHp > 0)
                {
                    var enemyMovement = e.GetComponent<AttackMovement>();

                    if (enemyMovement != null)
                        enemyMovement.PlayAttack(Player.transform.position);

                    yield return new WaitForSeconds(0.5f);

                    e.Attack.MakeATurn();
                    battleLog.AddMessage($"{e.name} нанес {e.Attack.Damage} урона!");

                    yield return new WaitForSeconds(0.5f);
                }
            }
    }

        if (Player.Health.CurrentHp > 0)
        {
            Debug.Log("Игрок победил!");
            // открыть магазин, загрузить UI
        }
        else
        {
            Debug.Log("Игрок проиграл!");
            // экран поражения
        }
    }
}
