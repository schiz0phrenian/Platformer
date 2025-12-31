using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "Artefact/Health")]
public class ArtefactHealth : ArtefactSO
{
   public int bonusHp;
    public override void Apply(Player player) // берем родительский компонент
    {
        player.maxHealth += bonusHp;
        player.currentHp += bonusHp;
    }
}
