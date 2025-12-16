using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArtefactUI : MonoBehaviour
{
    public TMP_Text nameArt;
    public TMP_Text description;
    public TMP_Text price;

    public RectTransform rect;
    public Canvas canvas;
    public Vector2 offset = new Vector2(20, -20);
    public void Show(ArtefactSO artefact)
    {
        nameArt.text = artefact.artefactName;
        description.text = artefact.description;
        price.text = $"{artefact.cost}";

        UpdatePosition();
        gameObject.SetActive(true);
        /*
        price.color = player.coins >= artefact.cost
        ? Color.green
        : Color.red;
        */
    }
    void Update()
    {
        if (gameObject.activeSelf)
            UpdatePosition();
    }
    
    void UpdatePosition()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPos
        );

        rect.localPosition = localPos + offset;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
