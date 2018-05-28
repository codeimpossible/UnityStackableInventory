using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryList : ScriptableObject {

    public List<InventorySpot> Items;

    public event EventHandler<EventArgs> ItemAdded;
    public event EventHandler<EventArgs> ItemRemoved;

    public void AddItem(InventoryObject item)
    {
        var slot = GetInventorySlot(item);
        if (slot == null)
        {
            slot = new InventorySpot() { Count = 0, ItemType = item };
            Items.Add(slot);
        }
        slot.Count++;
        if (ItemAdded != null) ItemAdded(this, EventArgs.Empty);
    }

    public void RemoveItem(InventoryObject item)
    {
        var slot = GetInventorySlot(item);
        if (slot != null && slot.Count > 0)
        {
            slot.Count--;
            if (ItemRemoved != null) ItemRemoved(this, EventArgs.Empty);
        }

        if (slot != null && slot.Count == 0) Items.Remove(slot);
    }

    private InventorySpot GetInventorySlot(InventoryObject item)
    {
        foreach(var slot in Items)
        {
            if (slot.ItemType == item)
                return slot;
        }
        return null;
    }
}
