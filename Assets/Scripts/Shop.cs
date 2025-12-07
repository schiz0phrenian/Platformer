using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Player player;

    public void BuyHelmet()
    {
        if(player.coins >= 5){
            player.maxHealth += 10;
            player.currentHp = player.maxHealth;
        }
    }
    public void BuyWeapon()
    {
        player.damage += 5;
    }
    public void BuyArtifact()
    {   
        //добавлю разные статы
        player.damage += 2;
        player.maxHealth += 5;
        player.currentHp = player.maxHealth;
    }

}
