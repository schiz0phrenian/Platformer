using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy currentEnemy;
    public GameManager gameManager;
  
    private bool battleActive;
    public void StartBattle(Player p, Enemy e)
    {
        player = p;
        currentEnemy = e;

        player.playerTurn = 0f;
        currentEnemy.enemyTurn = 0f;

        battleActive = true;
        StartCoroutine(BattleLoop());
    }

    private IEnumerator BattleLoop()
    {
        yield return new WaitForSeconds(1f);
        
        while (battleActive)
        {
            if (player.currentHp <= 0 || currentEnemy.currentHp <= 0)
                break;  
            //накопление шкалы
            player.playerTurn += player.speed * Time.deltaTime;
            currentEnemy.enemyTurn += currentEnemy.speed * Time.deltaTime;


            if (player.playerTurn >= 100f)
            {
                player.playerTurn = 0f;
                player.OnAttackEnemy(currentEnemy);
            }
            if (currentEnemy.enemyTurn >= 100f)
            {
                currentEnemy.enemyTurn = 0f;
                currentEnemy.OnAttackPlayer(player);
            }

            yield return null;
        }

        battleActive = false;
        
        if(player.currentHp > 0)
        {
            Debug.Log("Win");
            gameManager.OpenMain();
        }

        else
        {
            Debug.Log("Lose");
            gameManager.OpenMain();
        }
    }

    
}