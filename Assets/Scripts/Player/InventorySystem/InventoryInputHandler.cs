using Player.InventorySystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInputHandler : MonoBehaviour
{

    private Inventory _inventory;
    private PlayerControl inputSystem;
    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        inputSystem = InputManager.inputActions;
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Inventory.IndexLeft.performed += PreviousItem;
        inputSystem.Inventory.IndexRight.performed += NextItem;
        inputSystem.Inventory.Use.performed += UseItem;
        inputSystem.Player.dropItem.performed += OnDropItem;
    }

    private void OnDisable()
    {
        inputSystem.Inventory.IndexLeft.performed -= PreviousItem;
        inputSystem.Inventory.IndexRight.performed -= NextItem;
        inputSystem.Inventory.Use.performed -= UseItem;
        inputSystem.Player.dropItem.performed -= OnDropItem;
    }

    private void OnDropItem(InputAction.CallbackContext ctx)
    {
        //drop item
        //检查该索引插槽中是否有物体
        if (_inventory.GetActiveSlot().HasItem)
        {
            _inventory.RemoveItem(_inventory.ActiveSlotIndex, true);
        }
    }

    private void NextItem(InputAction.CallbackContext ctx)
    {
        _inventory.ActivateSlot(_inventory.ActiveSlotIndex +1);
    }

    private void PreviousItem(InputAction.CallbackContext ctx)
    {
        _inventory.ActivateSlot(_inventory.ActiveSlotIndex -1);
    }

    private void UseItem(InputAction.CallbackContext ctx)
    {
        if (_inventory.GetActiveSlot().HasItem)
        {
            _inventory.UseItem(_inventory.ActiveSlotIndex);
        }
    }
    
}
