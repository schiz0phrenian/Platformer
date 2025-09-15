using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Entity player;
    public BattleLog battleLog;

    public void BuyHelmet()
    {
        player.Health.MaxHealth += 10;
        player.Health.CurrentHp = player.Health.MaxHealth;
        battleLog.AddMessage("Куплен шлем (+10 HP)");
    }
    public void BuyWeapon()
    {
        player.Attack.Damage += 5;
        battleLog.AddMessage("Вы купили оружие(+5 DMG)");
    }
    public void BuyArtifact()
    {
        //добавлю разные статы
        battleLog.AddMessage("Вы купили аретфакт");
    }

}
