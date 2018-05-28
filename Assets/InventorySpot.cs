using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class InventorySpot {

    public InventoryObject ItemType;
    public int Count;

    // these could also be extension methods to keep the object slim (if it needs to be a SO)
    public bool AddItem(InventoryObject item)
    {
        if (item != ItemType) return false;
        Count++;
        return true; // used by inventory to trigger Item_Added events (local and global)
    }

    public InventoryObject RemoveItem()
    {
        if (Count == 0) return null;
        Count--;
        return ItemType; // used by inventory to trigger Item_Removed events (local and global)
    }
}
