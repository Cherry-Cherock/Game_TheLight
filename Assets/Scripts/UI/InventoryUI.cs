using System.Collections;
using System.Collections.Generic;
using Player.InventorySystem;
using UnityEditor;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private  GameObject _inventorySlotPrefeb;

    [SerializeField] 
    private Inventory _inventory;

    [SerializeField] 
    private List<InventorySlotUI> _slots;

    public Inventory Inventory => _inventory;

    [ContextMenu("init Inventory")]
    private void InitializeInventoryUI()
    {
        if (_inventory == null || _inventorySlotPrefeb == null) return;
        _slots = new List<InventorySlotUI>(_inventory.Size);
        for (var i = 0; i < _inventory.Size; i++)
        {
            var uiSlot = PrefabUtility.InstantiatePrefab(_inventorySlotPrefeb) as GameObject;
            uiSlot.transform.SetParent(transform, false);
            var uiSlotScript = uiSlot.GetComponent<InventorySlotUI>();
            uiSlotScript.AssignSlot(i);
            _slots.Add(uiSlotScript);
        }
    }
}
