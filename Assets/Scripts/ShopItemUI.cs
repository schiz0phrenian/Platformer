using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemUI : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public ArtefactSO artefact;
    public ArtefactUI tooltip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Show(artefact);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Hide();
    }
}