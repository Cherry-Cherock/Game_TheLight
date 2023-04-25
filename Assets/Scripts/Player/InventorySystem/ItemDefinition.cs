using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item Definition", fileName = "New Item definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private bool _isStackable;
        [SerializeField]
        private Sprite _inGameSprite;
        [SerializeField]
        private Sprite _uiSprite;

        public string Name => _name;
        public bool IsStackable => _isStackable;
        public Sprite InGameSprite => _inGameSprite;
        public Sprite UiSprite => _uiSprite;
    }
}

