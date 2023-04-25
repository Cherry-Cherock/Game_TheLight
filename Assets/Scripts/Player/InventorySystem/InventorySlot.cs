using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


namespace Player.InventorySystem
{
    [Serializable]
    public class InventorySlot
    {
        public event EventHandler<InventorySlotStateChangeMsg> StateChange;
        [SerializeField] 
        private ItemStack _state;

        private bool _active;

        public ItemStack State
        {
            get => _state;
            set
            {
                _state = value;
                NotifyAboutStateChange();
            }
        }

        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                NotifyAboutStateChange();
            }
        }

        public int NumberOfItems
        {
            get => _state.NumberOfItems;
            set
            {
                _state.NumberOfItems = value;
                NotifyAboutStateChange();
            }
        }

        public bool HasItem => _state?.Item != null;

        public ItemDefinition Item => _state?.Item;

        public void Clear()
        {
            State = null;
        }

        private void NotifyAboutStateChange()
        {
            StateChange?.Invoke(this, new InventorySlotStateChangeMsg(_state, _active));
        }
        
    }
}

