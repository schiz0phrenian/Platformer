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
    void Awake()
    {
        player.currentHp = player.maxHealth;
    }
    void Update()
    {
        if (player != null)
        {
            hpText.text = $"{player.currentHp}/{player.maxHealth}";
            dmgText.text = $"{player.damage}";
            coinsText.text = $"{player.coins}";
        }
    }
    
}
