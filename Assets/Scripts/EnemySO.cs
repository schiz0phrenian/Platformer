using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public GameObject prefab;   // ссылка на префаб врага
    public int maxHp;
    public int damage;
    public int reward;
}
