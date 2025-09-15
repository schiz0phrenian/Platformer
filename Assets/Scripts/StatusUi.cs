using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUi : MonoBehaviour
{
    public Entity player;
    public TMP_Text hpText;
    public TMP_Text dmgText;
    public TMP_Text coinsText;

    void Update()
    {
        if (player != null && player.Health != null && player.Attack != null)
        {
            hpText.text = $"HP:{player.Health.MaxHealth}";
            dmgText.text = $"DMG:{player.Attack.Damage}";
            coinsText.text = $"Coins: {player.Coins}";
        }
    }
    
}
