using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item Definition", fileName = "New Item definition")]
    public class ItemDefinition : ScriptableObject
    { 
        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private bool _isStackable;
        [SerializeField]
        private int _effectValue;
        [SerializeField] 
        private bool _canBeUsed;
        [SerializeField]
        private Sprite _inGameSprite;
        [SerializeField]
        private Sprite _uiSprite;
        [SerializeField] 
        private int _dropChance;

        public int Id => _id;
        public string Name => _name;
        public bool IsStackable => _isStackable;
        public bool CanBeUsed => _canBeUsed;
        public int EffectValue => _effectValue;
        public Sprite InGameSprite => _inGameSprite;
        public Sprite UiSprite => _uiSprite;
        public int DropChance => _dropChance;
    }
}

