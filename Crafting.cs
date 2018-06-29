using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {

    public ItemDatabase dataBase;
    public Inventory inventory;
    public GameObject craft;
    public GameObject slot;

    void Start()
    {
        GenSlots();
    }
    void GenSlots()
    {
        for (int i=0; i<dataBase.dataBaseItems.Count; i++)
        {
            Item currentItem = dataBase.dataBaseItems[i];
            if (currentItem.isCraftable)
            {
                GameObject go = Instantiate(slot, craft.transform.position, Quaternion.identity);
                go.transform.SetParent(craft.transform);
                go.GetComponent<Slot>().myItem = currentItem;
            }
        }
    }
    public void CraftItem(Item itemToCraft)
    {
        if (itemToCraft.isCraftable)
        {
            if (CanCraft(itemToCraft))
            {
                Add(itemToCraft);
            }
            else
            {
                print("Nie można stworzyć");
            }
        }
        else
        {
            return;
        }
    }
    bool CanCraft(Item itemToLookUp)
    {
        for (int i = 0; i< itemToLookUp.craftItems.Count; i++){
            Item currentItem = itemToLookUp.craftItems[i];
            int currentAmount = itemToLookUp.craftAmount[i];
            /*if (!inventory.HasItem(currentItem.itemName, currentAmount))
            {
                return false;
            }*/
        }
        return true;
    }
    void Add(Item itemToAdd)
    {
        inventory.AddItem(itemToAdd, itemToAdd.makesHowMany);
        Remove(itemToAdd);
    }
    void Remove(Item itemToRemove)
    {
        for (int i=0; i< itemToRemove.craftItems.Count; i++)
        {
            Item currentItem = itemToRemove.craftItems[i];
            int currentAmount = itemToRemove.craftAmount[i];
            inventory.RemoveItem(currentItem, currentAmount);

        }
    }
    
}
