using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public List<SO> enemies;
    public BattleManager battleManager;
    public AttackMovement PlayerMovement;

    [Header("UI Panels")]
    public GameObject ShopPanel;

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        var so = enemies[Random.Range(0, enemies.Count)];
        var enemyObj = Instantiate(so.prefab, new Vector3(5, 0, 0), Quaternion.identity); // xz
        var enemy = enemyObj.GetComponent<Enemy>();
        enemy.data = so;

        battleManager.StartBattle(player, enemy);
    }

}
