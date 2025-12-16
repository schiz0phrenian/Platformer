
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public abstract class ArtefactSO : ScriptableObject
{
    public string artefactName;
    [TextArea]
    public string description;
    public Sprite icon;
    public int cost;

    public abstract void Apply(Player player); //метод для дочерних артефактов, 
    // все вышепредоставленные методы осуществляются все равно
}
