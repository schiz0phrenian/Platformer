using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy currentEnemy;
    public GameManager gameManager;
    public GameObject mainPanel;
    public GameObject battlePanel;

    private bool playerTurn = true;

    public void StartBattle(Player p, Enemy e)
    {
        player = p;
        currentEnemy = e;
        StartCoroutine(BattleLoop());
    }

    private IEnumerator BattleLoop()
    {
        yield return new WaitForSeconds(1f);
        while (player.currentHp >= 0 && currentEnemy.currentHp >= 0)
        {
            if (playerTurn)
            {
                player.OnAttackEnemy(currentEnemy);
                playerTurn = false;
            }
            else
            {
                currentEnemy.OnAttackPlayer(player);
                playerTurn = true;
            }
            yield return new WaitForSeconds(1f);
        }
        if(player.currentHp > 0)
        {
            Debug.Log("Победа");
            OpenMain();
            
        }
        else
        {
            Debug.Log("Поражение");
        }
    }

    public void OpenMain()
    {
        mainPanel.SetActive(true);
        battlePanel.SetActive(false);
    }
    public void CloseMain()
    {
        mainPanel.SetActive(false);
        battlePanel.SetActive(true);
        gameManager.SpawnEnemy();
    }

}
