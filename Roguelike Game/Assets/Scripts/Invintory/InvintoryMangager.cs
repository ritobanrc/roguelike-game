﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvintoryMangager
{

    /// <summary>
    /// List of the items in 
    /// </summary>
    public InventoryItem[] inventory;

    /// <summary>
    /// Defines a size for the inventory
    /// </summary>
    public int InventorySize = 40;

    /// <summary>
    /// Defines the size of the stack
    /// </summary>
    public int StackSize = 128;

    /// <summary>
    /// Sets up array
    /// </summary>
    public InvintoryMangager()
    {
        inventory = new InventoryItem[InventorySize];
        for (int i = 0; i < InventorySize; i++)
        {
            inventory[i] = new InventoryItem(-1);
        }
    }

    /// <summary>
    /// returns the slot as int
    /// </summary>
    /// <returns></returns>
    public int ItemAsInt(int place)
    {
        if (place >= InventorySize) place = InventorySize - 1;
        return inventory[place].item;
    }

    public int StackAsInt(int place)
    {
        if (place >= InventorySize) place = InventorySize - 1;
        return inventory[place].stackAsi();
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNub"></param>
    /// <returns></returns>
    public bool AddItem(int itemType, int itemNum = 1)
    {
        // Searches through the entire inventory to see if there is a slot with the same items
        for (int i = 0; i < InventorySize; i++)
        {
            // So if there already is an item in this slot (I think this is useless)s
            if (inventory[i].item != -1)
            {
                // the slot has the same itemtype
                if (inventory[i].item == itemType)
                {
                    for (int n = itemNum; n > 0; n--)
                    {
                        if (inventory[i].stackAsi() + n <= StackSize)
                        {
                            inventory[i].AddToStack(n);
                            itemNum -= n;
                            if (itemNum == 0) return true;
                        }
                    }
                    // And the this won't overflow the stack
                    
                }
            }
        }
        bool completed = false;
        while (!completed)
        {
            int add = itemNum;
            while (add > StackSize)
            {
                for (int i = 0; i < InventorySize; i++)
                {
                    if (inventory[i].item == -1)
                    {
                        inventory[i].setItem(itemType);
                        inventory[i].AddToStack(StackSize);
                        break;
                    }
                }
                add -= StackSize;
            }
            for (int i = 0; i < InventorySize; i++)
            {
                if (inventory[i].item == -1)
                {
                    inventory[i].setItem(itemType);
                    inventory[i].AddToStack(add);
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Removes an item from the inventory
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNum"></param>
    /// <returns></returns>
    public bool RemoveItem(int itemType, int itemNum = 1)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (inventory[i].item != -1)
            {
                if (inventory[i].item == itemType)
                {
                    if (inventory[i].stackAsi() < StackSize)
                    {
                        if (inventory[i].RemoveFromStack(itemNum)) inventory[i] = null;
                        return true;
                    }
                }
            }
            else break;
        }
        return false;
    }
}