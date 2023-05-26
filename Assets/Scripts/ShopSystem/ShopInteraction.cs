using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopInteraction : MonoBehaviour
{
    private PlayerControl inputSystem;
    public GameObject obj;
    //-------------Events-----------------
    public delegate void ShopEvent(); 
    public static event ShopEvent shop;

    private void Awake()
    {
        inputSystem = InputManager.inputActions;
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Player.Interaction.performed += StartShopping;
    }

    private void OnDisable()
    {
        inputSystem.Player.Interaction.performed -= StartShopping;
    }

    private void StartShopping(InputAction.CallbackContext ctx)
    {
        if (GameManager.currentInteractionState == GameManager.InteractionType.SHOP)
        {
            shop.Invoke();
            UIManager.Show<ShopUI>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(true);
            GameManager.currentInteractionState = GameManager.InteractionType.SHOP;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.currentInteractionState = GameManager.InteractionType.NONE;
        obj.SetActive(false);
    }
}
