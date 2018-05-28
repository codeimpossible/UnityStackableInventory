using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public InventoryList TargetInventory;

    public Transform InventorySlotDisplayObject;

    private bool _isDirty;
    private Coroutine _routine;
    private bool _isRefreshing;

	void Start ()
    {
        TargetInventory.ItemAdded += TargetInventory_ItemAdded;
        TargetInventory.ItemRemoved += TargetInventory_ItemRemoved;
        _isDirty = true;
	}

    private void TargetInventory_ItemRemoved(object sender, System.EventArgs e)
    {
        _isDirty = true;
    }

    private void TargetInventory_ItemAdded(object sender, System.EventArgs e)
    {
        _isDirty = true;
    }

    void Update ()
    {
		if (_isDirty)
        {
            _isDirty = false;
            if (_routine != null && _isRefreshing)
            {
                StopCoroutine(_routine);
            }
            _routine = StartCoroutine(Refresh());
        }
	}

    public IEnumerator Refresh()
    {
        _isRefreshing = true;
        var limit = Mathf.Max(TargetInventory.Items.Count, transform.childCount);
        for (int i = 0; i < limit; i++)
        {
            Transform child;
            if (i >= transform.childCount)
            {
                var go = Instantiate(InventorySlotDisplayObject);
                go.parent = transform;
                child = go.transform;
                child.transform.localScale = Vector3.one;
            }
            else
            {
                child = transform.GetChild(i);
            }
            
            if (i >= TargetInventory.Items.Count)
            {
                child.gameObject.SetActive(false);
                continue;
            }
            child.gameObject.SetActive(true);
            var item = TargetInventory.Items[i];
            var button = child.GetComponent<Button>();
            var label = button.GetComponentInChildren<Text>();
            label.text = item.Count + "x " + item.ItemType.Description;
            yield return null;
        }
        _isRefreshing = false;
    }
}
