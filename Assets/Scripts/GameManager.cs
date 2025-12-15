using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public List<EnemySO> enemies;
    public BattleManager battleManager;
    public AttackMovement PlayerMovement;

    [Header("UI Panels")]
    public GameObject ShopPanel;

    void Start()
    {
        battleManager.OpenShop();
    }

    public void SpawnEnemy()
    {
        var so = enemies[Random.Range(0, enemies.Count)];
        var enemyObj = Instantiate(so.prefab, new Vector3(3, -1, 0), Quaternion.identity); // xz
        var enemy = enemyObj.GetComponent<Enemy>();
        enemy.data = so;

        battleManager.StartBattle(player, enemy);
    }

}
