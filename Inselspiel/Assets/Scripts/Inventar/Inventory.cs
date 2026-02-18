using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public ItemSO RS3;
    
    public GameObject hotbarObj;
    public GameObject inventorySlotParent;

    private List<Slot> inventorySlots = new List<Slot>();
    private List<Slot> hotbarSlots = new List<Slot>();
    private List<Slot> allSlots = new List<Slot>();

    private void Awake()
    {
        inventorySlots.AddRange(inventorySlotParent.GetComponentsInChildren<Slot>());
        hotbarSlots.AddRange(hotbarObj.GetComponentsInChildren<Slot>());
        allSlots.AddRange(inventorySlots);
        allSlots.AddRange(hotbarSlots);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddItem(RS3, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItem(RS3, 3);
        }
    }

    public void AddItem(ItemSO itemToAdd, int amount)
    {
        int remanining = amount;

        foreach (Slot slot in allSlots)
        {
            if(slot.HasItem() && slot.GetItem() == itemToAdd)
            {
               int currentAmount = slot.GetItemAmount();
                int maxStack = itemToAdd.maxStackSize;

                if (currentAmount < maxStack)
                {
                    int spaceLeft = maxStack - currentAmount;
                    int amountToAdd = Mathf.Min(spaceLeft, remanining);

                    slot.SetItem(itemToAdd, currentAmount + amountToAdd);
                    remanining -= amountToAdd;
                    if (remanining <= 0)
                        return;
                    
                  
                }
            }
        }

        foreach (Slot slot in allSlots)
        {
            if (!slot.HasItem())
            {
                int amountToPlace = Mathf.Min(itemToAdd.maxStackSize, remanining);
                slot .SetItem(itemToAdd, amountToPlace);
                remanining -= amountToPlace;

                if (remanining <= 0)
                    return;
            }   
               
        }

        if(remanining > 0)
        {
            Debug.Log("Inventory is full" + remanining + " of " + itemToAdd.itemName);
        }

    }

}
