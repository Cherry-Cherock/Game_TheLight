using System;
using UnityEngine;


namespace Player.InventorySystem
{
    [Serializable]
    public class ItemStack
    {
        [SerializeField]
        private ItemDefinition _item;
        
        [SerializeField]
        private int _numberOfItems;

        public bool IsStackable => _item != null && _item.IsStackable;
        public ItemDefinition Item
        {
            get => _item;
            set => _item = value;
        }

        public void SetItem(ItemDefinition i)
        {
            _item = i;
        }

        public int NumberOfItems
        {
            get => _numberOfItems;
            set
            {
                value = value < 0 ? 0 : value;
                _numberOfItems = IsStackable ? value : 1;
            }
        }

        public ItemStack(ItemDefinition item, int numberOfItems)
        {
            _item = item;
            NumberOfItems = numberOfItems;
        }
        
        public ItemStack() {}
        
        
    }
}

