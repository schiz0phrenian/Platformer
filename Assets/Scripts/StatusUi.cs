using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUi : MonoBehaviour
{
    public Player player;
    public TMP_Text hpText;
    public TMP_Text dmgText;
    public TMP_Text coinsText;

    void Update()
    {
        if (player != null)
        {
            hpText.text = $"HP:{player.currentHp}";
            dmgText.text = $"DMG:{player.damage}";
            coinsText.text = $"Coins: {player.coins}";
        }
    }
    
}
