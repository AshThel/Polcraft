using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> slots = new List<GameObject>();

    public string itemToLookUp { get; private set; }

    void Update () {
		
	}
    public bool AddItem(Item itemToAdd, int amount)
    {
        //return true;
        Slot emptySlot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToAdd)
            {
                currentSlot.AddItem(itemToAdd, amount);
                return true;
            }
            else if (currentSlot.myItem == null && emptySlot == null)
            {
                emptySlot = currentSlot;
            }
        }                  
         if (emptySlot != null)
        {
            emptySlot.AddItem(itemToAdd, amount);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveItem(Item itemToRemove, int amount)
    {
        for(int i =0; i<slots.Count; i++)
        {
            Slot currentSlot=slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToRemove)
            {
                currentSlot.RemoveItem(amount);
            }
        }
    }
    //Crafting
    public bool HasItem(Item theItem, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent <Slot>().myItem != null)
            {
                if (slots[i].GetComponent<Slot>().myItem.itemName == itemToLookUp && slots[i].GetComponent<Slot>().myAmount >= amount)
                {
                    return true;
                }
            }
            
        }
        return false;
    }
}
