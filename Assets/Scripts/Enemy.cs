using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO data;
    public int currentHp;
    public AttackMovement movement;

    void Awake()
    {
        currentHp = data.maxHp;
    }
    public void TakeDamage(int dmg)
    {
        currentHp -= dmg;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (movement != null)
        movement.StopAllCoroutines();
        // начинаем корутину уничтожения
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        // даём время корутине PlayAttack завершиться (например 0.5–0.7 сек)
        yield return new WaitForSeconds(0.5f);

        // даём награду игроку
        Player player = FindObjectOfType<Player>();
        if (player != null)
            player.OnEnemyKilled(data.reward);
            
        // теперь уничтожаем объект
        Destroy(gameObject);
    }


    public void OnAttackPlayer(Player player)
    {
        player.TakeDamage(data.damage);
    }

    public IEnumerator AttackAnimation(Player player)
{
    yield return movement.PlayAttack(false);
}

}
