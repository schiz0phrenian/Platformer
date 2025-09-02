using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    

public List<Health> Targets
public Health target
public int Damage

public Action OnTargetDead
//publci Entity targetEnt

public void MakeATurn(){
    target.value -= damage
    if (target.value <= 0) {
        target.Die()
        OnTargetDead?.Invoke()
           
        Targets.Remove(target)
        if (Targets.Count > 0){
            target = Targets[0]
        }
        
    }
}
public void SetTarget(Health target) { this.target =target }

public void SetTargets(List<Health> targets) {}

}
