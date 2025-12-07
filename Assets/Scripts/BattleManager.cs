using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy currentEnemy;
    public GameManager gameManager;
    public GameObject shopPanel;
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
                yield return player.AttackAnimation(currentEnemy);
                player.OnAttackEnemy(currentEnemy);
                playerTurn = false;
            }
            else
            {
                yield return currentEnemy.AttackAnimation(player);
                currentEnemy.OnAttackPlayer(player);
                playerTurn = true;
            }
            yield return new WaitForSeconds(1f);
        }
        if(player.currentHp > 0)
        {
            Debug.Log("Победа");
            OpenShop();
            
        }
        else
        {
            Debug.Log("Поражение");
        }
    }

    void OpenShop()
    {
        shopPanel.SetActive(true);
        battlePanel.SetActive(false);
        Debug.Log("Магазин открыт");
    }
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        battlePanel.SetActive(true);
        gameManager.SpawnEnemy();
        Debug.Log("начало битвы");
    }

}
