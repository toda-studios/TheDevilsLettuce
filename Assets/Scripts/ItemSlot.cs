using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    static Descriptor_manager desc_manger = null;

    private void Start()
    {
        if (desc_manger == null)
        {
            desc_manger = GameObject.FindObjectOfType<Descriptor_manager>();
            desc_manger.gameObject.SetActive(false);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        desc_manger.SetData(item.name, item.TypeOfItem.ToString(), item.description);
        desc_manger.gameObject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        desc_manger.gameObject.SetActive(false);
    }

}
