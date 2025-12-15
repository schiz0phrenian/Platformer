using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Player player;
    
    public void BuyArtefact(ArtefactSO artefact)
    {
        if(player.coins >= artefact.cost)
        {
            player.coins -= artefact.cost;
            artefact.Apply(player);//Вызывает эффект артефакта на игроке
        }
        else
        {
            Debug.Log("No money");
        }
        
    }
}
