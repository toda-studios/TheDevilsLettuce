using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class InventorySystem
{
    static bool loaded = false;
    static List<Item> items = new List<Item>();



    class LoadingItem
    {
        public string name;
        public string desc;
        public string type;
    }
    public static Item GetItemByID(string id)
    {
        foreach(Item testItem in items)
        {
            if (testItem.id == id)
                return testItem;
        }
        return null;
    }


    public static void LoadInventory()
    {
        if (loaded)
            return;

        Item noneItem = new Item("none", "NONE", ItemType.NONE, null);
        items.Add(noneItem);


        //Grab all item files
        var itemText = Resources.LoadAll<TextAsset>("Data/Items");

        //Convert text -> item and store data
        foreach (TextAsset item in itemText)
        {
            LoadingItem obj = JsonUtility.FromJson<LoadingItem>(item.text);
            Sprite itemSprite = Resources.Load<Sprite>("Art/Items/" + item.name);

            ItemType typeOitem = ItemType.NONE;

            ItemType.TryParse(obj.type, out typeOitem);

            Item newItem = new Item(item.name, obj.name, typeOitem, itemSprite, obj.desc);

            items.Add(newItem);
            Debug.Log("Loading - item:" + newItem.id);
        }

    }
}

public enum ItemType
{
    NONE, BASIC, TOOL, SEED
}


public class Item
{
    private string itemId;
    private string itemName;
    private ItemType itemType;
    private string itemDesc;
    private Sprite itemSprite;

    public Item(string id, string name, ItemType type, Sprite sprite, string desc = "")
    {
        itemName = name;
        itemDesc = desc;
        itemType = type;
        itemSprite = sprite;
        itemId = id;
    }

    public string id
    {
        get
        {
            return itemId;
        }
    }

    public Sprite sprite
    {
        get
        {
            return itemSprite;
        }
    }

    public string description
    {
        get
        {
            return itemDesc;
        }
    }

    public ItemType TypeOfItem
    {
        get
        {
            return itemType;
        }
    }

    public string name
    {
        get
        {
            return itemName;
        }
    }
}

public class Inventory
{
    public Item[] items;

    //GUI
    Transform guiParent;



    public Inventory(int slots, Transform gridMaster)
    {
        items = new Item[slots];
        Item nothing = InventorySystem.GetItemByID("none");
        for (int i = 0; i < slots; i++)
        {
            items[i] = nothing;
        }

        guiParent = gridMaster;
    }

    public bool AddItemById(string id)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].TypeOfItem == ItemType.NONE)
            {
                items[i] = InventorySystem.GetItemByID(id);
                UpdateGUI();
                return true;
            }
        }
        Debug.LogWarning("Inventory full! Could not add: " + id);
        return false;
    }

    public bool HasItem(string id)
    {
        Item itemToHave = InventorySystem.GetItemByID(id);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToHave)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(string id)
    {
        Item itemToRemove = InventorySystem.GetItemByID(id);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = InventorySystem.GetItemByID("none");
                UpdateGUI();
                return true;
            }
        }
        Debug.LogError("Tried to remove item player does not have!");
        return false;
    }


    public void UpdateGUI()
    {
        if (guiParent != null)
        {
            for (int i = 0; i < guiParent.childCount; i++)
            {
                Transform itemDisplay = guiParent.GetChild(i);
                Object.Destroy(itemDisplay.gameObject);
            }
            foreach (Item item in items)
            {
                GameObject gobj = MakeItemDisplay(item);
                gobj.transform.SetParent(guiParent);
            }
        }
        else
        {
            Debug.LogError("Cannot update inventory GUI when GUI is not setup!");
        }
    }

    GameObject MakeItemDisplay(Item item)
    {
        GameObject itemDisplay = new GameObject();
        if(item != null & item.TypeOfItem != ItemType.NONE)
        {
            Image image = itemDisplay.AddComponent<Image>();
            ItemSlot slotThing = itemDisplay.AddComponent<ItemSlot>();
            slotThing.item = item;

            image.sprite = item.sprite;
            itemDisplay.name = item.id;
        }
        else
        {
            itemDisplay.name = ItemType.NONE.ToString();
        }

        return itemDisplay;
    }

}
