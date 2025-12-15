using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Artefact/Damage")]
public class ArtefactDamage : ArtefactSO
{
    public int damage;

    public override void Apply(Player player)
    {
        player.damage += damage;
    }
}
