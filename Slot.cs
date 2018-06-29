using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
    Image myImage;
    Text myText;
    public Item myItem;
    public int myAmount;

	// Use this for initialization
	void Start ()
    {
        myImage = transform.GetChild(0).GetComponent<Image>();
        myText = transform.GetChild(1).GetComponent<Text>();
        ShowUI();
    }
	public void AddItem(Item itemToAdd, int amount)
    {
        if (itemToAdd == myItem)
        {
            myAmount += amount;
        }
        else
        {
            myItem = itemToAdd;
            myAmount = amount;
        }
    }
    public void RemoveItem(int amount)
    {
        if (myItem != null)
        {
            myAmount -= amount;
            if (myAmount <= 0)
            {
                myImage = null;
            }
        }
    }
    void ShowUI()
    {
        if (myItem != null)
        {
            myImage.enabled = true;
            myText.enabled = true;
            myImage.sprite = myItem.itemIcon;
            myText.text = myAmount.ToString();
        }
        else
        {
            myImage.enabled = false;
            myText.enabled = false;
        }
    }
}
