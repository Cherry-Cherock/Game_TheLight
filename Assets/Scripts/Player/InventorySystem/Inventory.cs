using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Player.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int _size = 8;

        [SerializeField] 
        private List<InventorySlot> _slots;

        private void OnValidate()
        {
            AdjustSize();
        }

        private void AdjustSize()
        {
            _slots ??= new List<InventorySlot>();
            if(_slots.Count > _size) _slots.RemoveRange(_size,_slots.Count-_size);
            if(_slots.Count< _size) _slots.AddRange(new InventorySlot[_size-_slots.Count]);
        }

        public bool IsFull()
        {
            return _slots.Count(slot => slot.HasItem) >= _size;
        }

        public bool CanAcceptItem(ItemStack itemStack)
        {
            var slotWithStackableItem = FindSlot(itemStack.Item, true);
            return !IsFull() || slotWithStackableItem != null;
        }

        private InventorySlot FindSlot(ItemDefinition item, bool onlyStackable = false)
        {
            return _slots.FirstOrDefault(slot => slot.Item == item &&
                                                 item.IsStackable ||
                                                 !onlyStackable);
        }

        public ItemStack AddItem(ItemStack itemStack)
        {
            var relevantSlot = FindSlot(itemStack.Item, true);
            if (IsFull() && relevantSlot == null)
            {
                throw new InventoryException(ErrorAction.Add, "Inventory is full!");
            }

            if (relevantSlot != null)
            {
                relevantSlot.NumberOfItems += itemStack.NumberOfItems;
            }
            else
            {
                relevantSlot = _slots.First(slot => !slot.HasItem);
                relevantSlot.State = itemStack;
            }
            return relevantSlot.State;
        }
    }
}

