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
                    if (!BuffRingInventory.IsRingsInventoryAvaliable(other.gameObject))
                    {
                        gameItem.Pick();
                        return;
                    }
                    BuffRingInventory.AddRingsInventory(gameItem.Pick());
                }else if (gameItem.Stack.Item.Id==1)
                {
                    //is gold
                    _inventory.AddGold(gameItem.Pick());
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

