using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HpBar : MonoBehaviour
{
    public Image hpBar;
    public Player player;
    void Start()
    {
        hpBar = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        hpBar.fillAmount = player.currentHp/player.maxHealth;
    }
}
