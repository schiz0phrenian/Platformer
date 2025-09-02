using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Entity Player;
    public List<Entity> CurrentEnemies = new();

    public Entity enemyPrefab1;
    public Entity enemyPrefab2;
    public Entity enemyPrefab3;

    public void SpawnEnemies() {
        var prefab = enemyPrefab1; //спавн врага

        Vector3 spawnPos = new Vector3(3, 0, 0); //спавн врага справа

        var inst = Instantiate(prefab, spawnPos, Quaternion.identity); // xz

        // восстанавливаем здоровье врага
        inst.Restore();
        
         // добавляем в список
        CurrentEnemies.Add(inst);

        // настраиваем таргеты
        inst.Attack.SetTarget(Player.Health);
        Player.Attack.SetTargets(CurrentEnemies);
    }

// Запуск боя
    public void StartBattle()
    {
        StartCoroutine(Battle());
    }

    private IEnumerator Battle()
    {
        while (Player.Health.CurrentHP > 0 && CurrentEnemies.Count > 0)
        {
            // Ход игрока
            Player.Attack.MakeATurn();
            yield return new WaitForSeconds(0.5f);

            // Ходы врагов
            foreach (var e in CurrentEnemies)
            {
                if (e.Health.CurrentHP > 0)
                {
                    e.Attack.MakeATurn();
                    yield return new WaitForSeconds(0.5f);
                }
            }
            // Убираем мёртвых врагов
            CurrentEnemies.RemoveAll(e => e.Health.CurrentHP <= 0);
    }

     // Если игрок жив и врагов нет — победа
        if (Player.Health.CurrentHP > 0)
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
