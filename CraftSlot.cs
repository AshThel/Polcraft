using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CraftSlot : MonoBehaviour, IPointerClickHandler {

    Crafting craftingScript;
    public Item myItem;
    Image myIcon;
	// Use this for initialization
	void Start () {
        if (myItem == null)
        {
            Destroy(gameObject);
        }
        craftingScript = GameObject.FindObjectOfType<Crafting>();
        myIcon.sprite = myItem.itemIcon;
	}
	public void OnPointerClick(PointerEventData eventData)
    {
        craftingScript.CraftItem(myItem);
    }
}
