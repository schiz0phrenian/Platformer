using System.Collections;
using UnityEngine;

public class AttackMovement : MonoBehaviour
{
    public float moveDistance = 0.5f;   // на сколько юнит двигается
    public float moveSpeed = 4f;        // скорость движения

    private Vector3 startPos;

    public void PlayAttack(Vector3 targetPosition)
    {
        if (!isActiveAndEnabled) return;
        StopAllCoroutines();
        startPos = transform.position;
        StartCoroutine(AttackCoroutine(targetPosition));
    }

    private IEnumerator AttackCoroutine(Vector3 targetPosition)
    {
        Vector3 attackPos = startPos + (targetPosition - startPos).normalized * moveDistance;

        // Двигаемся к цели
        while (Vector3.Distance(transform.position, attackPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, attackPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Немного задержка для удара
        yield return new WaitForSeconds(0.1f);

        // Возвращаемся на старт
        while (Vector3.Distance(transform.position, startPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
