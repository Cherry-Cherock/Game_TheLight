using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Player.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] 
    private Inventory _inventory;
    
    [SerializeField]
    private int _slotIndex;
    
    [SerializeField]
    private Image _itemIcon;
    
    
    
    [SerializeField]
    private Image _activeIndicator;
    
    [SerializeField]
    private TMP_Text _numberOfItems;
    [SerializeField]
    private TMP_Text _canUse;
    private InventorySlot _slot;

    private void Start()
    {
        AssignSlot(_slotIndex);
    }

    public void AssignSlot(int slotIndex)
    {
        if (_slot != null) _slot.StateChange -= OnStateChanged;
        _slotIndex = slotIndex;
        if (_inventory == null) _inventory = GetComponentInParent<InventoryUI>().Inventory;
        _slot = _inventory.Slots[_slotIndex];
        _slot.StateChange += OnStateChanged;
        UpdateViewState(_slot.State, _slot.Active);
    }

    private void UpdateViewState(ItemStack state,bool active)
    {
        _activeIndicator.enabled = active;
        var item = state?.Item;
        var hasItem = item != null;
        var isStackable = hasItem && item.IsStackable;
        var canBeUsed = hasItem && item.CanBeUsed && active;
        _itemIcon.enabled = hasItem;
        _numberOfItems.enabled = isStackable;
        _canUse.enabled = canBeUsed;
        if (!hasItem) return;
        _itemIcon.sprite = item.UiSprite;
        if(isStackable) _numberOfItems.SetText(state.NumberOfItems.ToString());
        if(canBeUsed) _canUse.SetText("E");
    }

    private void OnStateChanged(object sender, InventorySlotStateChangeMsg args)
    {
        UpdateViewState(args.NewState, args.Active);
    }
}
