using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.InventorySystem
{
    public class ItemCollisionHandler : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GetComponentInParent<Inventory>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(! other.TryGetComponent<GameItem>(out var gameItem) || !_inventory.CanAcceptItem(gameItem.Stack)) return;
            _inventory.AddItem(gameItem.Pick());
        }
    }
}

