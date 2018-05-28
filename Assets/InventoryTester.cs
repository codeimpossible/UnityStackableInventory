using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : MonoBehaviour {

    public InventoryList Inventory;

    public InventoryObject ObjectOne;
    public InventoryObject ObjectTwo;

	public void AddObjectOne()
    {
        Inventory.AddItem(ObjectOne);
    }

    public void AddObjectTwo()
    {
        Inventory.AddItem(ObjectTwo);
    }

    public void RemoveObjectOne()
    {
        Inventory.RemoveItem(ObjectOne);
    }

    public void RemoveObjectTwo()
    {
        Inventory.RemoveItem(ObjectTwo);
    }
}
