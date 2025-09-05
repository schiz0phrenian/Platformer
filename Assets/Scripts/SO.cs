using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "Enemy")]
public class SO : ScriptableObject
{
    public string enemyName;
    public Entity prefab;   // ссылка на префаб врага
    public int maxHp;
    public int damage;
}
