using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
public int MaxHealth
public int CurrentHealth
public UnityEvent OnDeath

public void Die() {
    // Destroy(gameObject)
}

/*
public void TakeDamage(DamegeMessage msg) {
    Value -= msg.damage
    if Value <= 0 {
        OnDeath?.Invoke()
    }
}
*/

}
