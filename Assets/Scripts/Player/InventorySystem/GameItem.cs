using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.InventorySystem
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField] 
        private ItemStack _stack;

        [SerializeField] 
        private SpriteRenderer _spriteRenderer;

        public ItemStack Stack => _stack;
        private void OnValidate()
        {
            SetupGameObject();
        }

        private void SetupGameObject()
        {
            if(_stack.Item == null) return;
            SetGameSprite();
            UpdateItemName();
            AdjustNumberOfItem();
        }

        private void SetGameSprite()
        {
            _spriteRenderer.sprite = _stack.Item.InGameSprite;
        }

        private void UpdateItemName()
        {
            var name = _stack.Item.Name;
            var number = _stack.IsStackable ? _stack.NumberOfItems.ToString() : "ns";
            gameObject.name = $"{name} ({number})";
        }

        private void AdjustNumberOfItem()
        {
            _stack.NumberOfItems = _stack.NumberOfItems;
        }

        public ItemStack Pick()
        {
            Destroy(gameObject);
            return _stack;
        }
    }
}

