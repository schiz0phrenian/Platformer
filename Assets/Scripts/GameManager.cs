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

    [Header("UI Panels")]
    public GameObject BattlePanel;
    public GameObject ShopPanel;


    void Start()
    {
        SpawnEnemies();
        StartBattle();
    }

    public void StartBattle()
    {
        if (battleLog != null)
        battleLog.ClearLog();
        BattlePanel.SetActive(true);
        ShopPanel.SetActive(false);
        StartCoroutine(Battle());

    }

    

    public void SpawnEnemies()
    {
        var enemy = EnemyList[Random.Range(0, EnemyList.Count)];

        Vector3 spawnPos = new Vector3(6, 0, 0f);
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

    public void StartNextBattle()
    {
        ShopPanel.SetActive(false);
        BattlePanel.SetActive(true);

        Player.Health.CurrentHp = Player.Health.MaxHealth;
        Player.gameObject.SetActive(true);

        foreach (var e in CurrentEnemies)
        {
            if (e != null)
                Destroy(e.gameObject);
        }
        CurrentEnemies.Clear();
    SpawnEnemies();
    StartBattle();
    }

    private IEnumerator Battle()
    {
        yield return new WaitForSeconds(0.5f);
        while (Player.Health.CurrentHp > 0 && CurrentEnemies.Count > 0)
        {
            // Ход игрока
            if (CurrentEnemies.Count > 0)
            {
                var targetEnemy = CurrentEnemies.Find(e => e != null && e.Health.CurrentHp > 0);
                if (PlayerMovement != null)
                    PlayerMovement.PlayAttack(targetEnemy.transform.position);
                Player.Attack.MakeATurn();
                battleLog.AddMessage($"У вас: {Player.Health.CurrentHp}/{Player.Health.MaxHealth}HP ");
                battleLog.AddMessage($" - Вы нанесли {Player.Attack.Damage} урона");
                yield return new WaitForSeconds(2f);
            }
            foreach (var e in CurrentEnemies)
            {
                if (e != null && e.Health.CurrentHp > 0 && e.gameObject.activeSelf)
                {
                    e.Attack.SetTarget(Player.Health);
                    var enemyMovement = e.GetComponent<AttackMovement>();
                    if (enemyMovement != null)
                        enemyMovement.PlayAttack(Player.transform.position);
                    e.Attack.MakeATurn();
                    battleLog.AddMessage($"{e.name} имеет: {e.Health.CurrentHp}/{e.Health.MaxHealth}HP ");
                    battleLog.AddMessage($" - {e.name} нанес вам {e.Attack.Damage} урона!");
                    yield return new WaitForSeconds(2f);
                }
            }

            // Чистим список врагов от мёртвых
            CurrentEnemies.RemoveAll(e => e == null || e.Health.CurrentHp <= 0 || !e.gameObject.activeSelf);
        }
        if (Player.Health.CurrentHp > 0)
        {
            battleLog.AddMessage("Вы победили!");
            yield return new WaitForSeconds(1.5f);
            OpenShop();
        }
        else
        {
            battleLog.AddMessage("Вы проиграли!");
            // экран поражения
        }
    }

    private void OpenShop()
    {
        if (battleLog != null)
        battleLog.ClearLog();

        BattlePanel.SetActive(false);
        ShopPanel.SetActive(true);
        Debug.Log("Magaz");
    }
}
