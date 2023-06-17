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
            if (other.TryGetComponent<GameItem>(out var gameItem))
            {
                if (gameItem.Stack.Item.IsRing)
                {
                    BuffRingInventory.AddRingsInventory(gameItem.Pick());
                }
                else
                {
                    if (_inventory.CanAcceptItem(gameItem.Stack))
                    {
                        _inventory.AddItem(gameItem.Pick());
                    }
                }
            }
        }
    }
}

