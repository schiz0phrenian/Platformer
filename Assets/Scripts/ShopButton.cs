using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public ArtefactSO artefact;
    public Shop shop;

    public void Buy()
    {
        shop.BuyArtefact(artefact);
    }
}
