using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace Player.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int _size = 8;
        public int Size => _size;
      
        [SerializeField] 
        private List<InventorySlot> _slots;
        public List<InventorySlot> Slots => _slots;

        private int _activeSlotIndex;

        public int ActiveSlotIndex
        {
            get => _activeSlotIndex;
            private set
            {
                _slots[_activeSlotIndex].Active = false;
                _activeSlotIndex = value < 0 ? _size - 1 : value % Size;
                _slots[_activeSlotIndex].Active = true;
            }
        }

        private void Awake()
        {
            if (_size>0)
            {
                _slots[0].Active = true;
            }
        }

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

        public bool HasItem(ItemStack itemStack, bool checkNumberOfItem = false)
        {
            var itemSlot = FindSlot(itemStack.Item);
            if (itemSlot == null) return false;
            if (!checkNumberOfItem) return true;
            
            if (itemStack.Item.IsStackable)
            {
                return itemSlot.NumberOfItems >= itemStack.NumberOfItems;
            }
            return _slots.Count(slot => slot.Item == itemStack.Item) >= itemStack.NumberOfItems;
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
        
        public ItemStack RemoveItem(int atIndex, bool spawn = false)
        {
            if (!_slots[atIndex].HasItem)
                throw new InventoryException(ErrorAction.Remove, "slot is empty!");
            if (spawn && TryGetComponent<ItemDropManager>(out var dropManager))
            {
                dropManager.SpawnItem(_slots[atIndex].State);
            }
            ClearSlot(atIndex);
            return new ItemStack();
        }

        public ItemStack RemoveItem(ItemStack itemStack)
        {
            var itemSlot = FindSlot(itemStack.Item);
            if (itemSlot == null)
            {
                throw new InventoryException(ErrorAction.Remove, "No item in inventory!");
            }

            if (itemSlot.Item.IsStackable && itemSlot.NumberOfItems < itemStack.NumberOfItems)
            {
                throw new InventoryException(ErrorAction.Remove, "Not enough items!");
            }

            itemSlot.NumberOfItems -= itemStack.NumberOfItems;
            if (itemSlot.Item.IsStackable && itemSlot.NumberOfItems > 0)
            {
                return itemSlot.State;
            }
            itemSlot.Clear();
            return new ItemStack();
        }

        public void ClearSlot(int atIndex)
        {
            _slots[atIndex].Clear();
        }
        public void ActivateSlot(int atIndex)
        {
            ActiveSlotIndex = atIndex;
        }

        public InventorySlot GetActiveSlot()
        {
            return _slots[ActiveSlotIndex];
        }
    }
}

