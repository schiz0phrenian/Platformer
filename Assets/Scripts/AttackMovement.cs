using UnityEngine;
using System.Collections;

public class AttackMovement : MonoBehaviour
{
    private Vector3 startPos;
    public float moveDistance = 1f;
    public float speed = 6f;

    public IEnumerator PlayAttack(bool moveRight)
    {
        startPos = transform.position;
        Vector3 targetPos = startPos + (moveRight ? Vector3.right : Vector3.left) * moveDistance;

        // движение вперёд
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            if (this == null) yield break;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        // небольшая задержка (удар)
        yield return new WaitForSeconds(0.1f);

        // возвращение назад
        while (Vector3.Distance(transform.position, startPos) > 0.01f)
        {
            if(this == null) yield break;
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            yield return null;
        }
    }
}
