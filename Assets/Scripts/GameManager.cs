using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public List<EnemySO> enemies;
    public BattleManager battleManager;

    [Header("UI Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject battleBG;
    [SerializeField] private GameObject battleGamePanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject buttons;
  
    [Header("PlayerPosition")]
    [SerializeField] private Transform mainPlayerPosition;
    [SerializeField] private Transform battlePlayerPosition;

    void Start()
    {
        OpenMain();
    }

    public void SpawnEnemy()
    {
        var so = enemies[Random.Range(0, enemies.Count)];
        var enemyObj = Instantiate(so.prefab, new Vector3(5, -1, 0), Quaternion.identity); // xz
        var enemy = enemyObj.GetComponent<Enemy>();
        enemy.data = so;

        battleManager.StartBattle(player, enemy);
    }
    public void OpenMain()
    {
        mainPanel.SetActive(true);
        buttons.SetActive(true);
        battleBG.SetActive(false);
        battleGamePanel.SetActive(false);
        player.transform.position = mainPlayerPosition.position;

    }
    
    public void CloseMain()
    {
        mainPanel.SetActive(false);
        buttons.SetActive(false);
        battleBG.SetActive(true);
        battleGamePanel.SetActive(true);
        SpawnEnemy();
        player.transform.position = battlePlayerPosition.position;
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        mainPanel.SetActive(false);
        buttons.SetActive(false);
    }
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        mainPanel.SetActive(true);
        buttons.SetActive(true);
    }
}
