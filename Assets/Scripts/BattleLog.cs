using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleLog : MonoBehaviour
{
    public TMP_Text logText;
    public ScrollRect scrollRect;


    public void AddMessage(string message)
    {
        logText.text += message + "\n";

        // обновляем Layout, чтобы ScrollView понял размер контента
        Canvas.ForceUpdateCanvases();

    }
    
    public void ClearLog()
    {
        logText.text = "";
    }
}
