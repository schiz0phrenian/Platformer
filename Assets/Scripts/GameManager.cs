using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Entity Player
public List<Entity> CurrentEnemies = new()


public Entity enemy_1
public Entity enemy_2
public Entity enemy_3

//public List<Entity> EnemiesPrefabs = new()

public void SpawnEnemies() {
    var prefab = enemy_1 //(Любой алгоритм который выдает врага или список врагов)
    //цикл если врагов много
   
    var inst = Instantiate(prefab, /*pos, */)
    // entity.Restore() если враги уже на сцене
    inst.Attack.target = Player.Health

    enemy_1.Restore()

    CurrentEnemies.Add(inst)

    Player.Attack.SetTarget(CurrentEnemies[0].GetComponent<Health>)
    Player.Attack.SetTargets(CurrentEnemies)
    //Player.Attack.SetTarget(inst)

}

public void StartBattle() {
    StartCoroutine(Battle())
}

private IEnumerator Battle() {

    while (Player.Health > 0 || CurrentEnemies.Count > 0) {
        Player.Attack.MakeATurn()
        yield new WaitForSeconds(0.5)

        foreach (e in CurrentEnemies) {
            e.Attack.MakeATurn()
            yield new WaitForSeconds(0.5)
        }        
    }

    // load ui
    // show shop 
    
}

}
